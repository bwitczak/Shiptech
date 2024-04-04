using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateShipHandler(IShipRepository repository, IShipFactory factory) : ICommandHandler<UpdateShip>
{
    public async Task HandleAsync(UpdateShip command)
    {
        var (id, code, orderer) = command;

        var updated = factory.Create(id, code, orderer);
        await repository.UpdateAsync(updated);
    }
}