using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities
{
    public class Drawing
    {
        public DrawingId Id { get; private set; }
        private Revision _drawingRevision;
        private Lot _lot;
        private Block _block;
        private Section _section;
        private Stage _stage;
        private Date _date;
        private Author _author;

        internal Drawing(DrawingId id, Revision drawingRevision, Lot lot, Block block, Section section, Stage stage, Date date, Author author)
        {
            Id = id;
            _drawingRevision = drawingRevision;
            _lot = lot;
            _block = block;
            _section = section;
            _stage = stage;
            _date = date;
            _author = author;
        }
    }
}