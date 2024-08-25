using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Constants;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Isos.Commands.CreateIso;

public record CreateIsoCommand(string Number, string Nameplate, char Revision, string System, string Class, string? Atest, string? KzmNumber, DateOnly? KzmDate, Ulid DrawingId, Ulid ChemicalProcessId) : IRequest
{
}

public class CreateIsoCommandValidator : AbstractValidator<CreateIsoCommand>
{
    public CreateIsoCommandValidator(IDrawingService drawingService, IChemicalProcessService chemicalProcessService)
    {
        RuleFor(x => x.Number)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_NUMBER")
            .WithMessage("Numer ISO nie może być puste!");
        
        RuleFor(x => x.Nameplate)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_NAMEPLATE")
            .WithMessage("Tabliczka znamionowa ISO nie może być pusta!");
        
        RuleFor(x => x.Revision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Must(char.IsLetterOrDigit)
            .WithErrorCode("CREATE_ISO_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.Revision}! Wymagany 1 znak");

        RuleFor(x => x.System)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_SYSTEM")
            .WithMessage("Nazwa systemu nie może być pusta!")
            .Must(x => x.Split("-").Length == 1 && x.Split("-").Length == 2)
            .WithErrorCode("CREATE_ISO_400_SYSTEM")
            .WithMessage(x => $"Niepoprawny format systemu izometryka {x.System}! Wymagany format XXX lub XXX-XXX");
        
        RuleFor(x => x.Class)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_CLASS")
            .WithMessage("Nazwa klasy nie może być pusta!")
            .Must(x => x.Length == 6)
            .WithErrorCode("CREATE_ISO_400_CLASS")
            .WithMessage(x => $"Nie poprawna klasa {x.Class}! Wymagane 6 znaków");

        When(x => x.Atest is not null, () =>
        {
            RuleFor(x => x.Atest)
                .Must(x => x is Atest.None or Atest.Yes or Atest.No)
                .WithErrorCode("CREATE_ISO_400_ATEST")
                .WithMessage(x => $"Nie poprawny atest {x.Atest}! Wymagane Tak/Nie/Puste");
        });

        When(x => x.KzmNumber is not null, () =>
        {
            RuleFor(x => x.KzmNumber)
                .Must(x => x!.Length == 6)
                .WithErrorCode("CREATE_ISO_400_KZM_NUMBER")
                .WithMessage(x => $"Niepoprawny format numeru KZM {x.KzmNumber}! Wymagane 6 znaków");
        });

        When(x => x.KzmDate is not null, () =>
        {
            RuleFor(x => x.KzmDate)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ISO_400_KZM_DATE")
                .WithMessage("Data KZM nie może być pusta!");
        });
        
        RuleFor(x => x.DrawingId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ISO_400_DRAWING_ID")
            .WithMessage("Identyfikator ISO nie może być pusty!")
            .MustAsync(async (x, _) => await drawingService.ExistsById(x))
            .WithMessage(x => $"{x.DrawingId} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_ISO_404_DRAWING_ID");
        
        RuleFor(x => x.ChemicalProcessId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ISO_400_CHEMICAL_PROCESS_ID")
            .WithMessage("Identyfikator ISO nie może być pusty!")
            .MustAsync(async (x, _) => await chemicalProcessService.ExistsById(x))
            .WithMessage(x => $"{x.ChemicalProcessId} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_ISO_404_CHEMICAL_PROCESS_ID");
    }
}

public class CreateIsoCommandHandler : IRequestHandler<CreateIsoCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IIsoFactory _factory;

    public CreateIsoCommandHandler(IApplicationDbContext context, IIsoFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateIsoCommand request, CancellationToken cancellationToken)
    {
        var (number, nameplate, revision, system, @class, atest, kzmNumber, kzmDate, drawingId, chemicalProcessId) = request;

        var drawing = await _context.Drawings.FirstAsync(x => x.Id == drawingId, cancellationToken: cancellationToken);
        var chemicalProcess = await _context.ChemicalProcesses.FirstAsync(x => x.Id == chemicalProcessId, cancellationToken: cancellationToken);
        var iso = _factory.Create(Ulid.NewUlid(), number, nameplate, revision, system, @class, atest, kzmNumber, kzmDate, drawing, chemicalProcess);
        
        await _context.Isos.AddAsync(iso, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
