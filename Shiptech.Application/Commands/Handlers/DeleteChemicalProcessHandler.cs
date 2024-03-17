using Shiptech.Application.Exceptions;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class DeleteChemicalProcessHandler
    (IChemicalProcessRepository repository) : ICommandHandler<DeleteChemicalProcess>
{
    public async Task HandleAsync(DeleteChemicalProcess command)
    {
        var chemicalProcess = await repository.GetAsync(command.Id);

        await repository.DeleteAsync(chemicalProcess);
    }
}