using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class DrawingFactory : IDrawingFactory
    {
        public Drawing Create(DrawingId id, Revision drawingRevision, Lot lot, Block block, Section section, Stage stage, Date date, Author author)
            => new(id, drawingRevision, lot, block, section, stage, date, author);
    }
}