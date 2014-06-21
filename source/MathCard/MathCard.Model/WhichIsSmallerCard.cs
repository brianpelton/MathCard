using System;

namespace MathCard.Model
{
    public class WhichIsSmallerCard<TCard, TAnswer> : FlashCard<TAnswer>
        where TCard : FlashCard<TAnswer>
        where TAnswer : IComparable<TAnswer>
    {
        #region [ Properties ]

        public override TAnswer Answer
        {
            get
            {
                var leftAnswer = LeftCard.Answer;
                var rightAnswer = RightCard.Answer;

                if (leftAnswer.CompareTo(rightAnswer) < 0)
                    return leftAnswer;
                return rightAnswer;
            }
        }

        public TCard LeftCard { get; set; }
        public TCard RightCard { get; set; }

        #endregion
    }
}