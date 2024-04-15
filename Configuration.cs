using DiseaseModeling.Diseases;

namespace DiseaseModeling
{
    public static class Configuration
    {
        // Количество итераций
        public static int Iterations { get; } = 100;

        // Количество здоровых людей
        public static int HealthyPeopleCount { get; } = 20;

        // Количество больных людей
        public static int SickPeopleCount { get; } = 1;

        // Количество докторов
        public static int DoctorsCount { get; } = 1;

        // Высота карты
        public static int MapRows { get; } = 10;

        // Ширина карты
        public static int MapCols { get; } = 10;

        // Болезнь
        public static Disease Disease { get; } = new ZombieVirus();

        // Задержка между итерациями (миллисекунд)
        public static int DelayMs { get; } = 0;

        // Выводить ли процесс симуляции в консоль
        public static bool Interactive { get; } = false;
    }
}