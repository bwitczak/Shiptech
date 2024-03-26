using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateAssortmentHandler(IAssortmentRepository repository, IAssortmentFactory factory)
    : ICommandHandler<UpdateAssortment>
{
    public async Task HandleAsync(UpdateAssortment command)
    {
        var (id, position, drawingLength, addition,
            technologicalAddition, stage, comment, d15I, d15II, d1I, d1II,
            prefabricationQuantity, prefabricationLength, prefabricationWeight,
            assemblyQuantity, assemblyLength, assemblyWeight) = command;

        var updated = factory.Create(id, position, drawingLength, addition,
            technologicalAddition, stage, comment, d15I, d15II, d1I, d1II,
            prefabricationQuantity, prefabricationLength, prefabricationWeight,
            assemblyQuantity, assemblyLength, assemblyWeight);
        await repository.UpdateAsync(updated);
    }
}