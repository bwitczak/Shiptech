using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateIsoHandler(IIsoRepository repository, IIsoFactory factory) : ICommandHandler<UpdateIso>
{
    public async Task HandleAsync(UpdateIso command)
    {
        var (id, name, isoRevision, system, @class, atest, kzmNumber, kzmDate) = command;

        var updated = factory.Create(id, name, isoRevision, system, @class, atest, kzmNumber, kzmDate);
        await repository.UpdateAsync(updated);
    }
}