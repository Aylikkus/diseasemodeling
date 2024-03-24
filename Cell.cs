namespace DiseaseModeling
{
    public class Cell
    {
        private readonly List<object> contents;

        public const int Capacity = 3;

        public bool TryAdd(object entity)
        {
            if (contents.Count < Capacity)
            {
                contents.Add(entity);
                return true;
            }

            return false;
        }

        public IEnumerator<object> GetEnumerator
        {
            get
            {
                return contents.GetEnumerator();
            }
        }

        public Cell()
        {
            contents = new List<object>(Capacity);
        }
    }
}