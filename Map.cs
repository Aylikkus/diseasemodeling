namespace DiseaseModeling
{
    public class Map
    {
        private Cell[,] cells;

        public Map(int width, int height)
        {
            cells = new Cell[width, height];
        }

        public Cell this[int i, int j]
        {
            get
            {
                return cells[i, j];
            }
        }
    }
}