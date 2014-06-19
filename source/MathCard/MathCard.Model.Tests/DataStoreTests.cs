using System;
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
        public void Load_Of_Sample_Data_Should_Contain_Four_Simple_Addition_Cards()
        {
            // arrange
            var dataSource = "SimpleData.json.txt";

            // act
            DataStore.Instance.Load(dataSource);

            // assert
            DataStore.Instance.Flashcards.Count.ShouldBe(9);
        }

        #endregion
    }
}