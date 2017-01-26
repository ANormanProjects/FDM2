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
    public class NavigationModelTest
    {
        NavigationViewModel navMVVM;
        [TestInitialize]
        public void Setup()
        {
            navMVVM = new NavigationViewModel();
        }

        [TestMethod]
        public void Test_Constructor()
        {
            //ARRANGE
            NavigationViewModel navMVVM = new NavigationViewModel();

            //ACT

            //ASSERT
            Assert.IsNotNull(navMVVM.location);
        }

        [TestMethod]
        public void Test_NavigateWelcomePageCommand_Returns_WelcomeCommand_WhenNotNull()
        {
            //ARRANGE
            Mock<ICommand> command = new Mock<ICommand>();
            navMVVM.navigateWelcomeCommand = command.Object;

            //ACT
            var test = navMVVM.navigateWelcomeCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_NavigateListAllUsersCommand_Returns_ListAllUsersCommand_WhenNotNull()
        {
            //ARRANGE
            Mock<ICommand> command = new Mock<ICommand>();
            navMVVM.navigateListOfAllUsersCommand = command.Object;

            //ACT
            var test = navMVVM.navigateListOfAllUsersCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_NavigateAddUserCommand_Returns_AddUserCommand_WhenNotNull()
        {
            //ARRANGE
            Mock<ICommand> command = new Mock<ICommand>();
            navMVVM.navigateAddUserCommand = command.Object;

            //ACT
            var test = navMVVM.navigateAddUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_NavigateRemoveUserCommand_Returns_RemoveUser_WhenNotNull()
        {
            //ARRANGE
            Mock<ICommand> command = new Mock<ICommand>();
            navMVVM.navigateRemoveUserCommand = command.Object;

            //ACT
            var test = navMVVM.navigateRemoveUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

    }
}
