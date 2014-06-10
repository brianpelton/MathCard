using System;
using System.Collections.Generic;
using System.Linq;

namespace MathCard.Model
{
    public class TimedTest<TCard, TAnswer>
        where TCard : FlashCard<TAnswer>
    {
        #region [ Properties ]

        public TCard CurrentCard
        {
            get { return PreparedCards[CurrentCardIndex]; }
        }

        public int CurrentCardIndex { get; protected set; }

        private TimedTestResult<TCard, TAnswer> CurrentResult
        {
            get { return FlashCardResults[CurrentCardIndex]; }
        }

        public List<TimedTestResult<TCard, TAnswer>> FlashCardResults { get; set; }
        public IList<TCard> FlashCards { get; set; }

        public int NumberOfCorrectAnswers
        {
            get
            {
                return (from r in FlashCardResults
                    where r.IsCorrect
                    select 1).Sum();
            }
        }

        public int NumberOfIncorrectAnswers
        {
            get
            {
                return (from r in FlashCardResults
                    where !r.IsCorrect
                    select 1).Sum();
            }
        }

        public List<TCard> PreparedCards { get; set; }

        public IList<TCard> WrongCards
        {
            get
            {
                return (from r in FlashCardResults
                    where !r.IsCorrect
                    select r.Flashcard).ToList();
            }
        }

        #endregion

        #region [ Public Methods ]

        public bool Answer(TAnswer answer)
        {
            // stop the timer
            // check the answer
            // store the correctness and time with the flashcard for the user.

            CurrentResult.StopTime = DateTime.Now;
            CurrentResult.Answer = answer;
            CurrentResult.IsCorrect = CurrentCard.CheckAnswer(answer);
            return CurrentResult.IsCorrect;
        }

        public TCard GetNextCard()
        {
            if (PreparedCards == null)
                throw new InvalidOperationException("You must prepare the test before attempting to get the next card");

            //if (CurrentCardIndex > PreparedCards.Count)
            //    throw new ove

            // get the next card in the random order list
            // start a timer

            CurrentCardIndex++;

            var result = new TimedTestResult<TCard, TAnswer>
            {
                Flashcard = CurrentCard,
                StartTime = DateTime.Now
            };

            FlashCardResults.Add(result);

            return CurrentCard;
        }

        public void PrepareTest()
        {
            // create copy of flashcards in a random order

            PreparedCards = FlashCards.OrderBy(g => Guid.NewGuid()).ToList();
            FlashCardResults = new List<TimedTestResult<TCard, TAnswer>>();
            CurrentCardIndex = -1;
        }

        #endregion
    }
}