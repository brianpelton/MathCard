using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MathCard.Model.Tests
{
    [TestClass]
    public class SimpleSubtractionCardTests
    {
        #region [ Public Methods ]

        [TestMethod]
        public void Four_Minus_Two_Should_Be_Two()
        {
            var card = new SimpleSubtractionCard
            {
                TopNumber = 4,
                BottomNumber = 2
            };
            card.CheckAnswer(2).ShouldBe(true);
            card.CheckAnswer(4).ShouldBe(false);
        }

        #endregion
    }
}