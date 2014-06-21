using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MathCard.Model.Tests
{
    [TestClass]
    public class WhichIsSmallerCardTests
    {
        #region [ Public Methods ]

        [TestMethod]
        public void Simple_Test()
        {
            // arrange
            var card = new WhichIsSmallerCard<SimpleAdditionCard, int>
            {
                LeftCard = new SimpleAdditionCard
                {
                    TopNumber = 2,
                    BottomNumber = 2
                },
                RightCard = new SimpleAdditionCard
                {
                    TopNumber = 4,
                    BottomNumber = 4
                }
            };

            // assert
            card.Answer.ShouldBe(4);
        }

        #endregion
    }
}