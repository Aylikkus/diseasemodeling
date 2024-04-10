namespace DiseaseModeling
{
    public static class Configuration
    {
        public static int Iterations { get; set; } = 100;
        public static int HealthyPeopleCount { get; set; } = 20;
        public static int SickPeopleCount { get; set; } = 1;
        public static int MapRows { get; set; } = 5;
        public static int MapCols { get; set; } = 5;
    }
}