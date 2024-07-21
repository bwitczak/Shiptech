using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateAssortmentDictionaryHandler(IAssortmentDictionaryRepository repository, IAssortmentDictionaryFactory factory)
    : ICommandHandler<UpdateAssortmentDictionary>
{
    public async Task HandleAsync(UpdateAssortmentDictionary command)
    {
        var (id, number, name, distinguishing, unit, amount, weight, material, kind, dn1, dn2, length, ro, comment) = command;

        var updated = factory.Create(id, number, name, distinguishing, unit, amount, weight, material, kind, dn1, dn2, length, ro, comment);
        await repository.UpdateAsync(updated);
    }
}