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
            bb.SetupSet(c => c.accountNumber = "HarryPotter").Verifiable();

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

        [TestMethod]
        public void Test_WithdrawMoney_CallsWithdrawMoneyToDatabase_ReturnsTrueIfCanWithdraw_AndSaveChangesOnContext()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(100);

            var testData = new List<Account> { bb.Object }.AsQueryable();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);

            decimal expected = 1;
            //ACT
            arTest.withdrawMoney(1, 99);
            decimal actual = arTest.printBalance(1);

            //ASSERT

            dbSetMock.Verify(c => c.Find(1));
            bb.VerifySet(c => c.balance = 1, Times.Once);
            Assert.AreEqual(expected, actual);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_WithdrawMoney_CallsWithdrawMoneyToDatabase_ReturnsFalseIfCannotWithdraw()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(100);

            var testData = new List<Account> { bb.Object }.AsQueryable();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);

            bool expected = false;
            //ACT
            bool actual = arTest.withdrawMoney(1, 101);

            //ASSERT

            dbSetMock.Verify(c => c.Find(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_DepositMoney_CallsDepositMoneyToDatabase_AndSaveChangesOnContext()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(0);

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
            arTest.depositMoney(1, 99);

            //ASSERT
            dbSetMock.Verify(c => c.Find(1));
            bb.VerifySet(c => c.balance = 99, Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_TransferMoney_CallsTransferMoneyToDatabase_ReturnsTrueIfHasEnoughFundsToTransfer_AndSaveChangesOnContext()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();
            Mock<Account> gg = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(101);

            gg.Setup(g => g.id).Returns(2);
            gg.Setup(g => g.accountOwnerId).Returns(2);
            gg.Setup(g => g.balance).Returns(50);

            var testData = new List<Account> { bb.Object, gg.Object }.AsQueryable();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);
            dbSetMock.Setup(c => c.Find(2)).Returns(gg.Object);
            bool expected = true;
            
            //ACT

            bool actual = arTest.transferMoney(1, 2, 100);

            //ASSERT
            dbSetMock.Verify(c => c.Find(1));
            dbSetMock.Verify(c => c.Find(2));
            bb.VerifySet(c => c.balance = 1, Times.Once);
            gg.VerifySet(c => c.balance = 150, Times.Once);
            Assert.AreEqual(expected, actual);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_TransferMoney_CallsTransferMoneyToDatabase_ReturnsFalseIfAccountHasInsufficentFunds()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();
            Mock<Account> gg = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(101);

            gg.Setup(g => g.id).Returns(2);
            gg.Setup(g => g.accountOwnerId).Returns(2);
            gg.Setup(g => g.balance).Returns(50);

            var testData = new List<Account> { bb.Object, gg.Object }.AsQueryable();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);
            dbSetMock.Setup(c => c.Find(2)).Returns(gg.Object);
            bool expected = false;

            //ACT

            bool actual = arTest.transferMoney(1, 2, 102);

            //ASSERT
            dbSetMock.Verify(c => c.Find(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PrintBalance_CallsDatabaseToPrintBalance_AndDisplaysCurrentBalance()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(101);

            var testData = new List<Account> { bb.Object }.AsQueryable();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);
            decimal expected = 101;

            //ACT
            decimal actual = arTest.printBalance(1);

            //ASSERT
            dbSetMock.Verify(c => c.Find(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PrintBudget_CallsDatabaseToPrintBudget_AndDisplaysCurrentBudget()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.budget).Returns(101);

            var testData = new List<Account> { bb.Object }.AsQueryable();
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<Account>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.accounts).Returns(dbSetMock.Object);

            AccountRepository arTest = new AccountRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);
            decimal expected = 101;

            //ACT
            decimal actual = arTest.printBudget(1);

            //ASSERT
            dbSetMock.Verify(c => c.Find(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SetBudget_CallsDatabaseToSetBudget_AndDIsplaysNewBudget()
        {
            //ARRANGE
            Mock<Account> bb = new Mock<Account>();

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.budget).Returns(0);

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
            arTest.setBudget(1, 101);
            

            //ASSERT
            dbSetMock.Verify(c => c.Find(1));
            bb.VerifySet(c => c.budget = 101, Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

    }
}
