using System.Linq.Expressions;

namespace DiseaseModeling
{

    public abstract class MapElement
    {
        private Cell? cell;

        public abstract char Syllable { get; }
        public event EventHandler? CellChanged;

        public Cell? Cell 
        {
            get
            {
                return cell;
            }
        }

        private bool moveTo(Cell? cell)
        {
            if (this.cell == null || cell == null) return false;

            if (this.cell.TryRemove(this) && cell.TryAdd(this))
            {
                this.cell = cell;
                CellChanged?.Invoke(this, new EventArgs());
                return true;
            }

            return false;
        }

        public bool Move(Direction direction)
        {
            return moveTo(cell?.Map.GetAdjacent(cell, direction));
        }

        public MapElement() { }

        public override string ToString()
        {
            return "(" + Syllable + ")";
        }
    }
}