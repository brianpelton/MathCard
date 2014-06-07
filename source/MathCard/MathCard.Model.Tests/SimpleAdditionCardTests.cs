using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MathCard.Model.Tests
{
    [TestClass]
    public class SimpleAdditionCardTests
    {
        #region [ Public Methods ]

        [TestMethod]
        public void Two_Plus_Two_Should_Be_Four()
        {
            var card = new SimpleAdditionCard
            {
                TopNumber = 2,
                BottomNumber = 2
            };
            card.CheckAnswer(4).ShouldBe(true);
            card.CheckAnswer(5).ShouldBe(false);
        }

        #endregion
    }
}