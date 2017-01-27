using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShopTestv2;
using System.Collections.Generic;

namespace Testing
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

        [TestMethod]
        public void Test_GetBooksInBasket_ReturnsEmptyBookList_IfNoBooksInBasket()
        {
            //ARRANGE

            List<Book> expected = new List<Book>();
    
            //ACT
            List<Book> actual = myBasket.GetBooksInBasket();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod] //TASK 2
        public void test_AddBook_ReturnsArrayOfLengthOne_AfterAddBookMethodIsCalledWithOneBook()
        {
            //ARRANGE

            double expected = 1.0;


            //ACT
            myBasket.AddBook(myBook);
            int actual = myBasket.GetBooksInBasket().Count;

            //ASSERT
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] //TASK 3
        public void test_AddBook_ReturnsArrayOfLengthTwo_AfterAddBookMethodIsCalledWithTwoBook()
        {
            //ARRANGE

            double expected = 2.0;


            //ACT
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            int actual = myBasket.GetBooksInBasket().Count;

            //ASSERT
            Assert.AreEqual(expected, actual);

        }
    }
}
