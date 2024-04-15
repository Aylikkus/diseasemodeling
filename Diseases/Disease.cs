using DiseaseModeling.MapElements;

namespace DiseaseModeling.Diseases
{
    public abstract class Disease
    {
        /// <summary>
        /// Заразность
        /// </summary>
        public abstract int Contagiousness { get; }

        /// <summary>
        /// Продолжительность
        /// </summary>
        public abstract int Duration { get; }

        /// <summary>
        /// Смертность
        /// </summary>
        public abstract int Mortality { get; }

        /// <summary>
        /// Название на русском
        /// </summary>
        public abstract string RussianName { get; }

        protected Dictionary<MapElement, int> infected = new Dictionary<MapElement, int>();
        protected HashSet<MapElement> victims = new HashSet<MapElement>();

        /// <summary>
        /// Делает "бросок кубика", результат
        /// с процента от 0 до 100;
        /// </summary>
        protected bool roll(int percent)
        {
            percent = percent > 100 ? 100 : percent;
            percent = percent < 0 ? 0 : percent;

            Random rand = new Random();
            int roll = rand.Next(1, 101);

            return roll <= percent;
        }

        /// <summary>
        /// Количество заразившихся данной болезнью
        /// </summary>
        public int InfectedCount
        {
            get
            {
                return infected.Count;
            }
        }

        /// <summary>
        /// Количество умерших от данной болезни
        /// </summary>
        public int VictimsCount
        {
            get
            {
                return victims.Count;
            }
        }

        /// <summary>
        /// Добавить (заразить) объект
        /// </summary>
        public bool AddInfected(MapElement element)
        {
            // Заразить вакцинированного сложнее
            if (element is Human human && human.Vaccinated)
            {
                Random rand = new Random();

                if (rand.Next(0, 2) == 0)
                    return false;
            }

            if (infected.ContainsKey(element) == false)
            {
                infected[element] = 0;
                element.AddModifier("i");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Убрать (вылечить) инфицируемый объект
        /// </summary>
        public void RemoveInfected(MapElement element)
        {
            // Убираем инфицируемого из списка 
            // и убираем модификатор
            infected.Remove(element);
            element.RemoveModifier("i");
        }

        /// <summary>
        /// Выполнить какую-то активность, характерную для болезни
        /// </summary>
        public virtual void DoActivity()
        {
            // Проходимся по каждому инфицированному
            foreach (var kv in infected.ToDictionary())
            {
                MapElement element = kv.Key;

                // Увеличиваем возраст болезни
                int timeOfLife = ++infected[element];

                // Если истёк срок жизни болезни
                if (timeOfLife > Duration)
                {
                    RemoveInfected(element);
                    continue;
                }

                // Попытка убить инфицируемого
                if (element is IMortal mortal && 
                    mortal.IsDead == false)
                {
                    if (roll(Mortality))
                    {
                        mortal.Kill();
                        victims.Add(element);
                    }
                }

                Cell? c = element.Cell;

                if (c is not null)
                {
                    Map map = c.Map;

                    // Заражение клетки, в которой стоит элемент
                    foreach (var cellElem in c)
                    {
                        if (roll(Contagiousness))
                            AddInfected(cellElem);
                    }

                    // Заражение соседних клеток с элементом
                    Cell?[] adjacents =
                    [
                        map.GetAdjacent(c, Direction.Left),
                        map.GetAdjacent(c, Direction.Up),
                        map.GetAdjacent(c, Direction.Down),
                        map.GetAdjacent(c, Direction.Right),
                    ];

                    foreach (var adjCell in adjacents)
                    {
                        if (adjCell is not null)
                            foreach (var cellElem in adjCell)
                            {
                                if (roll(Contagiousness / 4))
                                    AddInfected(cellElem);
                            }
                    }
                }
            }
        }

        public override string ToString()
        {
            return RussianName;
        }
    }
}