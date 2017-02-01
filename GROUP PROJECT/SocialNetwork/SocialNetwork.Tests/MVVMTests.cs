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
        ListAllUsersViewModel listAllUsersVMTests;

        [TestInitialize]
        public void Setup()
        {
            userRepo = new Mock<Repository<User>>();
            userAccountLogic = new Mock<UserAccountLogic>(userRepo.Object);
            listAllUsersVMTests = new ListAllUsersViewModel(userAccountLogic.Object);
            userList = new List<User>();

        }

        [TestMethod]
        public void Test_ListAllUsersViewModelConstructor()
        {
            //ARRANGE
            ListAllUsersViewModel listAllUsersVM = new ListAllUsersViewModel();
            //ACT

            //ASSERT
            Assert.IsNotNull(listAllUsersVM._userRepository);
            Assert.IsNotNull(listAllUsersVM.userAccLogic);
        }

        [TestMethod]
        public void Test_ListOfAllUsers_RunsGetAllUsersToDisplayListToWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.GetAllUserAccounts()).Returns(userList);

            //ACT
            listAllUsersVMTests.ListAllUsers();

            //ASSERT
            userAccountLogic.Verify(c => c.GetAllUserAccounts(), Times.Once);
        }
    }
}
