using System;

namespace MathCard.Model
{
    public abstract class SimpleMathCard<T> : FlashCard<T>
    {
        #region [ Properties ]

        public virtual T BottomNumber { get; set; }
        public virtual T TopNumber { get; set; }

        #endregion
    }
}