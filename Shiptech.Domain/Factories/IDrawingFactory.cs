using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IDrawingFactory
    {
        Drawing Create(DrawingId id, Revision drawingRevision, Lot lot, Block block, Section section, Stage stage, Date date, Author author);
    }
}