namespace DiseaseModeling.Diseases
{
    public interface IDisease
    {
        int Mortality { get; }
        int Contagiousness { get; }
        int Heaviness { get; }
    }
}