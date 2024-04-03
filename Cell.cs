using System.Text;

namespace DiseaseModeling
{
    public class Cell : IEnumerable<MapElement>
    {
        private readonly List<MapElement> contents;

        public const int Capacity = 2;

        public int Row { get; private set; }
        public int Column { get; private set; }
        public Map Map { get; }

        public event EventHandler? ContentsChanged;


        public bool TryAdd(MapElement entity)
        {
            if (contents.Count < Capacity)
            {
                contents.Add(entity);
                ContentsChanged?.Invoke(this, new EventArgs());
                return true;
            }

            return false;
        }

        public bool TryRemove(MapElement entity)
        {
            bool res = contents.Remove(entity);
            ContentsChanged?.Invoke(this, new EventArgs());
            return res;
        }

        public IEnumerator<MapElement> GetEnumerator()
        {
            return contents.ToList().GetEnumerator();
        }

        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return contents.ToList().GetEnumerator();
        }

        public Cell(Map map, int row, int col)
        {
            Map = map;
            Row = row;
            Column = col;
            contents = new List<MapElement>(Capacity);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (var e in contents)
            {
                sb.Append(e.ToString());
            }
            sb.Append(']');

            return sb.ToString();
        }
    }
}