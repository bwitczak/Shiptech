using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class DeleteAssortmentHandler(IAssortmentRepository repository) : ICommandHandler<DeleteAssortment>
{
    public async Task HandleAsync(DeleteAssortment command)
    {
        var assortment = await repository.GetAsync(command.Id);

        await repository.DeleteAsync(assortment);
    }
}