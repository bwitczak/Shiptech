using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

public class CreateChemicalProcessHandler : ICommandHandler<CreateChemicalProcess>
{
    private readonly IChemicalProcessRepository _repository;
    private readonly IChemicalProcessFactory _factory;
    private readonly IChemicalProcessReadService _readService;
    
    public async Task HandleAsync(CreateChemicalProcess command)
    {
        var (id,  chemicalProcessName ) = command;
    
        if (await _readService.ExistsById(id))
        {
            throw new AssortmentIdAlreadyExistsException(id);
        }

        var drawing = _factory.Create(id,  chemicalProcessName ) ;

        await _repository.CreateAsync(drawing);
    }
}