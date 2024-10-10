using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Constants;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Drawings.Commands.CreateDrawing;

public record CreateDrawingCommand(
    string Number,
    string Name,
    char Revision,
    string? Lot,
    string? Block,
    List<string>? Section,
    string? Stage,
    Ulid ShipId) : IRequest
{
}

public class CreateDrawingCommandValidator : AbstractValidator<CreateDrawingCommand>
{
    public CreateDrawingCommandValidator(IShipService shipService, IDrawingService drawingService)
    {
        RuleFor(x => x.Number)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_NUMBER")
            .WithMessage("Numer rysunku nie może być pusty!")
            .MustAsync(async (x, _) => !await drawingService.ExistsByNumber(x))
            .WithMessage(x => $"{x.Number} istnieje w bazie!")
            .WithErrorCode("CREATE_DRAWING_409_NUMBER");
        ;

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_NAME")
            .WithMessage("Nazwa rysunku nie może być pusta!");

        RuleFor(x => x.Revision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Must(char.IsLetterOrDigit)
            .WithErrorCode("CREATE_DRAWING_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.Revision}! Wymagany 1 znak");

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
                .WithErrorCode("CREATE_DRAWING_400_LOT")
                .WithMessage(x => $"Niepoprawny lot {x.Lot}! Wymagane > 99 oraz < 1000");
        });

        When(x => x.Block is not null, () =>
        {
            RuleFor(x => x.Block)
                .Must(x => x!.Length == 3)
                .WithErrorCode("CREATE_DRAWING_400_BLOCK")
                .WithMessage(x => $"Niepoprawny blok {x.Block}! Wymagane > 99 oraz < 1000");
        });

        When(x => x.Section is not null, () =>
        {
            RuleForEach(x => x.Section)
                .Cascade(CascadeMode.Stop)
                .Must(x =>
                {
                    if (!int.TryParse(x, out int number))
                    {
                        return false;
                    }

                    return number is >= 100 and <= 999;
                })
                .WithErrorCode("CREATE_DRAWING_400_SECTION")
                .WithMessage(_ => "Niepoprawna sekcja! Wymagane > 999 oraz < 10000");
        });

        When(x => x.Stage is not null, () =>
        {
            RuleFor(x => x.Stage)
                .Must(x => x is Stage.None or Stage.ODP or Stage.ODS or Stage.ODI)
                .WithErrorCode("CREATE_DRAWING_400_STAGE")
                .WithMessage(x => $"Niepoprawna sekcja {x.Stage}! Wymagane ODP/ODS/ODI/Puste");
        });

        RuleFor(x => x.ShipId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_SHIP_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await shipService.ExistsById(x))
            .WithMessage(x => $"{x.ShipId} nie istnieje w bazie!")
            .WithErrorCode("CREATE_DRAWING_404_SHIP_ID");
    }
}

public class CreateDrawingCommandHandler : IRequestHandler<CreateDrawingCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDrawingFactory _factory;

    public CreateDrawingCommandHandler(IApplicationDbContext context, IDrawingFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateDrawingCommand request, CancellationToken cancellationToken)
    {
        (string number, string name, char revision, string? lot, string? block, List<string>? section, string? stage,
            Ulid shipId) = request;

        Ship ship = await _context.Ships.FirstAsync(x => x.Id == shipId, cancellationToken);
        Drawing drawing = _factory.Create(Ulid.NewUlid(), number, name, revision, lot, block, section, stage, ship);

        await _context.Drawings.AddAsync(drawing, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
