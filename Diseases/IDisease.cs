namespace DiseaseModeling.Diseases
{
    public interface IDisease
    {
        int Mortality { get; set; }
        int Contagiousness { get; set; }
        int Heaviness { get; set; }
    }
}