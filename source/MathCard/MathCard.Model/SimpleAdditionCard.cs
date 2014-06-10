namespace MathCard.Model
{
    public class SimpleAdditionCard : SimpleMathCard<int>
    {
        #region [ Properties ]

        public override int Answer
        {
            get { return TopNumber + BottomNumber; }
            set { }
        }

        #endregion

        #region [ Public Methods ]

        public override string Prompt
        {
            get
            {
                return string.Format("{0} + {1} = ?",
                    TopNumber, BottomNumber);
            }
        }

        public override string ToString()
        {
            return Prompt;
        }

        #endregion
    }
}