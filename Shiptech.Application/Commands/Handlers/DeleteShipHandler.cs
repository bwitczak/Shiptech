using Shiptech.Application.Exceptions;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class DeleteShipHandler(IShipRepository repository) : ICommandHandler<DeleteShip>
{
    public async Task HandleAsync(DeleteShip command)
    {
        var ship = await repository.GetAsync(command.Id);

        if (ship is null)
        {
            throw new ShipNotExistsException(command.Id);
        }

        await repository.DeleteAsync(ship);
    }
}