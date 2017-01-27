using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreTDD;
using System.Collections.Generic;

namespace BasketTest
{
    [TestClass]
    public class BasketTest
    {
        Basket myBasket;    //CLASS DECLARED FOR ALL METHODS TO SEE
        Book myBooks;

        //BOOKS AVAILABLE
        Book nutshell;
        Book player;

        [TestInitialize]
        public void Setup()
        {
            myBasket = new Basket();    //CONDUCTORS FOR ALL TESTS.
            myBooks = new Book();
            //BOOKS AVAILABLE
            nutshell = new Book();
            player = new Book();
        }

        [TestMethod] //TASK 1 BASKET
        public void Test_GetBooksInBasket_ReturnEmptyBookList_IfNoBooksHaveBeenAdded()  //TESTING CODE TO RETURN EMPTY BOOKLIST IF NO BOOKS ARE IN BASKET.
        {
            //ARRANGE
            // NOT REQUIRED. LOCATED IN [TestInitialize]
            Basket myBasket = new Basket();
            List<Book> expected = new List<Book>();

            //ACT
            List<Book> actual = myBasket.GetBooksInBasket(); //Obtaining list of books in basket from basket.cs


            //ASSERT
            CollectionAssert.AreEqual(expected, actual);    //Expected to see 0 books. Actual results will show number of books in the list/basket
            // expected = list<book> in arrange, actual = mybasket.getbooksinbasket.
        }

        [TestMethod] //TASK 2 BASKET
        public void test_AddBook_ReturnsArrayOfLengthOne_AfterAddBookMethodIsCalledWithOneBook()
        {
            //ARRANGE
            //books are in setup

            //ACT
            myBasket.addBook(nutshell);

            //ASSERT
            Assert.AreEqual(1, myBasket.books.Count); 

        }

        [TestMethod]    // TASK 3 BASKET
        public void test_AddBook_ReturnsArrayOfLengthTwo_AfterAddBookMethodIsCalledWithTwoBook()
        {
            //ARRANGE
            //books are in setup

            //ACT
            myBasket.addBook(nutshell); //adding books to basket(list) x2
            myBasket.addBook(player);

            List<Book> books = myBasket.GetBooksInBasket(); //providing an instance of list for the assert as books (List<Book>)

            //ASSERT
            Assert.AreEqual(2, myBasket.books.Count); //methodname.valuename.count e.g. myBasket.books.Count

        }

    }
}
