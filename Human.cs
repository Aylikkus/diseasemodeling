using DiseaseModeling.Diseases;

namespace DiseaseModeling
{
    public class Human : MapElement
    {
        private IDisease? sickness;
        public override char Syllable => sickness == null ? 'h' : 's';

        public bool MakeSick(IDisease disease)
        {
            sickness = disease;
            return true;
        }
    }
}