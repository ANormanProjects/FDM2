using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using BudgieDatabaseLayer;
using BudgieLogic;
using ASP.NET.Budgie.Controllers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using BudgieMVVM.ViewModels;
using System.Windows.Input;


namespace BudgieUsersRepositoryTests
{
    [TestClass]
    public class MVVMTests
    {
        Mock<BudgieDBCFModel> contextMock;
        Mock<BudgieUserLogic> buLogicMock;
        Mock<BudgieUserRepository> buRepoMock;
        Mock<AccountRepository> accRepoMock;
        Mock<AccountLogic> accountLogicMock;
        BudgieViewModel mvvmTests;
        List<BudgieUser> budgieUserList;

        [TestInitialize]
        public void Setup()
        {
            contextMock = new Mock<BudgieDBCFModel>();
            accRepoMock = new Mock<AccountRepository>(contextMock.Object);
            buRepoMock = new Mock<BudgieUserRepository>(contextMock.Object);
            buLogicMock = new Mock<BudgieUserLogic>(buRepoMock.Object, accRepoMock.Object);
            accountLogicMock = new Mock<AccountLogic>(accRepoMock.Object);
            mvvmTests = new BudgieViewModel(buLogicMock.Object);
            budgieUserList = new List<BudgieUser>();
        }

        [TestMethod]
        public void Test_BudgieViewModelConstructor()
        {
            //ARRANGE
            BudgieViewModel bvm = new BudgieViewModel();
            //ACT

            //ASSERT
            Assert.IsNotNull(bvm.budgieUserRepo);
            Assert.IsNotNull(bvm.accountRepo);
            Assert.IsNotNull(bvm.budgieUserLogic);
        }

        [TestMethod]
        public void Test_ListOfAllBudgieUsers_RunsGetAllBudgieUsersToDisplayListToWPFApplication()
        {
            //ARRANGE
            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(budgieUserList);

            //ACT
            mvvmTests.ListAllBudgieUser();

            //ASSERT
            buLogicMock.Verify(c => c.GetAllBudgieUsers(), Times.Once);
        }

        [TestMethod]
        public void Test_AddUserCommand_Returns_AddUserCommand_WhenNotNull()
        {
            //ARRANGE
            Mock<ICommand> command = new Mock<ICommand>();
            mvvmTests.addBudgieUserCommand = command.Object;

            //ACT
            var test = mvvmTests.addBudgieUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_RemoveUserCommand_Returns_RemoveUserCommand_WhenNotNull()
        {
            //ARRANGE
            Mock<ICommand> command = new Mock<ICommand>();
            mvvmTests.removeBudgieUserCommand = command.Object;

            //ACT
            var test = mvvmTests.removeBudgieUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

    }
}
