using DiseaseModeling.Diseases;

namespace DiseaseModeling
{
    public class DataModel
    {
        private int time;

        public IDisease Disease { get; }
        public Map Map { get; }

        public DataModel(IDisease disease, int rows, int cols)
        {
            Disease = disease;
            Map = new Map(rows, cols);

            for (int i = 0; i < Configuration.HealthyPeopleCount; i++)
            {
                Random random = new Random();
                int row = random.Next(1, rows + 1);
                int col = random.Next(1, cols + 1);
                Map[row, col].TryAdd(new Human());
            }

            for (int i = 0; i < Configuration.SickPeopleCount; i++)
            {
                Random random = new Random();
                int row = random.Next(1, rows + 1);
                int col = random.Next(1, cols + 1);
                Human h = new Human();
                h.MakeSick(disease);
                Map[row, col].TryAdd(h);
            }
        }

        public override string ToString()
        {
            return Map.ToString();
        }
    }
}