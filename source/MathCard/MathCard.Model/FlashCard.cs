using System;

namespace MathCard.Model
{
    public interface IFlashCard
    {
    }

    public class FlashCard<T> : IFlashCard
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