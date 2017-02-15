using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using E_Commerce_Logic;
using Moq;
using E_Commerce_DAL;
using System.Collections.Generic;

namespace E_Commerce_TDD
{
    [TestClass]
    public class ItemLogicTests
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void Test_GetAllItems_ReturnsAListOfItemsInStore()
        {
            //ARRANGE
            Mock<ItemRepository> mockItemRepo = new Mock<ItemRepository>();
            mockItemRepo.Setup(c => c.GetAllItems()).Returns(new List<Item>());

            ItemLogic itemLogicTest = new ItemLogic(mockItemRepo.Object);

            //ACT
            itemLogicTest.GetAllItems();

            //ASSERT
            mockItemRepo.Verify(c => c.GetAllItems());           
        }
    }
}
