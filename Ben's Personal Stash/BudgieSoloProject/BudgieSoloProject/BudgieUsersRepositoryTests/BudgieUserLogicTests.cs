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
    public class BudgieUserLogicTests
    {
        Mock<BudgieDBCFModel> contextMock;
        Mock<BudgieUserRepository> budgieUserRepoMock;
        Mock<BudgieUser> budgieUserMock;
        Mock<AccountRepository> accountRepoMock;
        Mock<AccountLogic> accountLogicMock;
        Mock<BudgieUser> bb;
        Mock<Account> bbAcc;

        [TestInitialize]
        public void Setup()
        {
            contextMock = new Mock<BudgieDBCFModel>();
            budgieUserRepoMock = new Mock<BudgieUserRepository>(contextMock.Object);
            budgieUserMock = new Mock<BudgieUser>(contextMock.Object);
            accountRepoMock = new Mock<AccountRepository>(contextMock.Object);
            accountLogicMock = new Mock<AccountLogic>(accountRepoMock.Object);
            bb = new Mock<BudgieUser>();
            bbAcc = new Mock<Account>();
        }

        [TestMethod]
        public void Test_RegisterUser_CallsAddABudgieUserToDatabase()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.firstName).Returns("Ben");
            bb.Setup(c => c.lastName).Returns("Bowes");
            bb.Setup(c => c.dob).Returns("010101");
            bb.Setup(c => c.emailAddress).Returns("benbowes@gmail.com");
            bb.Setup(c => c.roles).Returns("User");

            bbAcc.Setup(c => c.id).Returns(1);
            bbAcc.Setup(c => c.accountOwnerId).Returns(1);

            budgieUserRepoMock.Setup(c => c.addNewBudgieUser(bb.Object)).Verifiable();
            accountRepoMock.Setup(c => c.addNewAccount(bbAcc.Object)).Verifiable();


            BudgieUserLogic bulTest = new BudgieUserLogic(budgieUserRepoMock.Object, accountRepoMock.Object, accountLogicMock.Object);
            
            //ACT
            bulTest.RegisterUser(bb.Object);

            //ASSERT
            budgieUserRepoMock.Verify(c => c.addNewBudgieUser(bb.Object));

        }

        [TestMethod]
        public void Test_UpdateUser_UpdatesBudgieUserDetailsToDatabase_AndUpdatesAccountDetails()
        {
            //ARRANGE
            bbAcc.Setup(c => c.id).Returns(1);
            bbAcc.Setup(c => c.accountOwnerId).Returns(1);
            bbAcc.Setup(c => c.accountNumber).Returns("Bowes040191");

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.firstName).Returns("Ben");
            bb.Setup(c => c.lastName).Returns("Bowes");
            bb.Setup(c => c.dob).Returns("010101");
            bb.Setup(c => c.emailAddress).Returns("benbowes@gmail.com");

            budgieUserRepoMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            budgieUserRepoMock.Setup(c => c.updateBudgieUser(1, "Ben", "Bowes", "010101")).Verifiable();
            accountRepoMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbAcc.Object });
            accountLogicMock.Setup(c => c.updateNewAccount(1, "Bowes", "010101")).Verifiable();

            BudgieUserLogic bulTest = new BudgieUserLogic(budgieUserRepoMock.Object, accountRepoMock.Object, accountLogicMock.Object);

            //ACT
            bulTest.UpdateUser(bb.Object); 

            //ASSERT
            budgieUserRepoMock.Verify(c => c.GetAllBudgieUsers());
            budgieUserRepoMock.Verify(c => c.updateBudgieUser(1, "Ben", "Bowes", "010101"));
            accountRepoMock.Verify(a => a.GetAllAccounts());
        }

        [TestMethod]
        public void Test_RemoveUser_RemovesUserFromDatabase()
        {
            //ARRANGE
            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.emailAddress).Returns("benbowes@gmail.com");

            budgieUserRepoMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            budgieUserRepoMock.Setup(c => c.removeBudgieUser(1)).Verifiable();

            BudgieUserLogic bulTest = new BudgieUserLogic(budgieUserRepoMock.Object, accountRepoMock.Object, accountLogicMock.Object);

            //ACT
            bulTest.RemoveUser(bb.Object);

            //ASSERT
            budgieUserRepoMock.Verify(c => c.GetAllBudgieUsers());
            budgieUserRepoMock.Verify(c => c.removeBudgieUser(1));

        }
    }
}
