using System.Reflection.Metadata.Ecma335;

namespace DiseaseModeling.Diseases
{
    class Virus : IDisease
    {
        public int Mortality => 50;

        public int Contagiousness => 50;

        public int Heaviness => 25;
    }
}