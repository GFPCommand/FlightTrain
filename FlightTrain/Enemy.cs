namespace FlightTrain
{
	public class Enemy : Button
	{
		public int HorizontalTransition;
		public int VerticalTransition;

        public Enemy()
        {
            Visible = false;

            BackColor = Color.Red;

            Size = new(40, 40);
        }
    }
}