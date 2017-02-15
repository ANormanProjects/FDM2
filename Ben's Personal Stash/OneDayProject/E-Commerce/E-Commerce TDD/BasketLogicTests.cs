using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using E_Commerce_DAL;
using E_Commerce_Logic;
using System.Collections.Generic;

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
        public void Test_StartNewBasket_CreatesNewUniqueBasketAndAddsToDatabase()
        {
            //ARRANGE
            mockBasketRepo.Setup(c => c.GetAllBaskets()).Returns(new List<Basket>());
            mockBasketRepo.Setup(c => c.addNewBasket(mockBasket.Object)).Verifiable();

            //ACT
            basketLogic.startNewBasket(mockBasket.Object);

            //ASSERT
            mockBasketRepo.Verify(c => c.GetAllBaskets(), Times.Once);
            mockBasketRepo.Verify(c => c.addNewBasket(mockBasket.Object), Times.Once);

        }

        [TestMethod]
        [ExpectedException(typeof(BasketAlreadyExistsException))]
        public void Test_BasketAlreadyExistsExceptionThrown_WhenBasketIsNotInDatabase_WhenStartNewBasketIsRun()
        {
            //ARRANGE
            mockBasketRepo.Setup(c => c.GetAllBaskets()).Returns(new List<Basket>() { mockBasket.Object } );

            //ACT
            basketLogic.startNewBasket(mockBasket.Object);
        }

        [TestMethod]
        public void Test_GetAllItemsInBasket_ReturnsListOfItemsFromBasket()
        {
            //ARRANGE

            mockBasketRepo.Setup(c => c.GetAllBaskets()).Returns(new List<Basket>(){ mockBasket.Object });
            mockBasket.Setup(c => c.itemsInBasket).Returns(new List<Item>() { mockItem.Object });

            List<Item> expected = new List<Item>() { mockItem.Object };

            //ACT
            List<Item> actual = basketLogic.GetAllItemsInBasket(mockBasket.Object);


            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void Test_AddNewItemToBasket_CallsAddNewItemToBasket_SaveChangesOnContext()
        {
            //ARRANGE
            mockBasketRepo.Setup(c => c.GetAllBaskets()).Returns(new List<Basket>() { mockBasket.Object });
            mockItemRepo.Setup(c => c.GetAllItems()).Returns(new List<Item>() { mockItem.Object });

            List<Item> items = new List<Item>();

            mockBasket.Setup(c => c.itemsInBasket).Returns(items);
            List<Item> expected = new List<Item>(){ mockItem.Object };

            //ACT
            basketLogic.addItemToBasket(mockBasket.Object, mockItem.Object);

            //ASSERT
            CollectionAssert.AreEqual(expected, items);
        }

        [TestMethod]
        [ExpectedException(typeof(ItemDoesNotExistException))]
        public void Test_ItemDoesNotExistExceptionThrown_WhenItemIsNotInDatabase_WhenAddItemToBasketIsRun()
        {
            //ARRANGE
            mockBasketRepo.Setup(c => c.GetAllBaskets()).Returns(new List<Basket>() { mockBasket.Object });
            mockItemRepo.Setup(c => c.GetAllItems()).Returns(new List<Item>() { });

            //ACT
            basketLogic.addItemToBasket(mockBasket.Object, mockItem.Object);
        }
    }
}
