using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.MVVM.ViewModel;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System.Collections.Generic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class MVVMTests
    {

        Mock<Repository<User>> userRepo;
        Mock<UserAccountLogic> userAccountLogic;
        List<User> userList;
        WPFViewModel WPFVMTests;

        [TestInitialize]
        public void Setup()
        {
            userRepo = new Mock<Repository<User>>();
            userAccountLogic = new Mock<UserAccountLogic>(userRepo.Object);
            WPFVMTests = new WPFViewModel(userAccountLogic.Object);
            userList = new List<User>();

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
    }
}
