using DiseaseModeling.Diseases;

namespace DiseaseModeling
{
    class Program
    {
        public static void Main()
        {
            DataModel m = new DataModel(new Virus(), 5, 10);
            Console.WriteLine(m);
        }
    }
}