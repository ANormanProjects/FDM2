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



        [TestInitialize]
        public void Setup()
        {
            myBasket = new Basket();    //CONDUCTORS FOR ALL TESTS.

        }


        [TestMethod]
        public void Test_GetBooksInBasket_ReturnEmptyBookList_IfNoBooksHaveBeenAdded()  //TESTING CODE TO RETURN EMPTY BOOKLIST IF NO BOOKS ARE IN BASKET.
        {
            //ARRANGE
            // NOT REQUIRED. LOCATED IN [TestInitialize]
            Basket myBasket = new Basket();

            //ACT
            List<Book> books = myBasket.GetBooksInBasket(); //Obtaining list of books in basket from basket.cs


            //ASSERT
            Assert.AreEqual(0, books.Count);    //Expected to see 0 books. Actual results will show number of books in the list/basket

        }
    }
}
