using Shiptech.Application.Exceptions;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateShipHandler(IShipRepository repository, IShipFactory factory) : ICommandHandler<UpdateShip>
{
    public async Task HandleAsync(UpdateShip command)
    {
        var (id, orderer) = command;
        var ship = await repository.GetAsync(id);

        // if (ship is null)
        // {
        //     throw new ShipIdNotExistsException(id);
        // }

        var updated = factory.Create(id, orderer);
        await repository.UpdateAsync(updated);
    }
}