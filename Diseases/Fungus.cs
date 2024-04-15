using System.Reflection.Metadata.Ecma335;

namespace DiseaseModeling.Diseases
{
    class Fungus : Disease
    {
        public override int Contagiousness => 1;

        public override int Duration => 240;

        public override int Mortality => 1;

        public override string RussianName => "Грибок";
    }
}