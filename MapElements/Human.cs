using DiseaseModeling.Diseases;

namespace DiseaseModeling.MapElements
{
    public class Human : MapElement, IMortal
    {
        public bool IsDead { get; private set; }
        public bool Vaccinated { get; private set; }

        public void Vaccinate()
        {
            Random rand = new Random();

            // Человек может не захотеть вакцинироваться
            if (Vaccinated == false && rand.Next(0, 2) == 0)
            {
                Vaccinated = true;
                AddModifier("v");
            }
        }

        private void doMove()
        {
            if (IsDead) return;

            Random random = new Random();

            int roll = random.Next(0, 10);
            bool moveRes = true;

            switch (roll)
            {
                case 1:
                    moveRes = Move(Direction.Left);
                    break;
                case 2:
                    moveRes = Move(Direction.Right);
                    break;
                case 3:
                    moveRes = Move(Direction.Up);
                    break;
                case 4:
                    moveRes = Move(Direction.Down);
                    break;
                default:
                    break;
            }

            if (moveRes == false) doMove();
        }

        public override void DoAction()
        {
            doMove();
        }

        public bool Kill()
        {
            IsDead = true;
            AddModifier("d");
            return true;
        }

        public Human(Cell cell) : base(cell)
        {
            syllable = "h";
            IsDead = false;
        }
    }
}