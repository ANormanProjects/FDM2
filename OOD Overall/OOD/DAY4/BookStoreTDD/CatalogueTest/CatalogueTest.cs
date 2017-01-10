using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStoreTDD;
using System.Collections.Generic;
using Moq;

namespace CatalogueTest
{
    [TestClass]
    public class CatalogueTest
    {
        [TestMethod] // TASK 1
        public void Test_GetAllBooks_ReturnEmptyBooksList_IfNoBooksAreInTheCatalogue()
        {
          
            //Test code

            //ARRANGE
            Mock<DatabaseReader> mockdatabasereader = new Mock<DatabaseReader>();

            //METHOD STUBBING RETURNING A NEW EMPTY LIST OF BOOKS (OVERRIDES BookStoreTDD).

            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(new List<Book>());

            Catalogue catalogue = new Catalogue(mockdatabasereader.Object);

            //ACT
            List<Book> books = catalogue.GetAllBooks();

            //ASSERT
            Assert.AreEqual(0, books.Count);
        }

        [TestMethod] // TASK 2
        public void Test_GetAllBooks_CallsReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE
            Mock<DatabaseReader> mockdatabasereader = new Mock<DatabaseReader>();

            //ADD to catalogue (public catalogue(***))
            Catalogue catalogue = new Catalogue(mockdatabasereader.Object); 

            //ACT
            catalogue.GetAllBooks(); //Calls this method

            //ASSERT
            mockdatabasereader.Verify(r => r.ReadDatabase(),Times.Once); //Runs once, calls List<Book> in DatabaseReader
        }

        [TestMethod] // TASK 3
        public void Test_GetAllBooks_ReturnsListOfBooksItReceivesFromReadDatabaseMethodOfDatabaseReader_WhenCalled()
        {
            //ARRANGE
            Mock<DatabaseReader> mockdatabasereader = new Mock<DatabaseReader>(); // Mock databasereader
            Mock<List<Book>> mocklistbooks = new Mock<List<Book>>(); // Mock list of books

            Catalogue catalogue = new Catalogue(mockdatabasereader.Object); // INJECT MockDatabaseReader into catalogue object

            mockdatabasereader.Setup(r => r.ReadDatabase()).Returns(new List<Book>()); // Mock Method Stubbing to stub readdatabase to return mock book list


            //ACT


            //ASSERT




        }
    }
}
