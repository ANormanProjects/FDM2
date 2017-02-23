using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCodeTest.Question5;
using System.Collections.Generic;

namespace CSCodeTest.Tests
{
    [TestClass]
    public class StringSorterTests
    {
        [TestMethod]
        public void Test_AlphabeticalSortLinq_CorrectlySortsString_WhenCalled()
        {
            // Arrange
            StringSorter sorter = new StringSorter();
            string message = "ecfbad";
            string expected = "abcdef";

            // Act
            string result = sorter.AlphabeticalSortLinq(message);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_DistinctAlphabeticalSortLinq_CorrectlySortsStringOfUniqueCharacters_WhenCalled()
        {
            // Arrange
            // Arrange
            StringSorter sorter = new StringSorter();
            string message = "eeecccfbbffabaddde";
            string expected = "abcdef";

            // Act
            string result = sorter.DistinctAlphabeticalSortLinq(message);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_CountCharOccurencesLinq_CorrectlyCountsOccurencesOfEachCharacterInAString_WhenCalled()
        {
            // Arrange
            // Arrange
            StringSorter sorter = new StringSorter();
            string message = "ddfffabb";
            int dExpected = 2, fExpected = 3, aExpected = 1, bExpected = 2;

            // Act
            Dictionary<char, int> dictionaryResult = sorter.CountCharOccurencesLinq(message);

            int aResult, bResult, dResult, fResult;
            dictionaryResult.TryGetValue('a', out aResult);
            dictionaryResult.TryGetValue('b', out bResult);
            dictionaryResult.TryGetValue('d', out dResult);
            dictionaryResult.TryGetValue('f', out fResult);

            // Assert
            Assert.AreEqual(aExpected, aResult);
            Assert.AreEqual(bExpected, bResult);
            Assert.AreEqual(dExpected, dResult);
            Assert.AreEqual(fExpected, fResult);
        }

        [TestMethod]
        public void Test_AlphabeticalSort_CorrectlySortsString_WhenCalled()
        {
            // Arrange
            StringSorter sorter = new StringSorter();
            string message = "ecfbad";
            string expected = "abcdef";

            // Act
            string result = sorter.AlphabeticalSort(message);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_DistinctAlphabeticalSort_CorrectlySortsStringOfUniqueCharacters_WhenCalled()
        {
            // Arrange
            // Arrange
            StringSorter sorter = new StringSorter();
            string message = "eeecccfbbffabaddde";
            string expected = "abcdef";

            // Act
            string result = sorter.DistinctAlphabeticalSort(message);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_CountCharOccurences_CorrectlyCountsOccurencesOfEachCharacterInAString_WhenCalled()
        {
            // Arrange
            // Arrange
            StringSorter sorter = new StringSorter();
            string message = "ddfffabb";
            int dExpected = 2, fExpected = 3, aExpected = 1, bExpected = 2;

            // Act
            Dictionary<char, int> dictionaryResult = sorter.CountCharOccurences(message);

            int aResult, bResult, dResult, fResult;
            dictionaryResult.TryGetValue('a', out aResult);
            dictionaryResult.TryGetValue('b', out bResult);
            dictionaryResult.TryGetValue('d', out dResult);
            dictionaryResult.TryGetValue('f', out fResult);

            // Assert
            Assert.AreEqual(aExpected, aResult);
            Assert.AreEqual(bExpected, bResult);
            Assert.AreEqual(dExpected, dResult);
            Assert.AreEqual(fExpected, fResult);
        }
    }
}
