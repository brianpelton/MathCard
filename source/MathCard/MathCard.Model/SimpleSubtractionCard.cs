namespace MathCard.Model
{
    public class SimpleSubtractionCard : SimpleMathCard<int>
    {
        #region [ Properties ]

        public override int Answer
        {
            get { return TopNumber - BottomNumber; }
            set { }
        }

        #endregion

        #region [ Public Methods ]

        public override string ToString()
        {
            return string.Format("{0} - {1} = {2}",
                TopNumber, BottomNumber, Answer);
        }

        #endregion
    }
}