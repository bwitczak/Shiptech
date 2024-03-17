using Shiptech.Application.Exceptions;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateIsoHandler(IIsoRepository repository, IIsoFactory factory) : ICommandHandler<UpdateIso>
{
    public async Task HandleAsync(UpdateIso command)
    {
        var (id, isoRevision, system, @class, atest, kzmNumber, kzmDate) = command;
        var iso = await repository.GetAsync(id);

        // if (iso is null)
        // {
        //     throw new IsoNotExistsException(id);
        // }

        var updated = factory.Create(id, isoRevision, system, @class, atest, kzmNumber, kzmDate);
        await repository.UpdateAsync(updated);
    }
}