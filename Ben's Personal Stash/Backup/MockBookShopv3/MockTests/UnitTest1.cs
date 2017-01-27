using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockBookShopv3;
using System.Collections.Generic;
using Moq;

namespace MockTests
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IDatabaseReader> mockdatabasereader;
        Mock<DatabaseWriter> mockdbwriter;
        Catalogue catalogue;

        [TestInitialize]
        public void Setup()
        {
            mockdbwriter = new Mock<DatabaseWriter>();
            mockdatabasereader = new Mock<IDatabaseReader>();
            catalogue = new Catalogue(mockdatabasereader.Object, mockdbwriter.Object);
        }

        [TestMethod] // TASK 1
        public void Test_GetAllBooks_ReturnsEmptyBookList_IfNoBooksAreInCatalogue()
        {
            //ARRANGE
            //Catalogue catalogue = new Catalogue(); //Catalogue object
            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(new List<Book>()); //T2
            List<Book> expected = new List<Book>(); //Book list

            //ACT
            List<Book> actual = catalogue.GetAllBooks(); // Call GetAllBooks method of catalogue and return list of books

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod] // TASK 2
        public void Test_GetAllBooks_CallsReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE
            Mock<IDatabaseReader> mockdatabasereader = new Mock<IDatabaseReader>(); // Mock Database Object
            Catalogue catalogue = new Catalogue(mockdatabasereader.Object, mockdbwriter.Object); // Catalogue Object
            mockdatabasereader.Setup(r => r.ReadDatabase());

            //ACT
            catalogue.GetAllBooks();

            //ASSERT
            mockdatabasereader.Verify(r => r.ReadDatabase());

        }

        [TestMethod] // TASK 3
        public void Test_GetAllBooks_ReturnsListOfBooksItReceivesFromReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE
            Mock<List<Book>> mockbooklist = new Mock<List<Book>>();
            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(mockbooklist.Object);

            //ACT
            List<Book> actual = catalogue.GetAllBooks();
            //ASSERT
            CollectionAssert.AreEqual(mockbooklist.Object, actual);
        }

        [TestMethod]
        public void Test_AddBook_CallsWriteDatabaseMethodOfDatabaseWriter_WhenCalled()
        {
            //ARRANGE
            Mock<DatabaseWriter> mockdbwriter = new Mock<DatabaseWriter>();
            Mock<List<Book>> mockbooks = new Mock<List<Book>>();
            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(mockbooks.Object);

            //ACT
            catalogue.AddBooks(new Book());

            //ASSERT
            mockdbwriter.Verify(r => r.WriteDatabase(It.IsAny<Book>()), Times.Once);

        }

        [TestMethod] //TASK 5
        public void Test_AddBook_CallsWriteDatabaseMethodOfDatabaseWriter_AndContainsAddedBook()
        {
            //ARRANGE
            Mock<Book> mockBook = new Mock<Book>(); // MOCK BOOK OBJECT

            //ACT
            catalogue.AddBooks(mockBook.Object);  // MOCKBOOK INJECTED INTO ADDBOOK (DATABASEWRITER METHOD)

            //ASSERT
            mockdbwriter.Verify(r => r.WriteDatabase(mockBook.Object), Times.Once);
        }
    }
}
