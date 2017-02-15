using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using E_Commerce_DAL;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_TDD
{
    [TestClass]
    public class ItemsTest
    {
        Mock<DbSet<Item>> dbSetMock;

        [TestInitialize]
        public void setup()
        {
            dbSetMock = new Mock<DbSet<Item>>();
        }

        [TestMethod]
        public void Test_GetAllItems_ReturnsAllItems()
        {
            //ARRANGE
            Mock<Item> book = new Mock<Item>();

            var expected = new List<Item>
            {
                book.Object
            };

            var testData = new List<Item>
            {
                book.Object
            }.AsQueryable();
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextmock = new Mock<E_CommerceDataModel>();
            contextmock.Setup(c => c.items).Returns(dbSetMock.Object);

            ItemRepository itemRepoTest = new ItemRepository(contextmock.Object);


            //ACT
            var actual = itemRepoTest.GetAllItems();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddNewItem_CallsAddNewItemToDatabase_AndSaveChangesOnContext()
        {
            //ARRANGE
            Mock<Item> book = new Mock<Item>();

            var testData = new List<Item>().AsQueryable();
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Item>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextmock = new Mock<E_CommerceDataModel>();
            contextmock.Setup(c => c.items).Returns(dbSetMock.Object);
            ItemRepository itemRepoTest = new ItemRepository(contextmock.Object);

            //ACT
            itemRepoTest.addNewItem(book.Object);

            //ASSERT
            dbSetMock.Verify(c => c.Add(It.IsAny<Item>()), Times.Once);
            contextmock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
