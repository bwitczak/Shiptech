using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class CreateShipHandler(IShipRepository repository, IShipFactory factory, IShipReadService readService)
    : ICommandHandler<CreateShip>
{
    public async Task HandleAsync(CreateShip command)
    {
        var ship = factory.Create(Guid.NewGuid(), command.Orderer);
        await repository.CreateAsync(ship);
    }
}