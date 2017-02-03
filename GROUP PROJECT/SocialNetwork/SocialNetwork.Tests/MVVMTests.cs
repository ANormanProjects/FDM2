using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.MVVM.ViewModel;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System.Collections.Generic;
using System.Windows.Input;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class MVVMTests
    {

        Mock<Repository<User>> userRepo;
        Mock<UserAccountLogic> userAccountLogic;
        List<User> userList;
        WPFViewModel WPFVMTests;
        Mock<ICommand> command;

        [TestInitialize]
        public void Setup()
        {
            userRepo = new Mock<Repository<User>>();
            userAccountLogic = new Mock<UserAccountLogic>(userRepo.Object);
            WPFVMTests = new WPFViewModel(userAccountLogic.Object);
            userList = new List<User>();
            command = new Mock<ICommand>();

        }

        [TestMethod]
        public void Test_ListAllUsersViewModelConstructor()
        {
            //ARRANGE
            WPFViewModel WPFVM = new WPFViewModel();
            //ACT

            //ASSERT
            Assert.IsNotNull(WPFVM._userRepository);
            Assert.IsNotNull(WPFVM.userAccLogic);
        }

        [TestMethod]
        public void Test_ListOfAllUsers_RunsGetAllUsersToDisplayListToWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.GetAllUserAccounts()).Returns(userList);

            //ACT
            WPFVMTests.ListAllUsers();

            //ASSERT
            userAccountLogic.Verify(c => c.GetAllUserAccounts(), Times.Once);
        }

        [TestMethod]
        public void Test_ListAllUsersCommand_Returns_ListAllUsersCommand_WhenNotNull()
        {
            //ARRANGE
            WPFVMTests.ListAllUsersCommand = command.Object;

            //ACT
            var test = WPFVMTests.ListAllUsersCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_AddUserCommand_Returns_AddUserCommand_WhenNotNull()
        {
            //ACT
            WPFVMTests.addUserCommand = command.Object;

            //ARRANGE
            var test = WPFVMTests.addUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_EditUserCommand_Returns_EditUserCommand_WhenNotNull()
        {
            //ARRANGE
            WPFVMTests.editUserCommand = command.Object;

            //ACT
            var test = WPFVMTests.editUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_RemoveUserCommand_Returns_RemoveUserCommand_WhenNotNull()
        {
            //ARRANGE
            WPFVMTests.removeUserCommand = command.Object;

            //ACT
            var test = WPFVMTests.removeUserCommand;

            //ACT
            Assert.AreEqual(command.Object, test);
        }
    }
}
