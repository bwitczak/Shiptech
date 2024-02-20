using Shiptech.Application.Exceptions;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateChemicalProcessHandler(IChemicalProcessRepository repository,
        IChemicalProcessFactory factory)
    : ICommandHandler<UpdateChemicalProcess>
{
    public async Task HandleAsync(UpdateChemicalProcess command)
    {
        var (id, chemicalProcessName) = command;
        var chemicalProcess = await repository.GetAsync(id);

        if (chemicalProcess is null)
        {
            throw new ChemicalProcessNotExistsException(id);
        }

        var updated = factory.Create(id, chemicalProcessName);
        await repository.UpdateAsync(updated);
    }
}