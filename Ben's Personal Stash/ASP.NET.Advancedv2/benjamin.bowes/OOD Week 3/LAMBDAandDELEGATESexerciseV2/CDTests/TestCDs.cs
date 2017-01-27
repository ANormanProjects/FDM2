using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LAMBDAandDELEGATESexerciseV2;
using System.Linq;

namespace CDTests
{
    [TestClass]
    public class UnitTest1
    {
        CDDatabase cdDB;

        [TestInitialize]
        public void Setup()
        {
            cdDB = new CDDatabase();
            cdDB.cdList.Add(new CD("A", "DJ1", 5, 1));     //Index 0 (0-9)
            cdDB.cdList.Add(new CD("B", "DJ2", 10, 2));
            cdDB.cdList.Add(new CD("C", "DJ3", 15, 3));
            cdDB.cdList.Add(new CD("D", "DJ4", 20, 4));
            cdDB.cdList.Add(new CD("E", "DJ5", 25, 5));
            cdDB.cdList.Add(new CD("F", "DJ6", 50, 10));   //Index 5
            cdDB.cdList.Add(new CD("G", "DJ7", 55, 11));
            cdDB.cdList.Add(new CD("H", "DJ8", 60, 12));
            cdDB.cdList.Add(new CD("K", "DJ9", 65, 13));
            cdDB.cdList.Add(new CD("I", "DJ10", 70, 14)); //Index 9 (0-9)
        }

        [TestMethod]
        public void Test_SearchByTitle_ReturnSearchedForCD()
        {
            //ARRANGE
            List<CD> expected = new List<CD>();
            expected.Add(cdDB.cdList[5]);

            //ACT
            List<CD> actual = cdDB.SearchByTitle("F").ToList();        //ToList requires system.LINQ

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SearchForMinsMoreThan60_ReturnsAllCDsWithALengthOfMoreThan60()
        {
            //ARRANGE
            List<CD> expected = new List<CD>();
            expected.Add(cdDB.cdList[8]);
            expected.Add(cdDB.cdList[9]);

            //ACT
            List<CD> actual = cdDB.SearchForMinsMoreThan60().ToList();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SearchForLessThan10Tracks_ReturnsAllCDsWithLessThan10Tracks()
        {
            //ARRANGE
            List<CD> expected = new List<CD>();
            expected.Add(cdDB.cdList[0]);
            expected.Add(cdDB.cdList[1]);
            expected.Add(cdDB.cdList[2]);
            expected.Add(cdDB.cdList[3]);
            expected.Add(cdDB.cdList[4]);

            //ACT
            List<CD> actual = cdDB.SearchForLessThan10Tracks().ToList();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_OrderByTitle_ReturnsAllCDsInAlphabeticalOrder()
        {
            //ARRANGE
            List<CD> expected = new List<CD>();

            expected.Add(cdDB.cdList[0]);
            expected.Add(cdDB.cdList[1]);
            expected.Add(cdDB.cdList[2]);
            expected.Add(cdDB.cdList[3]);
            expected.Add(cdDB.cdList[4]);
            expected.Add(cdDB.cdList[5]);
            expected.Add(cdDB.cdList[6]);
            expected.Add(cdDB.cdList[7]);
            expected.Add(cdDB.cdList[9]);
            expected.Add(cdDB.cdList[8]);

            //ACT
            List<CD> actual = cdDB.OrderByTitle().ToList();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CheckIfArtistExists_ReturnFalseIfArtistDoesNotExist()
        {
            //ARRANGE
            bool expected = false;

            //ACT
            bool actual = cdDB.CheckIfArtistExists("No Artist");

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CheckIfArtistExists_ReturnTrueIfArtistDoesExist()
        {
            //ARRANGE
            bool expected = true;

            //ACT
            bool actual = cdDB.CheckIfArtistExists("DJ1");

            //ASSERT
            Assert.AreEqual(expected, actual);
        }
    }
}
