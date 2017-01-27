using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShopTDDv2;

namespace BasketTest
{
    [TestClass]
    public class CheckoutTest
    {
        Basket myBasket;
        Checkout myCheckout;
        Book myBook;

        [TestInitialize]
        public void Setup()
        {
            myBasket = new Basket();
            myCheckout = new Checkout();
            myBook = new Book();
        }

        [TestMethod] //TASK 1
        public void Test_CalculatePrice_IfPassedEmptyBasket_WillReturnAPriceOfZero()
        {
            //ARRANGE
            double expected = 0.0;

            //ACT
            double actual = myCheckout.calculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TASK 2
        public void Test_CalculatePrice_ReturnsPriceOfOneBook_WhenPassedABasketWithOneBook()
        {
            //ARRANGE
            myBook.price = 20.00;
            double expected = 20.0;

            //ACT
            myBasket.AddBook(myBook);
            double actual = myCheckout.calculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TASK 3
        public void Test_CalculatePrice_ReturnsPriceOfTwoBooks_WhenPassedABasketWithTwo()
        {
            //ARRANGE
            myBook.price = 20.00;
            double expected = 40.0;

            //ACT
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            double actual = myCheckout.calculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TASK 4
        public void Test_CalculatePrice_ReturnsPriceOfThreeBooks_WhenPassedABasketWithThree_Get1PDiscount()
        {
            //ARRANGE
            myBook.price = 20.00;
            double expected = 59.4;

            //ACT
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            double actual = myCheckout.calculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TASK 5
        public void Test_CalculatePrice_ReturnsPriceOfSevenBooks_WhenPassedABasketWithSeven_Get2PDiscount()
        {
            //ARRANGE
            myBook.price = 20.00;
            double expected = 137.2;

            //ACT
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);

            double actual = myCheckout.calculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TASK 6
        public void Test_CalculatePrice_ReturnsPriceOfTenBooks_WhenPassedABasketWithTen_Get13PDiscount()
        {
            //ARRANGE
            myBook.price = 20.00;
            double expected = 174;

            //ACT
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);

            double actual = myCheckout.calculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //TASK 7
        public void Test_CalculatePrice_ReturnsPriceOf20Books_WhenPassedABasketWith20_Get26PDiscount()
        {
            //ARRANGE
            myBook.price = 20.00;
            double expected = 296;

            //ACT
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);


            double actual = myCheckout.calculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }
    }
}
