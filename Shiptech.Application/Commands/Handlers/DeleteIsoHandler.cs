using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class DeleteIsoHandler(IIsoRepository repository) : ICommandHandler<DeleteIso>
{
    public async Task HandleAsync(DeleteIso command)
    {
        var iso = await repository.GetAsync(command.Id);

        await repository.DeleteAsync(iso);
    }
}