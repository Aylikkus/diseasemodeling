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

        private Dictionary<MapElement, int> infected = new Dictionary<MapElement, int>();

        public int InfectedCount
        {
            get
            {
                return infected.Count;
            }
        }

        public bool AddInfected(MapElement element)
        {
            if (infected.ContainsKey(element) == false)
            {
                infected[element] = 0;
                element.Syllable = "i:" + element.Syllable;
                return true;
            }

            return false;
        }

        public void RemoveInfected(MapElement element)
        {
            infected.Remove(element);
            element.Syllable = element.Syllable.Replace("i:", "");
        }

        public void DoActivity()
        {
            Random random = new Random();

            foreach (var kv in infected.ToDictionary())
            {
                MapElement element = kv.Key;
                int timeOfLife = kv.Value;

                infected[element]++;

                if (timeOfLife > Duration)
                {
                    RemoveInfected(element);
                    continue;
                }

                if (Contagiousness == 0)
                    continue;

                Cell? c = element.Cell;

                if (c is not null)
                {
                    Map map = c.Map;

                    foreach (var cellElem in c)
                    {
                        int roll = random.Next(0, 25);
                        if (roll * 100 / Contagiousness < Contagiousness % 100)
                            AddInfected(cellElem);
                    }

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
                                int roll = random.Next(0, 4);
                                if (roll * 100 / Contagiousness < Contagiousness % 100)
                                    AddInfected(cellElem);
                            }
                    }
                }
            }
        }
    }
}