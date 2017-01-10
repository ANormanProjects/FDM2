using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LAMBDAandDELEGATESpart1;

namespace Part1Tests
{
    [TestClass]
    public class UnitTest1
    {
        CDDatabase cdDB;
        CD testCd;
        CD testCd2;
        CD testCd3;
        CD testCd4;
        CD testCd5;
        CD testCd6;
        CD testCd7;
        CD testCd8;
        CD testCd9;
        CD testCd10;
        
        [TestInitialize]
        public void Setup()
        {
            cdDB = new CDDatabase();
            testCd = new CD("Album 1", "TranceDJ1", 30, 6);
            testCd2 = new CD("Album 2", "TranceDJ2", 40, 9);
            testCd3 = new CD("Album 3", "TranceDJ3", 50, 8);
            testCd4 = new CD("Album 4", "TranceDJ4", 60, 7);
            testCd5 = new CD("Album 5", "TranceDJ5", 70, 14);
            testCd6 = new CD("Album 6", "TranceDJ6", 80, 15);
            testCd7 = new CD("Album 7", "TranceDJ7", 90, 16);
            testCd8 = new CD("Album 8", "TranceDJ8", 100, 17);
            testCd9 = new CD("Album 9", "TranceDJ9", 110, 18);
            testCd10 = new CD("Album 10", "TranceDJ10", 120, 19);
        }

        [TestMethod]  //TEST 1
        public void Test_getCDsInList_ReturnsValueOfZero_WhenCheckingEmptyCDDatabase()
        {
            //ARRANGE

            List<CD> expected = new List<CD>();

            //ACT
            List<CD> actual = cdDB.getCDsInList();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod] //TEST 2
        public void Test_SearchByTitle_ReturnsValueOf1CDs_WhenCheckingTheCDList()
        {
            //ARRANGE

            cdDB.CDlist.Add(testCd);

            List<CD> expected = new List<CD>()
            {
                testCd,
            };

            //ACT
            
            List<CD> actual = cdDB.SearchByTitle("Album 1");
            

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod] //TEST 3
        public void Test_longerThanOneHour_ReturnsAllCDsInTheList_ThatAreLongerThan60Mins()
        {
            //ARRANGE
            cdDB.CDlist.Add(testCd5);
            cdDB.CDlist.Add(testCd6);
            cdDB.CDlist.Add(testCd7);
            cdDB.CDlist.Add(testCd8);
            cdDB.CDlist.Add(testCd9);
            cdDB.CDlist.Add(testCd10);

            List<CD> expected = new List<CD>()
            {
                testCd4, testCd5, testCd6, testCd7, testCd8, testCd9, testCd10
            };

            //ACT

            List<CD> actual = cdDB.longerThanOneHour(60);

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
