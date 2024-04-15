using DiseaseModeling.Diseases;
using DiseaseModeling.MapElements;

namespace DiseaseModeling
{
    public class DataModel
    {
        private int seconds;

        public TimeSpan Time
        {
            get
            {
                return new TimeSpan(0, 0, seconds);
            }
        }

        public Disease Disease { get; }
        public Map Map { get; }

        public DataModel(Disease disease, int rows, int cols)
        {
            Disease = disease;
            Map = new Map(rows, cols);

            for (int i = 0; i < Configuration.HealthyPeopleCount; i++)
            {
                Random random = new Random();
                int row = random.Next(1, rows + 1);
                int col = random.Next(1, cols + 1);
                Human h = new Human(Map[row, col]);
            }

            for (int i = 0; i < Configuration.SickPeopleCount; i++)
            {
                Random random = new Random();
                int row = random.Next(1, rows + 1);
                int col = random.Next(1, cols + 1);
                Human h = new Human(Map[row, col]);
                disease.AddInfected(h);
            }

            for (int i = 0; i < Configuration.DoctorsCount; i++)
            {
                Random random = new Random();
                int row = random.Next(1, rows + 1);
                int col = random.Next(1, cols + 1);
                Doctor d = new Doctor(Map[row, col]);
                disease.AddInfected(d);
            }
        }

        public void Iterate()
        {
            foreach (Cell cell in Map)
                foreach (MapElement elem in cell)
                    elem.DoAction();

            Disease.DoActivity();

            seconds += 3600;
        }

        

        public override string ToString()
        {
            return Map.ToString();
        }
    }
}