using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateDrawing(Guid Id, string Name, char DrawingRevision, string Lot, string Block, string Section,
    string Stage, DateTime Date, string Author) : ICommand;