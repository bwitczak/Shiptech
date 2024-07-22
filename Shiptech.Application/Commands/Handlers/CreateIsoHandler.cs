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
        var (_, name, isoRevision, system, @class, atest, kzmNumber, kzmDate) = command;

        var iso = factory.Create(Ulid.NewUlid(), name, isoRevision, system, @class, atest, kzmNumber, kzmDate);
        await repository.CreateAsync(iso);
    }
}