using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SupermarketCheckout;

namespace SupermarketCheckoutTDD
{
    [TestClass]
    public class CheckoutTests
    {
        Mock<Basket> myBasket;
        Mock<SKU> mockA;
        Checkout myCheckout;

        [TestInitialize]
        public void Setup()
        {
            myBasket = new Mock<Basket>();
            myCheckout = new Checkout(myBasket.Object);
            mockA = new Mock<SKU>();

            mockA.Setup(x => x.name).Returns("A");
            mockA.Setup(x => x.price).Returns(5.00);
            mockA.Setup(x => x.isThereAnOffer).Returns(true);
            mockA.Setup(x => x.numberRequiredForOffer).Returns(3);
            mockA.Setup(x => x.offerPrice).Returns(13.00);
        }

        [TestMethod]
        public void Test_CalculatePrice_ReturnsZeroWhenPassesAnEmptyBasket()
        {
            //ARRANGE
            double expected = 0.0;            

            //ACT
            double actual = myCheckout.CalculatePrice();

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CalculatePrice_ReturnsPriceOf5WhenPassesABasketWithOneItem()
        {
            //ARRANGE
            double expected = 5.00;


            myBasket.Object.AddSku(mockA.Object);
            

            //ACT
            double actual = myCheckout.CalculatePrice();

            //ASSERT
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_CalculatePrice_ReturnsPriceOf13WhenPassesABasketWithThreeItemsOnOffer()
        {
            //ARRANGE
            double expected = 13.00;

            //Add Three mockA items to the basket
            myBasket.Object.AddSku(mockA.Object);
            myBasket.Object.AddSku(mockA.Object);
            myBasket.Object.AddSku(mockA.Object);
            
            //ACT
            double actual = myCheckout.CalculatePrice();

            //ASSERT
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_CalculatePrice_ReturnsPriceOf18WhenPassesABasketWithFourItems_IncludingAnOfferOfThree()
        {
            //ARRANGE
            double expected = 18.00;

            //Add Four mockA items to the basket
            myBasket.Object.AddSku(mockA.Object);
            myBasket.Object.AddSku(mockA.Object);
            myBasket.Object.AddSku(mockA.Object);
            myBasket.Object.AddSku(mockA.Object);

            //ACT
            double actual = myCheckout.CalculatePrice();

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

    }
}
