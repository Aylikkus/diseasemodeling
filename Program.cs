using DiseaseModeling.Diseases;
using DiseaseModeling.MapElements;

namespace DiseaseModeling
{
    class Program
    {
        public static void Main()
        {
            int iterations = Configuration.Iterations;
            DataModel m = new DataModel(new ZombieVirus(),
                Configuration.MapRows,
                Configuration.MapCols);

            for (int i = 0; i < iterations; i++)
            {
                Console.Clear();
                Console.WriteLine("Итерация " + i);
                Console.WriteLine("Количество больных " + m.Disease.InfectedCount);
                Console.WriteLine("Количество умерших " + m.Disease.VictimsCount);
                Console.WriteLine();
                Console.WriteLine(m);
                Thread.Sleep(1000);
                m.Iterate();
            }

            int peopleCount = m.Map.CountType(typeof(Human));

            Console.Clear();
            Console.WriteLine("Пройденное время:\t" + m.Time);
            Console.WriteLine("Количество здоровых:\t" +
                (peopleCount - m.Disease.InfectedCount));
            Console.WriteLine("Количество инфицированных:\t" + m.Disease.InfectedCount);
            Console.WriteLine("Количество умерших " + m.Disease.VictimsCount);
        }
    }
}