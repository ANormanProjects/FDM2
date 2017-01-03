using Microsoft.VisualStudio.TestTools.UnitTesting;
using LambdasExcercise;
using System.Collections.Generic;
using System.Linq;

namespace LambdasExercise.Tests
{
    [TestClass]
    public class CdStockTests
    {
        CdStock cdStock;

        [TestInitialize]
        public void Setup()
        {
            cdStock = new CdStock();
            cdStock.cds.Add(new Cd("k", "a", 1, 1));
            cdStock.cds.Add(new Cd("l", "b", 5, 3));
            cdStock.cds.Add(new Cd("m", "c", 10, 5));
            cdStock.cds.Add(new Cd("n", "d", 20, 7));
            cdStock.cds.Add(new Cd("o", "e", 25, 9));
            cdStock.cds.Add(new Cd("p", "f", 30, 11));
            cdStock.cds.Add(new Cd("q", "g", 40, 13));
            cdStock.cds.Add(new Cd("r", "h", 50, 15));
            cdStock.cds.Add(new Cd("t", "i", 60, 17));
            cdStock.cds.Add(new Cd("s", "j", 70, 19));
        }

        [TestMethod]
        public void Test_SearchByTitle_ReturnsSearchedForCd()
        {
            //Arrange
            List<Cd> expected = new List<Cd>();
            expected.Add(cdStock.cds[4]);

            //Act
            List<Cd> actual = cdStock.SearchByTitle("o").ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SearchForLengthOfMoreThan60_ReturnsAllCdsWithALengthOfMoreThan60()
        {
            //Arrange
            List<Cd> expected = new List<Cd>();
            expected.Add(cdStock.cds[9]);

            //Act
            List<Cd> actual = cdStock.SearchForLengthOfMoreThan60().ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SearchForTracksOflessThan10_ReturnsAllCdsWithLessThan10Tracks()
        {
            //Arrange
            List<Cd> expected = new List<Cd>();
            expected.Add(cdStock.cds[0]);
            expected.Add(cdStock.cds[1]);
            expected.Add(cdStock.cds[2]);
            expected.Add(cdStock.cds[3]);
            expected.Add(cdStock.cds[4]);

            //Act
            List<Cd> actual = cdStock.SearchForTracksOfLessThan10().ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_OrderByTitle_ReturnsAllCdsInAlphabeticalOrder()
        {
            //Arrange
            List<Cd> expected = new List<Cd>();
            expected.Add(cdStock.cds[0]);
            expected.Add(cdStock.cds[1]);
            expected.Add(cdStock.cds[2]);
            expected.Add(cdStock.cds[3]);
            expected.Add(cdStock.cds[4]);
            expected.Add(cdStock.cds[5]);
            expected.Add(cdStock.cds[6]);
            expected.Add(cdStock.cds[7]);
            expected.Add(cdStock.cds[9]);
            expected.Add(cdStock.cds[8]);

            //Act
            List<Cd> actual = cdStock.OrderByTitle().ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CheckIfArtistExists_ReturnsFalseIfArtistDoesntExist()
        {
            //Arrange
            bool expected = false;

            //Act
            bool actual = cdStock.CheckIfArtistExists("I Dont Exist");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CheckIfArtistExists_ReturnsTrueIfArtistDoesExist()
        {
            //Arrange
            bool expected = true;

            //Act
            bool actual = cdStock.CheckIfArtistExists("a");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
