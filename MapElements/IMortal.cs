namespace DiseaseModeling.MapElements
{
    public interface IMortal
    {
        bool Kill();

        bool IsDead { get; }
    }
}