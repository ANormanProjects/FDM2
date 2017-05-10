using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketCheckout;
using System.Collections.Generic;
using Moq;

namespace SupermarketCheckoutTDD
{
    [TestClass]
    public class BasketTests
    {
        Basket mybasket;

        [TestInitialize]
        public void Setup()
        {
            mybasket = new Basket();
        }

        [TestMethod]
        public void Test_AddToBasket_AddsItemToBasket()
        {
            //ARRANGE
            Basket mybasket = new Basket();
            Mock<SKU> testA = new Mock<SKU>();
            List<SKU> expected = new List<SKU> { testA.Object };

            //ACT
            mybasket.AddSku(testA.Object);
            
            //ASSERT
            CollectionAssert.AreEqual(expected, mybasket.skuList);

            
        }
    }
}
