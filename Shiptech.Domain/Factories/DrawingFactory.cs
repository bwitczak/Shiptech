using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class DrawingFactory : IDrawingFactory
    {
        public Drawing Create(Id id, DrawingName name, Revision drawingRevision, Lot lot, Block block, Section section, Stage stage, CreationDate kzmDate, Author author)
            => new(id, name, drawingRevision, lot, block, section, stage, kzmDate, author);
    }
}