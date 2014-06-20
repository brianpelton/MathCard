using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

// ReSharper disable ConvertToConstant.Local

namespace MathCard.Model.Tests
{
    [TestClass]
    public class DataStoreTests
    {
        #region [ Public Methods ]

        [TestMethod]
        public void Load_Of_Invalid_Data_Should_Throw_Invalid_Operation_Exception()
        {
            Should.Throw<InvalidOperationException>(() =>
                DataStore.Instance.Load("InvalidData.json.txt"));
        }

        [TestMethod]
        public void Load_Of_Simple_Data_Should_Contain_Four_Simple_Addition_Cards()
        {
            // arrange
            var dataSource = "SimpleData.json.txt";

            // act
            DataStore.Instance.Load(dataSource);

            // assert
            DataStore.Instance.Flashcards.Count().ShouldBe(9);
        }

        [TestMethod]
        public void Save_Of_Mixed_Type_Flashcards_Should_Load_Correctly()
        {
            var mixedFlashcards = new List<IFlashCard>
            {
                new SimpleAdditionCard {TopNumber = 1, BottomNumber = 1},
                new SimpleSubtractionCard {TopNumber = 1, BottomNumber = 1}
            };

            DataStore.Instance.Flashcards = mixedFlashcards;

            DataStore.Instance.Save("MixedFlashcards.json.txt");

            DataStore.Instance.Load("MixedFlashcards.json.txt");

            // assert
            DataStore.Instance.Flashcards.Count().ShouldBe(2);
        }

        #endregion
    }
}