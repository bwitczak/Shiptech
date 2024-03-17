using Shiptech.Application.Exceptions;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class DeleteDrawingHandler
    (IDrawingRepository repository) : ICommandHandler<DeleteDrawing>
{
    public async Task HandleAsync(DeleteDrawing command)
    {
        var drawing = await repository.GetAsync(command.Id);

        await repository.DeleteAsync(drawing);
    }
}