using System.Linq.Expressions;

namespace DiseaseModeling
{

    public abstract class MapElement
    {
        private Cell cell;

        protected string syllable = "";

        public string Syllable
        {
            get => syllable;
            set => syllable = value;
        }
        public event EventHandler? CellChanged;

        public Cell Cell 
        {
            get
            {
                return cell;
            }
        }

        private bool moveTo(Cell? cell)
        {
            if (cell == null) return false;

            if (cell.TryAdd(this))
            {
                this.cell.TryRemove(this);
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

        public abstract void DoAction();

        private MapElement() { }

        public MapElement(Cell cell)
        {
            if (cell.TryAdd(this) == false)
                throw new ArgumentException("Cell is full");

            this.cell = cell;
        }

        public override string ToString()
        {
            return "(" + Syllable + ")";
        }
    }
}