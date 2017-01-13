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
        Mock<DbSet<Account>> dbSetMock;
        [TestInitialize]
        public void Setup()
        {
            dbSetMock = new Mock<DbSet<Account>>();
        }

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

        [TestMethod]
        public void Test_AddNewAccount_RunsAddAnAccountToDatabase_WhenCalledWithAnAccount()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();

            var testData = new List<Account>().AsQueryable();

            Mock<DbSet<Account>> dbSetMock = new Mock<DbSet<Account>>();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository classUnderTest = new AccountRepository(contextMock.Object);

            //ACT
            classUnderTest.addNewAccount(bb.Object);

            //ASSERT
            dbSetMock.Verify(c => c.Add(It.IsAny<Account>()), Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_UpdateAccount_RunsUpdateAccountToDatabase_AndSaveChangesOnContext()
        {
            //ARRANGE 
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);

            var testData = new List<Account> { bb.Object }.AsQueryable();
            Mock<DbSet<Account>> dbSetMock = new Mock<DbSet<Account>>();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);

            //ACT
            bb.SetupSet(c => c.accountNumber = "Bowes040191").Verifiable();
            arTest.updateNewAccount(1, "Bowes", "040191");

            //ASSERT
            dbSetMock.Verify(c => c.Find(1), Times.Once);
            bb.VerifySet(c => c.accountNumber = "Bowes040191");
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_RemoveAccount_CallsRemoveAnAccountToDatabase_AndSaveChangesOnContext()
        {
            //ARRANGE 
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);

            var testData = new List<Account> { bb.Object }.AsQueryable();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);

            //ACT
            arTest.removeAccount(1);

            //ASSERT
            //CollectionAssert.AreEqual(expected, actual);

            dbSetMock.Verify(c => c.Find(1), Times.Once);
            dbSetMock.Verify(c => c.Remove(bb.Object), Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
