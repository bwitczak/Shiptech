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
        var (_, name, drawingRevision, lot, block, section, stage, date, author) = command;

        var drawing = factory.Create(Ulid.NewUlid(), name, drawingRevision, lot, block, section, stage, date, author);
        await repository.CreateAsync(drawing);
    }
}