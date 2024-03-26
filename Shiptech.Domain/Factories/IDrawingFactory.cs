using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IDrawingFactory
    {
        Drawing Create(Id id, DrawingName name, Revision drawingRevision, Lot lot, Block block, Section section, Stage stage, CreationDate kzmDate, Author author);
    }
}