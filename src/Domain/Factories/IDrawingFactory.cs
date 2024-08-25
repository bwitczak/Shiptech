using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IDrawingFactory
{
    Drawing Create(Ulid id, string number, string name, char revision, string? lot, string? block,
        List<string>? section, string? stage, Ship ship);
}
