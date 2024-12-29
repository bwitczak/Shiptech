using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Constants;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Drawings.Commands.UpdateDrawing;

public record UpdateDrawingCommand(
    Ulid Id,
    string Number,
    string Name,
    string DrawingRevision,
    string? Lot,
    string? Block,
    List<string>? Section,
    string? Stage,
    Ulid ShipId) : IRequest
{
}

public class UpdateDrawingCommandValidator : AbstractValidator<UpdateDrawingCommand>
{
    public UpdateDrawingCommandValidator(IDrawingService drawingService, IShipService shipService)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_ID")
            .WithMessage("Identyfikator rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await drawingService.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_DRAWING_404_ID");

        RuleFor(x => x.Number)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_NUMBER")
            .WithMessage("Numer rysunku nie może być pusty!");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_NAME")
            .WithMessage("Nazwa rysunku nie może być pusta!");

        RuleFor(x => x.DrawingRevision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Length(2)
            .WithErrorCode("UPDATE_DRAWING_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.DrawingRevision}! Wymagane 2 znaki");

        When(x => x.Lot is not null, () =>
        {
            RuleFor(x => x.Lot)
                .Must(x =>
                {
                    if (!int.TryParse(x, out int number))
                    {
                        return false;
                    }

                    return number is >= 100 and <= 999;
                })
                .WithErrorCode("UPDATE_DRAWING_400_LOT")
                .WithMessage(x => $"Niepoprawny lot {x.Lot}! Wymagane > 99 oraz < 1000");
        });

        When(x => x.Block is not null, () =>
        {
            RuleFor(x => x.Block)
                .Must(x => x!.Length == 3)
                .WithErrorCode("UPDATE_DRAWING_400_BLOCK")
                .WithMessage(x => $"Niepoprawny blok {x.Block}! Wymagane > 99 oraz < 1000");
        });

        When(x => x.Section is not null, () =>
        {
            RuleForEach(x => x.Section)
                .Must(x =>
                {
                    if (!int.TryParse(x, out int number))
                    {
                        return false;
                    }

                    return number is >= 100 and <= 999;
                })
                .WithErrorCode("UPDATE_DRAWING_400_SECTION")
                .WithMessage(x => $"Niepoprawna sekcja {x.Section}! Wymagane > 999 oraz < 10000");
        });

        When(x => x.Stage is not null, () =>
        {
            RuleFor(x => x.Stage)
                .Must(x => x is Stage.None or Stage.ODP or Stage.ODS or Stage.ODI)
                .WithErrorCode("UPDATE_DRAWING_400_STAGE")
                .WithMessage(x => $"Niepoprawna sekcja {x.Stage}! Wymagane ODP/ODS/ODI/Puste");
        });

        RuleFor(x => x.ShipId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_SHIP_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await shipService.ExistsById(x))
            .WithMessage(x => $"{x.ShipId} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_DRAWING_404_SHIP_ID");
    }
}

public class UpdateDrawingCommandHandler : IRequestHandler<UpdateDrawingCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDrawingFactory _factory;

    public UpdateDrawingCommandHandler(IApplicationDbContext context, IDrawingFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(UpdateDrawingCommand request, CancellationToken cancellationToken)
    {
        (Ulid id, string number, string name, string revision, string? lot, string? block, List<string>? section,
            string? stage, Ulid shipId) = request;

        Ship ship = await _context.Ships.FirstAsync(x => x.Id == shipId, cancellationToken);
        Drawing updated = _factory.Create(id, number, name, revision, lot, block, section, stage, ship);

        _context.Drawings.Update(updated);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
