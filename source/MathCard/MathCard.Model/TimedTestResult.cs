using System;

namespace MathCard.Model
{
    public class TimedTestResult<TCard, TAnswer>
    {
        #region [ Properties ]

        public TAnswer Answer { get; set; }
        public TCard Flashcard { get; set; }
        public bool IsCorrect { get; set; }

        public double Seconds
        {
            get
            {
                if (StartTime == DateTime.MinValue ||
                    StopTime == DateTime.MinValue)
                    return 0;

                return (StopTime - StartTime).TotalSeconds;
            }
        }

        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }

        #endregion
    }
}