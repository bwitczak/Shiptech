using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

public class CreateDrawingHandler : ICommandHandler<CreateDrawing>
{
    private readonly IDrawingRepository _repository;
    private readonly IDrawingFactory _factory;
    private readonly IDrawingReadService _readService;

    public CreateDrawingHandler(IDrawingRepository repository, IDrawingFactory factory, IDrawingReadService readService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
    }

    public async Task HandleAsync(CreateDrawing command)
    {
        var (id, drawingRevision, lot, block, section, stage, date, author) = command;
    
        if (await _readService.ExistsById(id))
        {
            throw new DrawingIdAlreadyExistsException(id);
        }

        var drawing = _factory.Create(id, drawingRevision, lot, block, section, stage, date, author);

        await _repository.CreateAsync(drawing);
    }
}