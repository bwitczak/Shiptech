using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

public class CreateIsoHandler : ICommandHandler<CreateIso>
{
    private readonly IIsoRepository _repository;
    private readonly IIsoFactory _factory;
    private readonly IIsoReadService _readService;
    public async Task HandleAsync(CreateIso command)
    {
        var (id, isoRevision, system, @class, atest, kzmNumber, kzmDate) = command;
    
        if (await _readService.ExistsById(id))
        {
            throw new DrawingIdAlreadyExistsException(id);
        }

        var iso = _factory.Create(id, isoRevision, system, @class, atest, kzmNumber, kzmDate);

        await _repository.CreateAsync(iso);
    }
}