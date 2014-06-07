using System;

namespace MathCard.Model
{
    public class FlashCard<T>
    {
        #region [ Properties ]

        public virtual T Answer { get; set; }
        public virtual string Prompt { get; set; }

        #endregion

        #region [ Public Methods ]

        public virtual bool CheckAnswer(T answer)
        {
            return Answer.Equals(answer);
        }

        #endregion
    }
}