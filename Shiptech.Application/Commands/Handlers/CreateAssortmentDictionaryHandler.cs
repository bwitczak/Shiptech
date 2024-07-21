using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class CreateAssortmentDictionaryHandler(IAssortmentDictionaryRepository repository, IAssortmentDictionaryFactory factory)
    : ICommandHandler<CreateAssortmentDictionary>
{
    public async Task HandleAsync(CreateAssortmentDictionary command)
    {
        var (id, number, name, distinguishing, unit, amount, weight, material, kind, dn1, dn2, length, ro, comment) = command;

        var assortmentDictionary = factory.Create(Ulid.NewUlid(), number, name, distinguishing, unit, amount, weight, material, kind, dn1, dn2, length, ro, comment);
        await repository.CreateAsync(assortmentDictionary);
    }
}