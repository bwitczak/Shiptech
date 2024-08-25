using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class DrawingFactory : IDrawingFactory
{
    public Drawing Create(Ulid id, string number, string name, char revision, string? lot, string? block,
        List<string>? section, string? stage, Ship ship)
    {
        return new Drawing {Id = id, Number = number, Name = name, Revision = revision, Lot = lot, Block = block, Section = section, Stage = stage, Ship = ship};
    }
}
