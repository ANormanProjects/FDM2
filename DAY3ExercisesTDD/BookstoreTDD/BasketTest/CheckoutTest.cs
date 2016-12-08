using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreTDD;

namespace BasketTest
{
    [TestClass]
    public class CheckoutTest
    {
        Basket myBasket = new Basket();
        Checkout myCheckout = new Checkout();
        Book myBook = new Book();
        Book nutshell = new Book();
        Book player = new Book();
        Book dummies = new Book();


        [TestInitialize]
        public void Setup()
        {
            // when using .price, must refer to a specific book and set price or will return false and add above addbook.
            nutshell.price = 15.00; 
            player.price = 10.00;
            dummies.price = 20.00;

        }

        [TestMethod] // TASK 1
        public void test_CalculatePrice_ReturnsZeroWhenPassedAnEmptyBasket()
        {
            //ARRANGE
            Basket myBasket = new Basket();
            Checkout myCheckout = new Checkout();
            double expected = 0;

            //ACT
            double actual = myCheckout.CalculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] // TASK 2
        public void test_CalculatePrice_ReturnsOneWhenPassedABasketWithOneBook()
        {
            //ARRANGE
            // CONDUCTORS IN SETUP
            nutshell.price = 15.00; // when using .price, must refer to a specific book and set price or will return false and add above addbook.
            myBasket.addBook(nutshell);
            
            //ACT
            double cost = myCheckout.CalculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(15.00, cost);

        }

        [TestMethod] // TASK 3
        public void test_CalculatePrice_ReturnsTwoWhenPassedABasketWithTwoBooks()
        {
            //ARRANGE
            //price is used multiple times and is now refactored at the top
            myBasket.addBook(nutshell);
            myBasket.addBook(player);

            //ACT
            double cost = myCheckout.CalculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(25.00, cost);

        }

        [TestMethod] // TASK 4
        public void test_CalculatePrice_WithOnePercentDiscountIfBasketHasThreeBooks()
        {
            
            //ARRANGE
            nutshell.price = 25.99;
            player.price = 25.99;
            dummies.price = 25.99;

            myBasket.addBook(nutshell);
            myBasket.addBook(player);
            myBasket.addBook(dummies);

            //ACT
            double cost = myCheckout.CalculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(77.1903, cost);

        }

        [TestMethod] // TASK 5
        public void test_CalculatePrice_WithTwoPercentDiscountIfBasketHasSevenBooks()
        {
            //ARRANGE
            nutshell.price = 25.99;

            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);

            //ACT
            double cost = myCheckout.CalculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(178.2914, cost);

        }

        [TestMethod] // TASK 6
        public void test_CalculatePrice_With13PercentDiscountIfBasketHas10Books()
        {
            //ARRANGE
            nutshell.price = 25.99;

            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);
            myBasket.addBook(nutshell);

            //ACT
            double cost = myCheckout.CalculatePrice(myBasket);

            //ASSERT
            Assert.AreEqual(226.8927, cost);
        }

    }
}
