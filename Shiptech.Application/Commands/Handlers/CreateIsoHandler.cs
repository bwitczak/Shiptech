using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class CreateIsoHandler(IIsoRepository repository, IIsoFactory factory, IIsoReadService readService)
    : ICommandHandler<CreateIso>
{
    public async Task HandleAsync(CreateIso command)
    {
        var (id, isoRevision, system, @class, atest, kzmNumber, kzmDate) = command;

        if (await readService.ExistsById(id))
        {
            throw new IsoIdAlreadyExistsException(id);
        }

        var iso = factory.Create(id, isoRevision, system, @class, atest, kzmNumber, kzmDate);
        await repository.CreateAsync(iso);
    }
}