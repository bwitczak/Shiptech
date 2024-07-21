using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class DeleteAssortmentDictionaryHandler(IAssortmentDictionaryRepository repository) : ICommandHandler<DeleteAssortmentDictionary>
{
    public async Task HandleAsync(DeleteAssortmentDictionary command)
    {
        var assortment = await repository.GetAsync(command.Id);

        await repository.DeleteAsync(assortment);
    }
}