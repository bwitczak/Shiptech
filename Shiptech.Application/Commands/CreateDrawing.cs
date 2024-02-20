using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateDrawing(string Id, string DrawingRevision, string Lot, string Block, string Section,
    StageEnum Stage, string Date, string Author) : ICommand;