using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockBookShopv3;
using System.Collections.Generic;
using Moq;

namespace MockTests
{
    [TestClass]
    public class MockTest
    {
        Mock<IDatabaseWriter> mockdbwriter;
        Mock<IDatabaseReader> mockdbreader;
        Catalogue catalogue;

        [TestInitialize]
        public void Setup()
        {
            mockdbwriter = new Mock<IDatabaseWriter>();
            mockdbreader = new Mock<IDatabaseReader>();
            catalogue = new Catalogue(mockdbreader.Object, mockdbwriter.Object);
        }


        [TestMethod] //TASK 1
        public void Test_GetAllBooks_ReturnsEmptyBookList_IfNoBooksAreInTheCatalogue()
        {
            //ARRANGE

            List<Book> expected = new List<Book>();
            mockdbreader.Setup(r => r.ReadDatabase()).Returns(new List<Book>());
            

            //ACT
            List<Book> actual = catalogue.GetAllBooks();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod] //Task2
        public void test_GetAllBooks_CallsReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE

            //ACT
            List<Book> actual = catalogue.GetAllBooks();

            //ASSERT
            mockdbreader.Verify(r => r.ReadDatabase(), Times.Once);

        }

        [TestMethod] //Task3
        public void test_GetAllBooks_ReturnsListOfBooksItReceivesFromReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE
            Mock<List<Book>> mockbooklist = new Mock<List<Book>>();
            mockdbreader.Setup(r => r.ReadDatabase()).Returns(mockbooklist.Object);

            //ACT
            List<Book> actual = catalogue.GetAllBooks();

            //ASSERT
            CollectionAssert.AreEqual(mockbooklist.Object, actual);
        }

        [TestMethod] //Task 4
        public void test_AddBook_CallsWriteDatabaseMethodOfDatabaseWriter_WhenCalled()
        {
            //ARRANGE

            //ACT
            catalogue.AddBook(new Book());


            //ASSERT
            mockdbwriter.Verify(r => r.WriteDatabase(It.IsAny<Book>()), Times.Once);
        }

        [TestMethod] //Task 5
        public void Test_AddBook_PassTheBookItIsGivenToTheDatabaseWriteOfDatabaseWriter()
        {
            //ARRANGE
            Mock<Book> mockbook = new Mock<Book>();

            //ACT
            catalogue.AddBook(mockbook.Object);

            //ASSERT
            mockdbwriter.Verify(r => r.WriteDatabase(mockbook.Object), Times.Once);
        }
    }
}
