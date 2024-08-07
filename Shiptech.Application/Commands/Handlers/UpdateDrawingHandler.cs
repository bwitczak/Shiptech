using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class UpdateDrawingHandler
    (IDrawingRepository repository, IDrawingFactory factory) : ICommandHandler<UpdateDrawing>
{
    public async Task HandleAsync(UpdateDrawing command)
    {
        var (id, name, drawingRevision, lot, block, section, stage, date, author) = command;

        var updated = factory.Create(id, name, drawingRevision, lot, block, section, stage, date, author);
        await repository.UpdateAsync(updated);
    }
}