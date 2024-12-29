using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Constants;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Isos.Commands.UpdateIso;

public record UpdateIsoCommand(
    Ulid Id,
    string Number,
    string Nameplate,
    string Revision,
    string System,
    string Class,
    string? Atest,
    string? KzmNumber,
    DateOnly? KzmDate,
    Ulid DrawingId,
    Ulid ChemicalProcessId) : IRequest
{
}

public class UpdateIsoCommandValidator : AbstractValidator<UpdateIsoCommand>
{
    public UpdateIsoCommandValidator(IIsoService isoService, IDrawingService drawingService,
        IChemicalProcessService chemicalProcessService)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ISO_400_ID")
            .WithMessage("Identyfikator ISO nie może być pusty!")
            .MustAsync(async (x, _) => await isoService.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_ISO_404_ID");

        RuleFor(x => x.Number)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ISO_400_NUMBER")
            .WithMessage("Numer ISO nie może być puste!");

        RuleFor(x => x.Nameplate)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_NAMEPLATE")
            .WithMessage("Tabliczka znamionowa ISO nie może być pusta!");

        RuleFor(x => x.Revision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ISO_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Length(2)
            .WithErrorCode("UPDATE_ISO_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.Revision}! Wymagane 2 znaki");

        RuleFor(x => x.System)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ISO_400_SYSTEM")
            .WithMessage("Nazwa systemu nie może być pusta!")
            .Must(x => x.Split("-").Length == 1 && x.Split("-").Length == 2)
            .WithErrorCode("UPDATE_ISO_400_SYSTEM")
            .WithMessage(x => $"Niepoprawny format systemu izometryka {x.System}! Wymagany format XXX lub XXX-XXX");

        RuleFor(x => x.Class)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ISO_400_CLASS")
            .WithMessage("Nazwa klasy nie może być pusta!")
            .Must(x => x.Length == 6)
            .WithErrorCode("UPDATE_ISO_400_CLASS")
            .WithMessage(x => $"Nie poprawna klasa {x.Class}! Wymagane 6 znaków");

        When(x => x.Atest is not null, () =>
        {
            RuleFor(x => x.Atest)
                .Must(x => x is Atest.None or Atest.Yes or Atest.No)
                .WithErrorCode("UPDATE_ISO_400_ATEST")
                .WithMessage(x => $"Nie poprawny atest {x.Atest}! Wymagane Tak/Nie/Puste");
        });

        When(x => x.KzmNumber is not null, () =>
        {
            RuleFor(x => x.KzmNumber)
                .Must(x => x!.Length == 6)
                .WithErrorCode("UPDATE_ISO_400_KZM_NUMBER")
                .WithMessage(x => $"Niepoprawny format numeru KZM {x.KzmNumber}! Wymagane 6 znaków");
        });

        When(x => x.KzmDate is not null, () =>
        {
            RuleFor(x => x.KzmDate)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("UPDATE_ISO_400_KZM_DATE")
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

public class UpdateIsoCommandHandler : IRequestHandler<UpdateIsoCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IIsoFactory _factory;

    public UpdateIsoCommandHandler(IApplicationDbContext context, IIsoFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(UpdateIsoCommand request, CancellationToken cancellationToken)
    {
        (Ulid id, string number, string nameplate, string revision, string system, string @class, string? atest,
            string? kzmNumber, DateOnly? kzmDate, Ulid drawingId, Ulid chemicalProcessId) = request;

        Drawing drawing = await _context.Drawings.FirstAsync(x => x.Id == drawingId, cancellationToken);
        ChemicalProcess chemicalProcess =
            await _context.ChemicalProcesses.FirstAsync(x => x.Id == chemicalProcessId, cancellationToken);

        Iso updated = _factory.Create(id, number, nameplate, revision, system, @class, atest, kzmNumber, kzmDate,
            drawing, chemicalProcess);

        _context.Isos.Update(updated);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
