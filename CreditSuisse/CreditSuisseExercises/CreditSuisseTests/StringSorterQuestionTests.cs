using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditSuisseExercises;
using System.Collections.Generic;

namespace CreditSuisseTests
{
    [TestClass]
    public class StringSorterQuestionTests
    {
        string testWord;
        StringSorterQuestion stringSorter;

        [TestInitialize]
        public void Setup()
        {
            testWord = "kdfjhglksdfjhglkfdhsgkjfhdsgkhjdfg";
            stringSorter = new StringSorterQuestion();
        }

        [TestMethod]
        public void Test_AlphabeticalSort_ReturnsCorrectResult()
        {
            //Arrange
            var expected = "dddddfffffggggghhhhhjjjjkkkkkllsss";

            //Act
            var actual = stringSorter.alphabeticalSort(testWord);
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_DistinctAlphabeticalSort_ReturnsCorrectResult()
        {
            //Arrange
            var expected = "dfghjkls";

            //Act
            var actual = stringSorter.distinctAlphabeticalSort(testWord);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CharacterCount_ReturnsCorrectResult()
        {
            //Arrange
            var expected = new Dictionary<char, int>();

            expected.Add('k', 5);
            expected.Add('d', 5);
            expected.Add('f', 5);
            expected.Add('j', 4);
            expected.Add('h', 5);
            expected.Add('g', 5);
            expected.Add('l', 2);
            expected.Add('s', 3);

            //Act
            var actual = stringSorter.characterCount(testWord);

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_AlphabeticalSortLinq_ReturnsCorrectResult()
        {
            //Arrange
            var expected = "dddddfffffggggghhhhhjjjjkkkkkllsss";

            //Act
            var actual = stringSorter.alphabeticalSortLinq(testWord);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_DistinctAlphabeticalSortLinq_ReturnsCorrectResult()
        {
            //Arrange
            var expected = "dfghjkls";

            //Act
            var actual = stringSorter.distinctAlphabeticalSortLinq(testWord);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CharacterCountLinq_ReturnsCorrectResult()
        {
            //Arrange
            var expected = new Dictionary<char, int>();

            expected.Add('k', 5);
            expected.Add('d', 5);
            expected.Add('f', 5);
            expected.Add('j', 4);
            expected.Add('h', 5);
            expected.Add('g', 5);
            expected.Add('l', 2);
            expected.Add('s', 3);

            //Act
            var actual = stringSorter.characterCountLinq(testWord);

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }
    }
}
