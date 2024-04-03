using System.Reflection.Metadata.Ecma335;

namespace DiseaseModeling.Diseases
{
    class Virus : Disease
    {
        public override int Contagiousness => 50;

        public override int Duration => 25;
    }
}