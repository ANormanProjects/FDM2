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
        Mock<DatabaseReader> mockdatabasereader;
        Mock<DatabaseWriter> mockdatabasewriter;
        Catalogue catalogue;

        [TestInitialize]
        public void Setup()
        {
            mockdatabasereader = new Mock<DatabaseReader>();
            mockdatabasewriter = new Mock<DatabaseWriter>();
            catalogue = new Catalogue(mockdatabasereader.Object, mockdatabasewriter.Object);

        }

        [TestMethod] // TEST 1
        public void Test_GetAllBooks_ReturnsEmptyBookList_IfNoBooksAreInTheCatalogue()
        {
            //ARRANGE
            //Mock<DatabaseReader> mockdatabasereader = new Mock<DatabaseReader>(); //MOVE HERE FOR TEST 2

            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(new List<Book>());  //SETUP FORCES ReadDatabase TO RETURN A NEW LIST OF BOOKS (EMPTY)

            List<Book> expected = new List<Book>();
            //Catalogue catalogue = new Catalogue(mockdatabasereader.Object); //MOVE HERE FOR TEST 2

            //ACT
            List<Book> actual = catalogue.GetAllBooks();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual); //CollectionAssert is USED FOR COMPARING LISTS

        }

        [TestMethod] // TEST 2
        public void test_GetAllBooks_CallsReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE
            //mockdatabasereader = new Mock<DatabaseReader>(); //FAKE OBJECT

            mockdatabasereader.Setup(r => r.ReadDatabase());

            //Catalogue catalogue = new Catalogue(mockdatabasereader.Object); // REAL OBJECT //INJECT MOCK OBJECT INTO REAL

            //mockdatabasereader.Object basically breaks down the big object of mockdatabasereader, by using the object databasereader property inside mockdatabasereader rather than the whole mock 

            //Install moq Tools - Nuget - Console - Install-package moq

            //ACT
            catalogue.GetAllBooks(); //USING METHOD GetAllBooks FROM CATALOGUE OBJECT


            //ASSERT
            mockdatabasereader.Verify(r => r.ReadDatabase(), Times.Once);

        }

        [TestMethod] //TASK 3
        public void Test_GetAllBooks_ReturnsListOfBooksItReceivesFromReadDatabase_WhenCalled()
        {
            //ARRANGE
            Mock<List<Book>> mockBooks = new Mock<List<Book>>();
            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(mockBooks.Object); //.Object is a small part of the full Mock

            //ACT
            List<Book> actual = catalogue.GetAllBooks();

            //ASSERT
            Assert.AreEqual(mockBooks.Object, actual);
        }

        [TestMethod] //TASK 4
        public void Test_AddBook_CallsWriteDatabaseMethodOfDatabaseWriter_WhenCalled()
        {
            //ARRANGE
            //Mock<DatabaseWriter> databasewriter = new Mock<DatabaseWriter>();
            Mock<List<Book>> mockBooks = new Mock<List<Book>>();
            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(mockBooks.Object); //.Object is a small part of the full Mock

            //ACT
            catalogue.AddBook(new Book());

            //ASSERT
            mockdatabasewriter.Verify(r => r.WriteDatabase(It.IsAny<Book>()), Times.Once);
        }

        [TestMethod] //TASK 5
        public void Test_AddBook_CallsWriteDatabaseMethodOfDatabaseWriter_AndContainsAddedBook()
        {
            //ARRANGE
            Mock<Book> mockBook = new Mock<Book>(); // MOCK BOOK OBJECT

            //ACT
            catalogue.AddBook(mockBook.Object);  // MOCKBOOK INJECTED INTO ADDBOOK (DATABASEWRITER METHOD)

            //ASSERT
            mockdatabasewriter.Verify(r => r.WriteDatabase(mockBook.Object), Times.Once);
        }
    }
}
