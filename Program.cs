using DiseaseModeling.Diseases;
using DiseaseModeling.MapElements;

namespace DiseaseModeling
{
    class Program
    {
        public static void Main()
        {
            int iterations = Configuration.Iterations;
            DataModel m = new DataModel(
                Configuration.Disease,
                Configuration.MapRows,
                Configuration.MapCols);

            for (int i = 0; i < iterations; i++)
            {
                Console.Clear();
                Console.WriteLine("Итерация " + i);
                if (Configuration.Interactive)
                {
                    Console.WriteLine("Количество больных " + m.Disease.InfectedCount);
                    Console.WriteLine("Количество умерших " + m.Disease.VictimsCount);
                    Console.WriteLine();
                    Console.WriteLine(m);
                }
                Thread.Sleep(Configuration.DelayMs);
                m.Iterate();
            }

            int peopleCount = m.Map.CountType(typeof(Human));
            int doctorsCount = m.Map.CountType(typeof(Doctor));

            // Подсчёт живых
            int aliveCount = 0;

            // Подсчёт вакцинированных
            int vaccinatedCount = 0;

            foreach (var c in m.Map)
            {
                foreach (var el in c)
                {
                    if (el is Human human)
                    {
                        if (human.Vaccinated)
                            vaccinatedCount++;
                        
                        if (human.IsDead == false)
                            aliveCount++;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("Тип болезни:\t" + m.Disease);
            Console.WriteLine("Пройденное время:\t" + m.Time);
            Console.WriteLine("Количество людей (обычных):\t" +
                peopleCount);
            Console.WriteLine("Количество живых:\t" +
                aliveCount);
            Console.WriteLine("Количество докторов:\t" +
                doctorsCount);
            Console.WriteLine("Количество инфицированных:\t" + m.Disease.InfectedCount);
            Console.WriteLine("Количество вакцинированных:\t" + vaccinatedCount);
            Console.WriteLine("Количество умерших:\t" + m.Disease.VictimsCount);
            Console.WriteLine();
            Console.WriteLine(m);
        }
    }
}