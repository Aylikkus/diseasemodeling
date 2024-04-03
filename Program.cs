using DiseaseModeling.Diseases;

namespace DiseaseModeling
{
    class Program
    {
        public static void Main()
        {
            int iterations = Configuration.Iterations;
            DataModel m = new DataModel(new Virus(), 20, 20);

            for (int i = 0; i < iterations; i++)
            {
                Console.Clear();
                Console.WriteLine("Итерация " + i);
                Console.WriteLine("Количество больных " + m.Disease.InfectedCount);
                Console.WriteLine();
                Console.WriteLine(m);
                Thread.Sleep(1000);
                m.Iterate();
            }
        }
    }
}