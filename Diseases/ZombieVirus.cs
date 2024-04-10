using System.Reflection.Metadata.Ecma335;
using DiseaseModeling.MapElements;

namespace DiseaseModeling.Diseases
{
    class ZombieVirus : Disease
    {
        public override int Contagiousness => 10;

        public override int Duration => 60;

        public override int Mortality => 20;

        public override void DoActivity()
        {
            base.DoActivity();

            foreach (var v in victims)
            {
                Cell c = v.Cell;
                Map map = c.Map;

                foreach (var el in v.Cell)
                {
                    if (el == v) continue;

                    AddInfected(el);
                }

                Dictionary<Direction, Cell?> adjacents = new Dictionary<Direction, Cell?>()
                {
                    { Direction.Left, map.GetAdjacent(c, Direction.Left) },
                    { Direction.Up, map.GetAdjacent(c, Direction.Up) },
                    { Direction.Down, map.GetAdjacent(c, Direction.Down) },
                    { Direction.Right, map.GetAdjacent(c, Direction.Right) }
                };
                
                foreach (var kv in adjacents)
                {
                    Direction direction = kv.Key;
                    Cell? adjCell = kv.Value;

                    if (adjCell == null) continue;

                    foreach (var el in adjCell)
                    {
                        if (infected.ContainsKey(el) || victims.Contains(el))
                            continue;

                        if (el is IMortal)
                        {
                            v.Move(direction);
                            break;
                        }
                    }
                }
            }
        }
    }
}