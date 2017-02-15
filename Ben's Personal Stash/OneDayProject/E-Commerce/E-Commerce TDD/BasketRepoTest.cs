using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using E_Commerce_DAL;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_TDD
{
    [TestClass]
    public class BasketRepoTest
    {
        Mock<DbSet<Basket>> dbSetMock;
        Mock<Basket> basket;

        [TestInitialize]
        public void Setup()
        {
            dbSetMock = new Mock<DbSet<Basket>>();
            basket = new Mock<Basket>();
        }

        [TestMethod]
        public void Test_GetAllBaskets()
        {
            //ARRANGE
            var expected = new List<Basket>
            {
                basket.Object
            };

            var testData = new List<Basket>
            {
                basket.Object
            }.AsQueryable();
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextmock = new Mock<E_CommerceDataModel>();
            contextmock.Setup(c => c.baskets).Returns(dbSetMock.Object);

            BasketRepository basketRepoTest = new BasketRepository(contextmock.Object);

            //ACT
            var actual = basketRepoTest.GetAllBaskets();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_addNewBasket_CallsAddNewBasketToDatabase_AndSaveChangesOnContext()
        {
            //ARRANGE
            var testData = new List<Basket>().AsQueryable();
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextmock = new Mock<E_CommerceDataModel>();
            contextmock.Setup(c => c.baskets).Returns(dbSetMock.Object);

            BasketRepository basketRepoTest = new BasketRepository(contextmock.Object);

            //ACT
            basketRepoTest.addNewBasket(basket.Object);

            //ASSERT
            dbSetMock.Verify(c => c.Add(It.IsAny<Basket>()), Times.Once);
            contextmock.Verify(c => c.SaveChanges(), Times.Once);

        }

        [TestMethod]
        public void Test_Save_SavesChangesToContext()
        {
            //ASSERT
            var testData = new List<Basket>().AsQueryable();
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Basket>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextmock = new Mock<E_CommerceDataModel>();
            contextmock.Setup(c => c.baskets).Returns(dbSetMock.Object);

            BasketRepository basketRepoTest = new BasketRepository(contextmock.Object);
            
            //ACT
            basketRepoTest.Save();

            //ASSERT
            contextmock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
