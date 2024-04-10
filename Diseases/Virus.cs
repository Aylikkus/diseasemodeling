using System.Reflection.Metadata.Ecma335;

namespace DiseaseModeling.Diseases
{
    class Virus : Disease
    {
        public override int Contagiousness => 10;

        public override int Duration => 30;

        public override int Mortality => 2;
    }
}