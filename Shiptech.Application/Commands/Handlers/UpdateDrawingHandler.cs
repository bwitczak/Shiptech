using Shiptech.Application.Exceptions;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateDrawingHandler
    (IDrawingRepository repository, IDrawingFactory factory) : ICommandHandler<UpdateDrawing>
{
    public async Task HandleAsync(UpdateDrawing command)
    {
        var (id, drawingRevision, lot, block, section, stage, date, author) = command;

        var drawing = await repository.GetAsync(id);

        // if (drawing is null)
        // {
        //     throw new DrawingIdNotExistsException(id);
        // }

        var updated = factory.Create(id, drawingRevision, lot, block, section, stage, date, author);
        await repository.UpdateAsync(updated);
    }
}