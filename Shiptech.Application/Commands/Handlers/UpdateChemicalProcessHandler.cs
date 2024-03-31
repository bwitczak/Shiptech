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
        var (id, chemicalProcessCode, chemicalProcessName) = command;

        var updated = factory.Create(id, chemicalProcessCode, chemicalProcessName);
        await repository.UpdateAsync(updated);
    }
}