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
        var (_, chemicalProcessCode, chemicalProcessName) = command;

        var chemicalProcess = factory.Create(Ulid.NewUlid(), chemicalProcessCode, chemicalProcessName);
        await repository.CreateAsync(chemicalProcess);
    }
}