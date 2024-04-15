namespace DiseaseModeling.MapElements
{
    public class Doctor : Human
    {
        public override void DoAction()
        {
            base.DoAction();

            foreach (var el in Cell)
            {
                if (el is Human human)
                    human.Vaccinate();
            }
        }

        public Doctor(Cell cell) : base(cell)
        {
            syllable = "d";
        }
    }
}