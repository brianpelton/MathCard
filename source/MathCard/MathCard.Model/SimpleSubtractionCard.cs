using Newtonsoft.Json;

namespace MathCard.Model
{
    public class SimpleSubtractionCard : SimpleMathCard<int>
    {
        #region [ Properties ]

        [JsonIgnore]
        public override int Answer
        {
            get { return TopNumber - BottomNumber; }
            set { }
        }

        [JsonIgnore]
        public override string Prompt
        {
            get
            {
                return string.Format("{0} - {1} = ?",
                    TopNumber, BottomNumber);
            }
        }

        #endregion

        #region [ Public Methods ]

        public override string ToString()
        {
            return Prompt;
        }

        #endregion
    }
}