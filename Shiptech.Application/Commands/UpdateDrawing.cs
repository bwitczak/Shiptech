using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateDrawing(Ulid Id, string Name, char DrawingRevision, string? Lot, string? Block, List<string>? Section,
    string? Stage, DateTime CreationDate, string Author) : ICommand;