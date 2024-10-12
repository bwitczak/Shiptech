using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Ships.Commands.CreateShip;

public record CreateShipCommand(string Code, Ulid ShipownerId) : IRequest
{
}

public class CreateShipCommandValidator : AbstractValidator<CreateShipCommand>
{
    public CreateShipCommandValidator(IShipService service)
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_SHIP_400_CODE")
            .WithMessage("Kod statku nie może być pusty!")
            .MustAsync(async (x, _) => !await service.ExistsByCode(x))
            .WithMessage(x => $"{x.Code} już istnieje w bazie!")
            .WithErrorCode("CREATE_SHIP_409_CODE");
    }
}

public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IShipFactory _factory;

    public CreateShipCommandHandler(IApplicationDbContext context, IShipFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateShipCommand request, CancellationToken cancellationToken)
    {
        (string code, Ulid shipownerId) = request;

        Shipowner shipowner = await _context.Shipowners.FirstAsync(x => x.Id == shipownerId, cancellationToken);
        Ship ship = _factory.Create(Ulid.NewUlid(), code, shipowner);

        await _context.Ships.AddAsync(ship, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
