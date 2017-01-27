using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using BudgieDatabaseLayer;
using BudgieLogic;

namespace BudgieUsersRepositoryTests
{


    [TestClass]
    public class AccLogicTests
    {

        Mock<BudgieDBCFModel> contextMock;
        Mock<AccountRepository> accountRepoMock;
        Mock<Account> bb;
        Mock<Account> gg;

        [TestInitialize]
        public void Setup()
        {
            contextMock = new Mock<BudgieDBCFModel>();
            accountRepoMock = new Mock<AccountRepository>(contextMock.Object);
            bb = new Mock<Account>();
            gg = new Mock<Account>();
        }

        [TestMethod]
        public void Test_UpdateAccount_UpdatesAccountDetailsToDatabase_OverwritesPreviousDetails()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.accountNumber).Returns("Bowes040191");

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.updateNewAccount(1, "Bowes", "040191")).Verifiable();

       
            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            //ACT
            arTest.updateNewAccount(1, "Bowes", "040192");

            //ASSERT
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(c => c.updateNewAccount(1, "Bowes", "040192"));
        }

        [TestMethod]
        public void Test_RemoveAccount_RemovesAccountFromDatabase()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.removeAccount(1)).Verifiable();


            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            //ACT
            arTest.removeAccount(1);

            //ASSERT
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(c => c.removeAccount(1));
        }

        [TestMethod]
        public void Test_PrintBalance_PrintAccountBalanceFromDatabase()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.printBalance(1)).Returns(100);

            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            decimal expected = 100;

            //ACT
            decimal actual = arTest.printBalance(1);

            //ASSERT
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(c => c.printBalance(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PrintBudget()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.printBudget(1)).Returns(100);

            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            decimal expected = 100;

            //ACT
            decimal actual = arTest.printBudget(1);

            //ASSERT
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(c => c.printBudget(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_WithdrawMoney_CallsWithdrawMoneyToDatabase_ReturnsTrueIfCanWithdraw()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(100);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.printBalance(1)).Returns(100);
            accountRepoMock.Setup(c => c.withdrawMoney(1, 99)).Verifiable();         

            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            bool expected = true;
            
            //ACT
            bool actual = arTest.withdrawMoney(1, 99);

            //ASSERT
            Assert.AreEqual(expected, actual);
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(a => a.withdrawMoney(1, 99), Times.Once);
            accountRepoMock.Verify(a => a.printBalance(1), Times.Once);
        }

        [TestMethod]
        public void Test_WithdrawMoney_CallsWithdrawMoneyToDatabase_ReturnsFalseIfCanNotWithdraw()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(100);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.printBalance(1)).Returns(100);

            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            bool expected = false;

            //ACT
            bool actual = arTest.withdrawMoney(1, 101);

            //ASSERT
            Assert.AreEqual(expected, actual);
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(a => a.printBalance(1), Times.Once);
        }

        [TestMethod]
        public void Test_Deposit()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.depositMoney(1, 100)).Verifiable();

            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

           // decimal expected = 100;

            //ACT
            arTest.depositMoney(1, 100);

            //ASSERT
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(c => c.depositMoney(1, 100));
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_TransferMoney_CallsTransferMoneyToDatabase_ReturnsTrueIfHasEnoughFundsToTransfer()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(100);

            gg.Setup(c => c.id).Returns(2);
            gg.Setup(c => c.accountOwnerId).Returns(2);
            gg.Setup(c => c.balance).Returns(100);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object, gg.Object });
            accountRepoMock.Setup(c => c.printBalance(1)).Returns(100);
            accountRepoMock.Setup(c => c.transferMoney(1, 2, 100));


            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            bool expected = true;

            //ACT
            bool actual = arTest.transferMoney(1, 2, 100);

            //ASSERT
            Assert.AreEqual(expected, actual);
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(a => a.printBalance(1), Times.Once);
            accountRepoMock.Verify(a => a.transferMoney(1, 2, 100), Times.Once);
        }

        [TestMethod]
        public void Test_TransferMoney_CallsTransferMoneyToDatabase_ReturnsFalseIfHasNotGotEnoughFundsToTransfer()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);
            bb.Setup(c => c.balance).Returns(100);

            gg.Setup(c => c.id).Returns(2);
            gg.Setup(c => c.accountOwnerId).Returns(2);
            gg.Setup(c => c.balance).Returns(100);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object, gg.Object });
            accountRepoMock.Setup(c => c.printBalance(1)).Returns(100);
            accountRepoMock.Setup(c => c.transferMoney(1, 2, 100));


            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            bool expected = false;

            //ACT
            bool actual = arTest.transferMoney(1, 2, 101);

            //ASSERT
            Assert.AreEqual(expected, actual);
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(a => a.printBalance(1), Times.Once);
        }

        [TestMethod]
        public void Test_SetBudget()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.accountOwnerId).Returns(1);

            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bb.Object });
            accountRepoMock.Setup(c => c.setBudget(1, 100)).Verifiable();

            AccountLogic arTest = new AccountLogic(accountRepoMock.Object);

            // decimal expected = 100;

            //ACT
            arTest.setBudget(1, 100);

            //ASSERT
            accountRepoMock.Verify(a => a.GetAllAccounts());
            accountRepoMock.Verify(c => c.setBudget(1, 100));
            //Assert.AreEqual(expected, actual);
        }


    }
}
