using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class CreateDrawingHandler(IDrawingRepository repository, IDrawingFactory factory,
        IDrawingReadService readService)
    : ICommandHandler<CreateDrawing>
{
    public async Task HandleAsync(CreateDrawing command)
    {
        var (id, drawingRevision, lot, block, section, stage, date, author) = command;
    
        if (await readService.ExistsById(id))
        {
            throw new DrawingIdAlreadyExistsException(id);
        }

        var drawing = factory.Create(id, drawingRevision, lot, block, section, stage, date, author);

        await repository.CreateAsync(drawing);
    }
}