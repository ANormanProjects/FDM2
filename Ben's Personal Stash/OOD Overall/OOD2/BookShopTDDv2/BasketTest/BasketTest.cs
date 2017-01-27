using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShopTDDv2;
using System.Collections.Generic;

namespace BasketTest
{
    [TestClass]
    public class BasketTest
    {
        Basket myBasket;
        Book myBook;

        [TestInitialize]
        public void Setup()
        {
            myBasket = new Basket();
            myBook = new Book();
        }
        [TestMethod] //TASK 1
        public void Test_GetBooksInBasket_ReturnsEmptyBookList_IfNoBooksHaveBeenAdded()
        {
            //ARRANGE
            List<Book> expected = new List<Book>();

            //ACT
            List<Book> actual = myBasket.GetBooksInBasket();

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod] //TASK 2
        public void Test_AddBook_ReturnsArrayOfLengthOne_AfterAddBookMethodIsCalledWithOneBook()
        {
            //ARRANGE
            int expected = 1;


            //ACT
            myBasket.AddBook(myBook);
            int actual = myBasket.booklist.Count;
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] //TASK 3
        public void Test_AddBook_ReturnsArrayOfLengthTwo_AfterAddBookMethodIsCalledWithTwoBooks()
        {
            //ARRANGE
            int expected = 2;


            //ACT
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            int actual = myBasket.booklist.Count;

            //Assert
            Assert.AreEqual(expected, actual);

        }

    }
}
