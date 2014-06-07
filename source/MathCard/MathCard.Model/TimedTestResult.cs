using System;

namespace MathCard.Model
{
    public class TimedTestResult<TCard, TAnswer>
    {
        #region [ Properties ]

        public TAnswer Answer { get; set; }
        public TCard Flashcard { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }

        #endregion
    }
}