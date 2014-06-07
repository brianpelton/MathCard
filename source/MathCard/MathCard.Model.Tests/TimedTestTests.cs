using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MathCard.Model.Tests
{
    [TestClass]
    public class TimedTestTests
    {
        #region [ Public Methods ]

        [TestMethod]
        public void Cards_Should_Be_In_A_Random_Order()
        {
            var originalList = SimpleAdditionCardFactory.CreateCompleteSet(2, 100, 2, 100);

            var timedTest = new TimedTest<SimpleAdditionCard, int>
            {
                FlashCards = originalList
            };

            timedTest.PrepareTest();

            var randomlyOrderedCards = timedTest.PreparedCards;

            for (int i = 1; i < originalList.Count - 1; i++)
            {
                var previous = randomlyOrderedCards[i - 1].Equals(originalList[i - 1]);
                var current = randomlyOrderedCards[i].Equals(originalList[i]);
                var next = randomlyOrderedCards[i + 1].Equals(originalList[i + 1]);

                (previous && current && next).ShouldBe(false);
            }
        }

        [TestMethod]
        public void Moving_To_Next_Card_Should_Set_Time_For_Previous_Card()
        {
            var test = GetTimedTest();
            test.PrepareTest();

            test.GetNextCard();
            test.FlashCardResults[0].StartTime.Date.ShouldBe(DateTime.Today);
            test.FlashCardResults[0].StopTime.ShouldBe(DateTime.MinValue);
            test.Answer(1);
            test.FlashCardResults[0].StopTime.Date.ShouldBe(DateTime.Today);
        }

        [TestMethod]
        public void Test_Should_Throw_Exception_If_Attempt_To_Get_Next_Card_After_Last_Card()
        {
            var test = GetTimedTest();
            test.PrepareTest();

            for (int i = 0; i < test.FlashCards.Count; i++)
            {
                test.GetNextCard();
            }

            Should.Throw<ArgumentOutOfRangeException>(() => test.GetNextCard());
        }

        [TestMethod]
        public void Test_Should_Throw_Exception_If_Attempt_To_Get_Next_Card_Without_Preparing_Test()
        {
            var test = GetTimedTest();

            Should.Throw<InvalidOperationException>(() => test.GetNextCard());
        }


        [TestMethod]
        public void Test_Should_Track_Right_And_Wrong_Answers()
        {
            var timedTest = GetTimedTest();

            timedTest.PrepareTest();

            timedTest.GetNextCard();
            timedTest.Answer(-1);
            timedTest.NumberOfIncorrectAnswers.ShouldBe(1);
            timedTest.NumberOfCorrectAnswers.ShouldBe(0);

            var card = timedTest.GetNextCard();
            timedTest.Answer(card.Answer);
            timedTest.NumberOfIncorrectAnswers.ShouldBe(1);
            timedTest.NumberOfCorrectAnswers.ShouldBe(1);
        }

        #endregion

        #region [ Methods ]

        private TimedTest<SimpleAdditionCard, int> GetTimedTest()
        {
            return new TimedTest<SimpleAdditionCard, int>
            {
                FlashCards = SimpleAdditionCardFactory.CreateCompleteSet(2, 10, 2, 10)
            };
        }

        #endregion
    }
}