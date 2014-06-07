using System;
using System.Collections.Generic;

namespace MathCard.Model
{
    public static class SimpleAdditionCardFactory
    {
        #region [ Public Methods ]

        public static IList<SimpleAdditionCard> CreateCompleteSet(int topStaringNumber, int topEndingNumber,
            int bottomStartingNumber, int bottomEndingNumber)
        {
            var list = new List<SimpleAdditionCard>();

            for (int i = topStaringNumber; i < topEndingNumber; i++)
                for (int j = bottomStartingNumber; j < bottomEndingNumber; j++)
                {
                    list.Add(new SimpleAdditionCard
                    {
                        TopNumber = i,
                        BottomNumber = j
                    });
                }

            if (list.Count == 0)
                throw new InvalidOperationException("No flashcards created.");

            return list;
        }

        #endregion
    }
}