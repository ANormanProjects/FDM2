using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question5v2;
using System.Collections.Generic;

namespace QuestionsTests
{
    [TestClass]
    public class Question5Tests
    {
        StringSorter sorter;
        StringSorterLINQ sorterLINQ;

        [TestInitialize]
        public void Setup()
        {
            sorter = new StringSorter();
            sorterLINQ = new StringSorterLINQ();
        }

        [TestMethod]
        public void Test_AlphabeticalSortLinq_CorrectSortString_WhenCalled()
        {
            //Arrange
            string message = "ecfbad";
            string expected = "abcdef";

            //Act
            string result = sorterLINQ.AlphabeticalSortLinq(message);

            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_DistinctAlphabeticalSortLinq_CorrectSortString_WhenCalled()
        {
            //Arrange
            string message = "ecfbadd";
            string expected = "abcdef";

            //Act
            string result = sorterLINQ.DistinctAlphabeticalSortLinq(message);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_CountCharOccurencesLinq_CorrectlyCountsOccurencesOfEachCharacterInAString_WhenCalled()
        {
            //Arrange
            string message = "eeecccff";
            int eExpected = 3, cExpected = 3, fExpected = 2;

            //Act
            Dictionary<char, int> dictionaryResult = sorterLINQ.CountCharOccurencesLinq(message);
            int eResult, cResult, fResult;
            dictionaryResult.TryGetValue('e', out eResult);
            dictionaryResult.TryGetValue('c', out cResult);
            dictionaryResult.TryGetValue('f', out fResult);

            //Assert
            Assert.AreEqual(eExpected, eResult);
            Assert.AreEqual(cExpected, cResult);
            Assert.AreEqual(fExpected, fResult);
        }

        [TestMethod]
        public void Test_AlphabeticalSort_CorrectlySortString_WhenCalled()
        {
            //Arrange
            string message = "ecfbad";
            string expected = "abcdef";

            //Act
            string result = sorter.AlphabeticalSort(message);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_DistinctAlphabeticalSort_CorrectlySortString_WhenCalled()
        {
            //Arrange
            string message = "cceeefff";
            string expected = "cef";

            //Act
            string result = sorter.DistinctAlphabeticalSort(message);

            //Assert
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void Test_CountCharOccurences_CorrectlyCountsCharOccurencesInAString_WhenCalled()
        {
            //Arrange
            string message = "eeecccff";
            int eExpected = 3, cExpected = 3, fExpected = 2;

            //Act
            Dictionary<char, int> dictionaryResult = sorter.CountCharOccurences(message);
            int eResult, cResult, fResult;
            dictionaryResult.TryGetValue('e', out eResult);
            dictionaryResult.TryGetValue('c', out cResult);
            dictionaryResult.TryGetValue('f', out fResult);

            //Assert
            Assert.AreEqual(eExpected, eResult);
            Assert.AreEqual(cExpected, eResult);
            Assert.AreEqual(fExpected, fResult);
        }
    }
}
