﻿using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Isos.Commands.CreateIso;

public record CreateIsoCommand(
    string Number,
    string Nameplate,
    string Revision,
    string System,
    string Class,
    string? Atest,
    string? KzmNumber,
    string? KzmDate,
    string DrawingNumber,
    string ChemicalProcessName) : IRequest
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
            .Length(1, 2)
            .WithErrorCode("CREATE_ISO_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.Revision}! Wymagane 1 lub 2 znaki");

        RuleFor(x => x.System)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_SYSTEM")
            .WithMessage("Nazwa systemu nie może być pusta!")
            .Must(x => x.Split("-").Length == 1 || x.Split("-").Length == 2)
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

        // TODO: Check validation if Atest table appears
        // When(x => x.Atest is not null, () =>
        // {
        //     RuleFor(x => x.Atest)
        //         .Must(x => x is Atest.None or Atest.Yes or Atest.No)
        //         .WithErrorCode("CREATE_ISO_400_ATEST")
        //         .WithMessage(x => $"Nie poprawny atest {x.Atest}! Wymagane Tak/Nie/Puste");
        // });

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
                .WithMessage("Data KZM nie może być pusta!")
                .Must(x => DateOnly.TryParse(x, out _))
                .WithErrorCode("CREATE_ISO_400_KZM_DATE")
                .WithMessage("Błędny format daty! (YYYY-MM-DD)");
        });

        RuleFor(x => x.DrawingNumber)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_DRAWING_NUMBER")
            .WithMessage("Numer rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await drawingService.ExistsByNumber(x))
            .WithMessage(x => $"{x.DrawingNumber} nie istnieje w bazie!")
            .WithErrorCode("CREATE_ISO_404_DRAWING_NUMEBR");

        RuleFor(x => x.ChemicalProcessName)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_CHEMICAL_PROCESS_NAME")
            .WithMessage("Identyfikator ISO nie może być pusty!")
            .MustAsync(async (x, _) => await chemicalProcessService.ExistsByName(x))
            .WithMessage(x => $"{x.ChemicalProcessName} nie istnieje w bazie!")
            .WithErrorCode("CREATE_ISO_404_CHEMICAL_PROCESS_NAME");
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
        (string number, string nameplate, string revision, string system, string @class, string? atest,
            string? kzmNumber, string? kzmDate, string drawingNumber, string chemicalProcessName) = request;

        Drawing drawing = await _context.Drawings.FirstAsync(x => x.Number == drawingNumber, cancellationToken);
        ChemicalProcess chemicalProcess =
            await _context.ChemicalProcesses.FirstAsync(x => x.Name == chemicalProcessName, cancellationToken);

        DateOnly kzmDateToDateOnly = DateOnly.Parse(kzmDate!);
        Iso iso = _factory.Create(Ulid.NewUlid(), number, nameplate, revision, system, @class, atest, kzmNumber,
            kzmDateToDateOnly, drawing, chemicalProcess);

        await _context.Isos.AddAsync(iso, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
