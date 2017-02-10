using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using System.Web.Mvc;
using SocialNetwork.DataAccess;
using Moq;
using SocialNetwork.Logic;
using SocialNetwork.WebUI.Models;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        Repository<User> userRep;
        Mock<UserAccountLogic> mockUserAccountLogic;
        User existingUser;
        User user;
        Mock<User> mockUser;
        Mock<Repository<User>> mockUserRepository;

        [TestInitialize]
        public void Setup()
        {
            userRep = new Repository<User>();
            mockUserAccountLogic = new Mock<UserAccountLogic>(userRep);
            existingUser = new User();
            user = new User();
            mockUser = new Mock<User>();
            mockUserRepository = new Mock<Repository<User>>();
        }

        [TestMethod]
        public void Test_ProfilePageInAccounts_ReturnsProfilePageView()
        {
            var expected = "ProfilePage";

            AccountController classUnderTest = new AccountController();

            var actual = classUnderTest.ProfilePage() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void Test_LoginInAccounts_ReturnsLoginView()
        {
            var expected = "Login";

            AccountController classUnderTest = new AccountController();

            var actual = classUnderTest.Login() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void Test_LoginInAccounts_CallsLoginMethod()
        {
            existingUser.username = "tomjones";
            existingUser.password = "delilah";
            mockUserAccountLogic.Setup(x => x.Register(existingUser));

            user.username = "tomjones";
            user.password = "delilah";
            string returnUrl = "ProfilePage";

            AccountController classUnderTest = new AccountController(mockUserAccountLogic.Object);

            mockUserAccountLogic.Setup(s => s.Login(user.username, user.password)).Returns(false);

            classUnderTest.Login(user, returnUrl);

            mockUserAccountLogic.Verify(r => r.Login(user.username, user.password), Times.Once);
        }

        [TestMethod]
        public void Test_LoginInAccounts_ReturnsModelError_WhenWrongInfoIsGiven()
        {
            mockUser.Object.fullName = null;
            Mock<UserAccountLogic> mockUserAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);
            mockUser.Setup(s => s.fullName).Returns("Donald Donaldson");
            mockUser.Setup(s => s.password).Returns("password");
            mockUser.Setup(s => s.username).Returns("Don");
            mockUser.Setup(s => s.gender).Returns("male");


            string returnUrl = "Account/Login";
            string expected = "Login";

            AccountController classUnderTest = new AccountController(mockUserAccountLogic.Object);
            mockUserAccountLogic.Setup(s => s.Login(mockUser.Object.username, mockUser.Object.password)).Returns(false);
            var actual = classUnderTest.Login(mockUser.Object, returnUrl) as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void Test_RegisterInAccounts_ReturnsRegisterView()
        {
            var expected = "Register";

            AccountController classUnderTest = new AccountController();

            var actual = classUnderTest.Register() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void Test_RegisterInAccounts_UserFullNameIsNull_ReturnsFieldNotFilledPartialView()
        {
            //Arrange
            mockUser.Object.fullName = null;
            Mock<UserAccountLogic> MockUserAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);
            var expected = "_FieldNotFilled";

            //Act
            AccountController classUnderTest = new AccountController(MockUserAccountLogic.Object);
            var actual = classUnderTest.Register(new UserRegisterViewModel() { user = mockUser.Object }) as PartialViewResult;

            //Assert
            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void Test_RegisterInAccounts_UserFullNameIsValid_ReturnsAccountCreatedPartialView()
        {
            //Arrange
            mockUser.Setup(s => s.fullName).Returns("Donald Donaldson");
            mockUser.Setup(s => s.password).Returns("password");
            mockUser.Setup(s => s.username).Returns("Don");
            mockUser.Setup(s => s.gender).Returns("male");
            Mock<UserAccountLogic> mockUserAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);
            mockUserAccountLogic.Setup(s => s.CheckForDuplicates(mockUser.Object)).Returns(false);

            var expected = "_AccountCreated";

            //Act
            AccountController classUnderTest = new AccountController(mockUserAccountLogic.Object);

            var actual = classUnderTest.Register(new UserRegisterViewModel() { user = mockUser.Object }) as PartialViewResult;

            //Assert
            Assert.AreEqual(expected, actual.ViewName);
        }
    }
}
