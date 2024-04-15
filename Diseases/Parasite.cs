using System.Reflection.Metadata.Ecma335;

namespace DiseaseModeling.Diseases
{
    class Parasite : Disease
    {
        public override int Contagiousness => 1;

        public override int Duration => 120;

        public override int Mortality => 0;

        public override string RussianName => "Паразит";
    }
}