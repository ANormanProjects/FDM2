using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using BudgieDatabaseLayer;

namespace BudgieUsersRepositoryTests
{
    [TestClass]
    public class ARTests
    {
        [TestMethod]
        public void Test_GetAllAccounts_ReturnsAllAccounts()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();
            Mock<Account> an = new Mock<Account>();
            Mock<Account> sn = new Mock<Account>();


            var expected = new List<Account>
            {
                bb.Object,
                an.Object,
                sn.Object
                //new BudgieUser{ id = 1, firstName = "Ben", lastName = "Bowes", emailAddress = "benjamin.bowes@fdmgroup.com", dob = "040191", password = "password123"},
                //new BudgieUser{ id = 1, firstName = "Andrew", lastName = "Norman", emailAddress = "andrew.norman@fdmgroup.com", dob = "010494", password = "password123"},
            };

            var testData = new List<Account>
            {
                bb.Object,
                an.Object,
                sn.Object

            }.AsQueryable();

            Mock<DbSet<Account>> dbSetMock = new Mock<DbSet<Account>>();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository classUnderTest = new AccountRepository(contextMock.Object);

            //ACT
            var actual = classUnderTest.GetAllAccounts();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
