using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.Logic;
using Moq;
using SocialNetwork.DataAccess;

namespace SocialNetwork.Tests
{
    //---------- Testing the HomeController ----------//

    [TestClass]
    public class WebUITests
    {
        [TestMethod]
        public void Test_IndexInHomeFolder_ReturnsIndexView()
        {
            var expected = "Index";

            HomeController classUnderTest = new HomeController();

            var actual = classUnderTest.Index() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        //---------- Testing the AccountController----------//

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
            var userRep = new Repository<User>();
            var mockUserAccountLogic = new Mock<UserAccountLogic>(userRep);

            User existingUser = new User();
            existingUser.username = "tomjones";
            existingUser.password = "delilah";
            mockUserAccountLogic.Setup(x => x.Register(existingUser));

            
            User user = new User();
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
            var userRep = new Repository<User>();
            var mockUserAccountLogic = new Mock<UserAccountLogic>(userRep);

            User user = new User();
            user.username = "tomjones";
            user.password = "unusual";
            string returnUrl = "Account/Login";
            var expected = "Error";

            AccountController classUnderTest = new AccountController(mockUserAccountLogic.Object);
            mockUserAccountLogic.Setup(s => s.Login(user.username, user.password)).Returns(false);
            var actual = classUnderTest.Login(user, returnUrl) as PartialViewResult;

            Assert.AreEqual(expected, actual);
            
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
            Mock<User> mockUser = new Mock<User>();
            Mock<Repository<User>> mockUserRepository = new Mock<Repository<User>>();
            mockUser.Object.fullName = null;
            Mock<UserAccountLogic> userAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);
            var expected = "_FieldNotFilled";

            //Act
            AccountController classunderTest = new AccountController(userAccountLogic.Object);
            var actual = classunderTest.Register(mockUser.Object) as PartialViewResult;

            //Assert
            Assert.AreEqual(expected,actual.ViewName);
        }

        [TestMethod]
        public void Test_RegisterInAccounts_UserFullNameIsValid_ReturnsUserAlreadyExistsPartialView()
        {
            //Arrange
            Mock<User> mockUser = new Mock<User>();
            Mock<Repository<User>> mockUserRepository = new Mock<Repository<User>>();
            mockUser.Setup(s => s.fullName).Returns("Donald Donaldson");
            mockUser.Setup(s => s.password).Returns("password");
            mockUser.Setup(s => s.username).Returns("Don");
            mockUser.Setup(s => s.gender).Returns("male");
            Mock<UserAccountLogic> userAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);
            userAccountLogic.Setup(s => s.CheckForDuplicates(mockUser.Object)).Returns(true);
            
            var expected = "_UserAlreadyExists";

            //Act
            AccountController classunderTest = new AccountController(userAccountLogic.Object);

            var actual = classunderTest.Register(mockUser.Object) as PartialViewResult;

            //Assert
            Assert.AreEqual(expected, actual.ViewName);
        }

        //---------- Testing the CodeWallController ----------//

        [TestMethod]
        public void Test_WallInCodeWall_ReturnsWallView()
        {
            var expected = "Wall";

            CodeWallController classUnderTest = new CodeWallController();

            var actual = classUnderTest.Wall() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        //---------- Testing the SearchController ----------//

        [TestMethod]
        public void Test_ResultsInSearchResults_ReturnsResultsView()
        {
            var expected = "Results";

            SearchController classUnderTest = new SearchController();

            var actual = classUnderTest.Results() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        //---------- Testing the SettingsController ----------//

        [TestMethod]
        public void Test_SettingsPageInSettings_ReturnsSettingsPageView()
        {
            var expected = "SettingsPage";

            SettingsController classUnderTest = new SettingsController();

            var actual = classUnderTest.SettingsPage() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        //---------- Testing the GroupController ----------//

        [TestMethod]
        public void Test_GroupPostsInGroups_ReturnGroupPostsView()
        {
            var expected = "GroupPosts";

            GroupController classUnderTest = new GroupController();

            var actual = classUnderTest.GroupPosts() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }
    }
}
