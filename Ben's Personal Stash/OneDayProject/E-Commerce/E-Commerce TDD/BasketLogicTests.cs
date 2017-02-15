using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using E_Commerce_DAL;
using E_Commerce_Logic;

namespace E_Commerce_TDD
{
    [TestClass]
    public class BasketLogicTests
    {
        Mock<ItemRepository> mockItemRepo;
        Mock<BasketRepository> mockBasketRepo;
        Mock<Item> mockItem;
        Mock<Basket> mockBasket;
        BasketLogic basketLogic;

        [TestInitialize]
        public void Setup()
        {
            mockItemRepo = new Mock<ItemRepository>();
            mockBasketRepo = new Mock<BasketRepository>();
            basketLogic = new BasketLogic(mockItemRepo.Object, mockBasketRepo.Object);
            mockItem = new Mock<Item>();
            mockBasket = new Mock<Basket>();
        }

        [TestMethod]
        public void Test_AddNewItemToBasket_CallsAddNewItemToBasket_SaveChangesOnContext()
        {
            //ARRANGE


            //ACT

            //ASSERT

        }

        [TestMethod]
        public void Test_GetAllItemsInBasket_ReturnsListOfItemsFromBasket()
        {
            //ARRANGE

            //ACT

            //ASSERT

        }
    }
}
