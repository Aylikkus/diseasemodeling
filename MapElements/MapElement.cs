using System.Linq.Expressions;
using System.Text;

namespace DiseaseModeling.MapElements
{

    public abstract class MapElement
    {
        private Cell cell;

        protected string syllable = "";
        protected HashSet<string> modifiers = new HashSet<string>(2);

        public string Syllable
        {
            get => syllable;
            private set => syllable = value;
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

        public bool AddModifier(string mod)
        {
            return modifiers.Add(mod);
        }

        public bool RemoveModifier(string mod)
        {
            return modifiers.Remove(mod);
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
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            if (modifiers.Count > 0)
            {
                foreach (var s in modifiers)
                    sb.Append(s + ',');
                sb.Remove(sb.Length - 1, 1);
                sb.Append(':');
            }
            sb.Append(Syllable + ")");
            return sb.ToString();
        }
    }
}