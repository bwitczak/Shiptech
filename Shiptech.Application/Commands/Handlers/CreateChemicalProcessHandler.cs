using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class CreateChemicalProcessHandler(IChemicalProcessRepository repository,
        IChemicalProcessFactory factory, IChemicalProcessReadService readService)
    : ICommandHandler<CreateChemicalProcess>
{
    public async Task HandleAsync(CreateChemicalProcess command)
    {
        var (id, chemicalProcessName) = command;

        if (await readService.ExistsById(id))
        {
            throw new AssortmentIdAlreadyExistsException(id);
        }

        var drawing = factory.Create(id, chemicalProcessName);

        await repository.CreateAsync(drawing);
    }
}