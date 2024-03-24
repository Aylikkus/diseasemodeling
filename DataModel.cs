using DiseaseModeling.Diseases;

namespace DiseaseModeling
{
    public class DataModel
    {
        private int time;

        public IDisease Disease { get; }

        public DataModel(IDisease disease)
        {
            Disease = disease;
        }
    }
}