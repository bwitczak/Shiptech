using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateDrawing(string Id, char DrawingRevision, string Lot, string Block, string Section,
    string Stage, DateTime Date, string Author) : ICommand;