using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DiseaseModeling
{
    public enum Direction
    {
        Left,
        Up,
        Right,
        Down,
    }

    public class Map
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

        public IEnumerable<Cell> GetEnumerable()
        {
            foreach (var c in cells)
                yield return c;
        }

        public Cell? GetAdjacent(Cell? cell, Direction direction)
        {
            if (cell == null) return null;

            if (cell.Row < 1 || cell.Row > cells.GetLength(0) ||
                cell.Column < 1 || cell.Column > cells.GetLength(1)) return null;

            switch (direction)
            {
                case Direction.Left:
                    return cells[cell.Row, cell.Column - 1];
                case Direction.Up:
                    return cells[cell.Row - 1, cell.Column];
                case Direction.Right:
                    return cells[cell.Row, cell.Column + 1];
                case Direction.Down:
                    return cells[cell.Row + 1, cell.Column];
            }

            return null;
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
                    sb.Append(cells[i, j].ToString());
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}