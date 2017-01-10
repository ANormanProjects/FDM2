using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mocking.Bookshop;
using Moq;

namespace Mocking.Test
{
    [TestClass]
    public class StockCheckerTests
    {
        [TestMethod]    //TESTING WHAT NumberInStock does
        public void Test_NumberInStock_CallsTheReadQuantityMethodOfOurDatabaseReader_WhenCalled()
        {
                // The NumberInStock method of the StockChecker object should make a call to 
                //  the ReadQuantity method of a DatabaseReader object once when called.

            //ARRANGE

                //DatabaseReader databaseReader = new DatabaseReader();       
                //TEST IS NOT INDEPENDENT ANYMORE AS DATABASEREADER REQUIRES CONNECTION TO DATABASE TO WORK.
                // IT IS BEST IF THE TEST CHECKS ONE THING A THE TIME - STOCKCHECKER FIRST, DATABASE READER NEXT.

            Mock<IDatabaseReader> mockDatabaseReader = new Mock<IDatabaseReader>(); //Right click Mock to add a using Moq; statement to fix.
                // THIS IS USED IN PLACE OF DatabaseReader as a fake Databasereader (ALWAYS MOCK ABSTRACT CLASS OR INTERFACE)
                // NEED TO TELL STOCKCHECKER TO USE MOCKDATABASEREADER USING DEPENDENCY INJECTOR.
                //DEPENDENCY INJECTOR, GIVING A CLASS EVERYTHING IT NEEDS WHEN ITS BORN OR CONSTRUCTED.

            string isbn = "ABC123";

                // GENERAL RULE OF THUMB, ONLY HAVE ONE REAL OBJECT IN EACH TEST.
            StockChecker stockChecker = new StockChecker(mockDatabaseReader.Object);     //WITH TWO CLASSES THE TEST IS NO LONGER FOCUSED
            
            //ACT
            stockChecker.NumberInStock(isbn); //RUN the NumInStock method


            //ASSERT
                //DatabaseReader class/object     //ReadQuantity method of databaseReader
            mockDatabaseReader.Verify(r => r.ReadQuantity(It.IsAny<string>()), Times.Once);
            //MOQ's Verify method (instead of MSTEST Assert)   //MATCHER, parameter can change to int or other types
            
                //databaseReader will verify that ReadQuantity was called. r => r will read each other.
                //Expect the ReadQuantity to run as well.

            //TEST will fail first, because ReadQuantity was not called once but zero times. (INVOCATION)

            //THIS TEST IS GOOD AS IT ALLOWS US TO TEST IF SOMETHING ELSE IS HAPPENING AS A RESULT OF THE TEST.

        }

        [TestMethod]

        public void Test_ReadQuantity_ToEnsureTheReadQuantityMethodOf_HasReceivedTheCorrectISBNNumberFromNumberInStock()
        {
            //ARRANGE
            Mock<IDatabaseReader> mockDatabaseReader = new Mock<IDatabaseReader>();

            StockChecker stockChecker = new StockChecker(mockDatabaseReader.Object);

            string isbn = "ABC123";

            //ACT
            stockChecker.NumberInStock(isbn);

            //ASSERT
            mockDatabaseReader.Verify(r => r.ReadQuantity(isbn), Times.Once);

        }

        [TestMethod]

        public void Test_ReadQuantityHasISBN_NumberInStockReturnsThree_WhenThreeCopiesExistInDatabase()
        {
            //ARRANGE
            Mock<IDatabaseReader> mockDatabaseReader = new Mock<IDatabaseReader>();

            StockChecker stockChecker = new StockChecker(mockDatabaseReader.Object);  
            //DEPENDENCY INJECTOR (mockDatabaseReader.Object)

            string isbn = "ABC123";

            int expected = 3;

            // BEFORE ENTERING THE FOLLOWING, CHECK TO SEE IF IT FAILS FIRST
            // USING METHOD STUBBING
            //mockDatabaseReader.Setup(r => r.ReadQuantity(It.IsAny<string>())).Returns(3); 

            mockDatabaseReader.Setup(r => r.ReadQuantity(isbn)).Returns(3);
            //TESTING int stock = _databaseReader.ReadQuantity   and setup 3 isbns
            // THIS OVERRIDES THE METHOD IN IDATABASEREADER "public int ReadQuantity(string isbn)"
            // STUBBING IGNORES THAT METHOD AND JUST TELLS THE READQUANTITY TO RETURN 3

            //ACT
            int actual = stockChecker.NumberInStock(isbn);

            //ASSERT
            Assert.AreEqual(expected, actual); //EXPECTED WILL EQUAL ACTUAL. USED THE MOCK.SETUP TO CREATE 3 INSTANCES OF THE ISBN


        }
    }
}
