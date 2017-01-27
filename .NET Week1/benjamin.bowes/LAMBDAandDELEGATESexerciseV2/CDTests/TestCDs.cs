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
            cdDB.cdList.Add(new CD("A1", "DJ1", 5, 1));     //Index 0 (0-9)
            cdDB.cdList.Add(new CD("A2", "DJ2", 10, 2));
            cdDB.cdList.Add(new CD("A3", "DJ3", 15, 3));
            cdDB.cdList.Add(new CD("A4", "DJ4", 20, 4));
            cdDB.cdList.Add(new CD("A5", "DJ5", 25, 5));
            cdDB.cdList.Add(new CD("A6", "DJ6", 50, 10));   //Index 5
            cdDB.cdList.Add(new CD("A7", "DJ7", 55, 11));
            cdDB.cdList.Add(new CD("A8", "DJ8", 60, 12));
            cdDB.cdList.Add(new CD("A9", "DJ9", 65, 13));
            cdDB.cdList.Add(new CD("A10", "DJ10", 70, 14)); //Index 9 (0-9)
        }

        [TestMethod]
        public void Test_SearchByTitle_ReturnSearchedForCD()
        {
            //ARRANGE
            List<CD> expected = new List<CD>();
            expected.Add(cdDB.cdList[5]);

            //ACT
            List<CD> actual = cdDB.SearchByTitle("A6").ToList();        //ToList requires system.LINQ

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
        public void Test_OrderListByTitle_ReturnsListOfCDsOrderedByTitle()
        {
            //ARRANGE


            //ACT

            //ASSERT

        }
    }
}
