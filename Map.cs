using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using DiseaseModeling.MapElements;

namespace DiseaseModeling
{
    public enum Direction
    {
        Left,
        Up,
        Right,
        Down,
    }

    public class Map : IEnumerable<Cell>
    {
        private Cell[,] cells;

        public event EventHandler? MapChanged;

        private void onCellChanged(object sender, EventArgs args)
        {
            MapChanged?.Invoke(sender, args);
        }

        public Map(int rows, int columns)
        {
            cells = new Cell[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cells[i, j] = new Cell(this, i + 1, j + 1);
                    cells[i, j].ContentsChanged += onCellChanged;
                }
            }
        }

        public Cell this[int row, int col]
        {
            get
            {
                return cells[row - 1, col - 1];
            }
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return (cells.Clone() as Cell[,]).Cast<Cell>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (cells.Clone() as Cell[,]).GetEnumerator();
        }

        public Cell? GetAdjacent(Cell? cell, Direction direction)
        {
            if (cell == null) return null;

            Cell? res = null;

            try
            {
                int i = cell.Row - 1;
                int j = cell.Column - 1;

                switch (direction)
                {
                    case Direction.Left:
                        res = cells[i, j - 1];
                        break;
                    case Direction.Up:
                        res = cells[i - 1, j];
                        break;
                    case Direction.Right:
                        res = cells[i, j + 1];
                        break;
                    case Direction.Down:
                        res = cells[i + 1, j];
                        break;
                }
            }
            catch (IndexOutOfRangeException) { }

            return res;
        }

        public int CountType(Type type)
        {
            int count = 0;
            foreach (var c in cells)
                foreach (var el in c)
                {
                    Type t = el.GetType();
                    if (type == t || type.IsSubclassOf(t))
                        count++;
                }

            return count;
        }

        public override string ToString()
        {
            int rows = cells.GetLength(0);
            int columns = cells.GetLength(1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sb.Append(cells[i, j].ToString()  + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}