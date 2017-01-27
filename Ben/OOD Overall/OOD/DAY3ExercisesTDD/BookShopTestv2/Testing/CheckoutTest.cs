using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShopTestv2;

namespace Testing
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
        [TestMethod] //Test1
        public void test_CalculatePrice_ReturnsZeroWhenPassedAnEmptyBasket()
        {
            //Arrange
            double expected = 0.0;

            //Act
            double actual = myCheckout.CalculatePrice(myBasket);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] //Test 2
        public void test_CalculatePrice_ReturnsPriceOfBookInBasket_WhenPassedBasketWithOneBook()
        {
            //Arrange
            double expected = 10.00;

            myBook.price = 10.00;

            //Act
            myBasket.AddBook(myBook);

            double actual = myCheckout.CalculatePrice(myBasket);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] //Test 3
        public void test_CalculatePrice_ReturnsPriceOfBooksInBasket_WhenPassedBasketWithTwoBook()
        {
            //Arrange
            double expected = 20.00;

            myBook.price = 10.00;

            //Act
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);

            double actual = myCheckout.CalculatePrice(myBasket);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] //Test 4
        public void test_CalculatePrice_ReturnsPriceOfBooksInBasket_WhenPassedBasketWithThreeBooks_With1Discount()
        {
            //Arrange
            double expected = 29.7;

            myBook.price = 10.00;

            //Act
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);


            double actual = myCheckout.CalculatePrice(myBasket);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //Test 5
        public void test_CalculatePrice_ReturnsPriceOfBooksInBasket_WhenPassedBasketWithSevenBooks_With2Discount()
        {
            //Arrange
            double expected = 68.6;

            myBook.price = 10.00;

            //Act
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);
            myBasket.AddBook(myBook);


            double actual = myCheckout.CalculatePrice(myBasket);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //Test 6
        public void test_CalculatePrice_ReturnsPriceOfBooksInBasket_WhenPassedBasketWith10Books_With13Discount()
        {
            //Arrange
            double expected = 87;

            myBook.price = 10.00;

            //Act
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


            double actual = myCheckout.CalculatePrice(myBasket);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
