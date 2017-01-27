using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore;
using System.Collections.Generic;
using Moq;

namespace BookStoreMock
{
    [TestClass]
    public class MockTests
    {
        [TestMethod] // TEST 1
        public void Test_GetAllBooks_ReturnsEmptyBookList_IfNoBooksAreInTheCatalogue()
        {
            //ARRANGE
            Mock<DatabaseReader> mockdatabasereader = new Mock<DatabaseReader>(); //MOVE HERE FOR TEST 2

            List<Book> expected = new List<Book>();
            Catalogue catalogue = new Catalogue(mockdatabasereader.Object); //MOVE HERE FOR TEST 2

            //ACT
            List<Book> actual = catalogue.GetAllBooks();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual); //CollectionAssert is USED FOR COMPARING LISTS

        }

        [TestMethod] // TEST 2
        public void test_GetAllBooks_CallsReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE
            Mock<DatabaseReader> mockdatabasereader = new Mock<DatabaseReader>(); //FAKE OBJECT

            mockdatabasereader.Setup(r => r.ReadDatabase());

            List<Book> expected = new List<Book>();

            Catalogue catalogue = new Catalogue(mockdatabasereader.Object); // REAL OBJECT //INJECT MOCK OBJECT INTO REAL

            //mockdatabasereader.Object basically breaks down the big object of mockdatabasereader, by using the object databasereader property inside mockdatabasereader rather than the whole mock 
            
            //Install moq Tools - Nuget - Console - Install-package moq

            //ACT
            catalogue.GetAllBooks(); //USING METHOD GetAllBooks FROM CATALOGUE OBJECT


            //ASSERT
            mockdatabasereader.Verify(r => r.ReadDatabase());

        }
    }
}
