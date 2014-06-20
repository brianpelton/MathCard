using System;
using System.Collections.Generic;
using System.Linq;
using MathCard.Model;

namespace MathCard.ConsoleApp
{
    internal class Program
    {
        #region [ Methods ]

        private static void Main(string[] args)
        {
            var flashcards = SimpleAdditionCardFactory.CreateCompleteSet(1, 1, 1, 9);

            DataStore.Instance.Flashcards = flashcards;
            DataStore.Instance.Save("SimpleData.json.txt");

            var test = new TimedTest<SimpleAdditionCard, int>
            {
                FlashCards = SimpleAdditionCardFactory.CreateCompleteSet(2, 10, 5, 12)
            };

            test.PrepareTest();

            for (int i = 0; i < test.FlashCards.Count; i++)
            {
                var card = test.GetNextCard();
                Console.WriteLine(card.Prompt);


                var validNumber = false;
                int number = -1;
                while (!validNumber)
                {
                    var input = Console.ReadLine();
                    validNumber = int.TryParse(input, out number);
                }

                test.Answer(number);
            }


            Console.WriteLine("You missed: {0}", test.NumberOfIncorrectAnswers);
            Console.WriteLine();

            var wrongAnswers = (from x in test.FlashCardResults
                                where !x.IsCorrect
                                select x).ToList();

            foreach (var wrongAnswer in wrongAnswers)
            {
                Console.WriteLine(wrongAnswer.Flashcard.Prompt);
                Console.WriteLine("Your Answer:      {0}", wrongAnswer.Answer);
                Console.WriteLine("Correct Answer:   {0}", wrongAnswer.Flashcard.Answer);
                Console.WriteLine();
            }

            var averageRightAnswerTimeTicks = (from x in test.FlashCardResults
                                               where x.IsCorrect
                                               select x.Seconds).Average();

            var averageRightAnswerTime = TimeSpan.FromSeconds(averageRightAnswerTimeTicks);

            Console.WriteLine("Average Answer Time: {0}", averageRightAnswerTime);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }

        #endregion
    }
}