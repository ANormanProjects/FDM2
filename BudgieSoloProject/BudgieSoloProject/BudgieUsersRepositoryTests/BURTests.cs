using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using BudgieDatabaseLayer;

namespace BudgieEntityFramework.Tests
{
    [TestClass]
    public class BURTests
    {
        [TestMethod]
        public void Test_GetAllBrokers_ReturnsAllBrokers()
        {
            //ARRANGE
            Mock<BudgieUser> bb = new Mock<BudgieUser>();
            Mock<BudgieUser> an = new Mock<BudgieUser>();
            Mock<BudgieUser> sn = new Mock<BudgieUser>();

            var expected = new List<BudgieUser>
            {
                bb.Object,
                an.Object,
                sn.Object
                //new BudgieUser{ id = 1, firstName = "Ben", lastName = "Bowes", emailAddress = "benjamin.bowes@fdmgroup.com", dob = "040191", password = "password123"},
                //new BudgieUser{ id = 1, firstName = "Andrew", lastName = "Norman", emailAddress = "andrew.norman@fdmgroup.com", dob = "010494", password = "password123"},
            };

            var testData = new List<BudgieUser>
            {
                bb.Object,
                an.Object,
                sn.Object

            }.AsQueryable();

            Mock<DbSet<BudgieUser>> dbSetMock = new Mock<DbSet<BudgieUser>>();
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.budgieUsers).Returns(dbSetMock.Object);

            BudgieUserRepository classUnderTest = new BudgieUserRepository(contextMock.Object);

            //ACT
            var actual = classUnderTest.GetAllBudgieUsers();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
