using DiseaseModeling.Diseases;

namespace DiseaseModeling
{
    public class Human : MapElement
    {
        protected void doMove()
        {
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

        public Human(Cell cell) : base(cell)
        {
            syllable = "h";
        }
    }
}