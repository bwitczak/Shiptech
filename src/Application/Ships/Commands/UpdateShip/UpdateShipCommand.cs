using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Ships.Commands.UpdateShip;

public record UpdateShipCommand(Ulid Id, string Code, Ulid ShipownerId) : IRequest
{
}

public class UpdateShipCommandValidator : AbstractValidator<UpdateShipCommand>
{
    public UpdateShipCommandValidator(IShipService shipService, IShipownerService shipownerService)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_SHIP_400_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await shipService.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_SHIP_404_ID");

        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_SHIP_400_CODE")
            .WithMessage("Kod statku nie może być pusty!")
            .MustAsync(async (x, _) => !await shipService.ExistsByCode(x))
            .WithMessage(x => $"{x.Code} już istnieje w bazie!")
            .WithErrorCode("CREATE_SHIP_409_ID");

        RuleFor(x => x.ShipownerId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nazwa zamawiającego nie może być pusta!")
            .WithErrorCode("UPDATE_SHIP_400_ORDERER")
            .MustAsync(async (x, _) => await shipownerService.ExistsById(x))
            .WithMessage(x => $"{x.ShipownerId} już istnieje w bazie!")
            .WithErrorCode("UPDATE_SHIP_409_ORDERER");
    }
}

public class UpdateShipCommandHandler : IRequestHandler<UpdateShipCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IShipFactory _factory;

    public UpdateShipCommandHandler(IApplicationDbContext context, IShipFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(UpdateShipCommand request, CancellationToken cancellationToken)
    {
        (Ulid id, string code, Ulid shipownerId) = request;

        Shipowner shipowner = await _context.Shipowners.FirstAsync(x => x.Id == shipownerId, cancellationToken);
        Ship updated = _factory.Create(id, code, shipowner);

        _context.Ships.Update(updated);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
