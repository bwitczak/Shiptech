using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

public class CreateAssortmentHandler : ICommandHandler<CreateAssortment>
{
    private readonly IAssortmentRepository _repository;
    private readonly IAssortmentFactory _factory;
    private readonly IAssortmentReadService _readService;
    
    public async Task HandleAsync(CreateAssortment command)
    {
        var (id, position,  drawingLength,  addition,
             technologicalAddition,  stage, d15I, d15II, d1I, d1II,
             prefabricationQuantity,  prefabricationLength,  prefabricationWeight,
             assemblyQuantity,  assemblyLength, assemblyWeight) = command;
    
        if (await _readService.ExistsById(id))
        {
            throw new AssortmentIdAlreadyExistsException(id);
        }

        var drawing = _factory.Create(id, position,  drawingLength,  addition,
            technologicalAddition,  stage, d15I, d15II, d1I, d1II,
            prefabricationQuantity,  prefabricationLength,  prefabricationWeight,
            assemblyQuantity,  assemblyLength, assemblyWeight) ;

        await _repository.CreateAsync(drawing);
    }
}