using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.MVVM.ViewModel;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class MVVMTests
    {

        Mock<Repository<User>> userRepo;
        Mock<UserAccountLogic> userAccountLogic;
        ObservableCollection<User> userList;
        WPFViewModel WPFVMTests;
        Mock<ICommand> command;
        Mock<User> testUser;

        [TestInitialize]
        public void Setup()
        {
            userRepo = new Mock<Repository<User>>();
            userAccountLogic = new Mock<UserAccountLogic>(userRepo.Object);
            WPFVMTests = new WPFViewModel(userAccountLogic.Object);
            userList = new ObservableCollection<User>();
            command = new Mock<ICommand>();
            testUser = new Mock<User>();

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

            List<User> newUserList = new List<User>();
            userAccountLogic.Setup(c => c.GetAllUserAccounts()).Returns(newUserList);
            WPFVMTests.userAccLogic = userAccountLogic.Object;

            //ACT
            WPFVMTests.ListAllUsers();

            //ASSERT
            userAccountLogic.Verify(c => c.GetAllUserAccounts(), Times.Once);
            CollectionAssert.AreEquivalent(WPFVMTests.user, newUserList);
        }

        
        [TestMethod]
        public void Test_Add_UserMethod_RunsRegisterMethodWhenCalledToAddNewUserToTheDatabaseFromWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.Register(It.IsAny<User>()));
            WPFVMTests.userAccLogic = userAccountLogic.Object;

            //ACT
            WPFVMTests.Add();

            //ASSERT
            userAccountLogic.Verify(c => c.Register(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void Test_Edit_UserMethod_RunsEditMethodWhenCalledToEditExistingUserInTheDatabaseFromWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.ViewAccountInfo("Test")).Returns(testUser.Object);
            userAccountLogic.Setup(c => c.EditUser(testUser.Object, "Test", "Test", "Test", "Test"));
            WPFVMTests.userAccLogic = userAccountLogic.Object;
            WPFVMTests.username = "Test";
            WPFVMTests.fullName = "Test";
            WPFVMTests.gender = "Test";
            WPFVMTests.role = "Test";
            WPFVMTests.password = "Test";

            //ACT
            WPFVMTests.Edit();

            //ASSERT
            userAccountLogic.Verify(c => c.ViewAccountInfo("Test"));
            userAccountLogic.Verify(c => c.EditUser(testUser.Object, "Test", "Test", "Test", "Test"));
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EditWPFMethod_ThrowsEntityNotFoundException_WhenUsernameIsNotInDatabase()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.ViewAccountInfo("Test")).Throws(new EntityNotFoundException());
            WPFVMTests.username = "Test";
            //ACT
            WPFVMTests.Edit();
        }

        [TestMethod]
        public void Test_Remove_UserMethod_RunsRemoveMethodWhenCalledToRemoveExisitingUserInTheDatabaseFromWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.ViewAccountInfo("Test")).Returns(testUser.Object);
            userAccountLogic.Setup(c => c.RemoveUser(testUser.Object));
            WPFVMTests.userAccLogic = userAccountLogic.Object;
            WPFVMTests.username = "Test";


            //ACT
            WPFVMTests.Remove();

            //ASSERT
            userAccountLogic.Verify(c => c.ViewAccountInfo("Test"));
            userAccountLogic.Verify(c => c.RemoveUser(testUser.Object));
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
