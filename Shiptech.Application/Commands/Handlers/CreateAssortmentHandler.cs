using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class CreateAssortmentHandler(IAssortmentRepository repository, IAssortmentFactory factory,
        IAssortmentReadService readService)
    : ICommandHandler<CreateAssortment>
{
    public async Task HandleAsync(CreateAssortment command)
    {
        var (id, position, drawingLength, addition,
            technologicalAddition, stage, comment, d15I, d15II, d1I, d1II,
            prefabricationQuantity, prefabricationLength, prefabricationWeight,
            assemblyQuantity, assemblyLength, assemblyWeight) = command;

        var assortment = factory.Create(id, position, drawingLength, addition,
            technologicalAddition, stage, comment, d15I, d15II, d1I, d1II,
            prefabricationQuantity, prefabricationLength, prefabricationWeight,
            assemblyQuantity, assemblyLength, assemblyWeight);
        await repository.CreateAsync(assortment);
    }
}