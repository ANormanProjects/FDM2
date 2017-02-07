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
using System.Web.Security;

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

        ////[TestMethod]
        //public void Test_LoginInAccounts_RedirectsToActionProfilePage()
        //{
        //    Mock<User> mockUser = new Mock<User>();
        //    Mock<Repository<User>> mockUserRepository = new Mock<Repository<User>>();
        //    Mock<UserAccountLogic> mockUserAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);

        //    User existingUser = new User();
        //    existingUser.username = "tomjones";
        //    existingUser.password = "delilah";
        //    mockUserAccountLogic.Setup(x => x.Register(existingUser));

        //    User user = new User();
        //    user.username = "tomjones";
        //    user.password = "delilah";
        //    string returnUrl = "a";

        //    mockUser.Object.fullName = null;

        //    var expected = "ProfilePage";

        //    //Act
        //    AccountController classUnderTest = new AccountController(mockUserAccountLogic.Object);
        //    var actual = classUnderTest.Login(user, returnUrl) as RedirectToRouteResult;


        //    //Assert
        //    Assert.AreEqual("ProfilePage", actual.RouteValues["action"]);
        //}

        [TestMethod]
        public void Test_LoginInAccounts_ReturnsModelError_WhenWrongInfoIsGiven()
        {
            Mock<User> mockUser = new Mock<User>();
            Mock<Repository<User>> mockUserRepository = new Mock<Repository<User>>();
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

        //[TestMethod]
        //public void Test_LogOffInAccounts_RedirectsToIndex()
        //{
        //    var userRep = new Repository<User>();
        //    Mock<UserAccountLogic> mockUserAccountLogic = new Mock<UserAccountLogic>(userRep);
        //    AccountController classUnderTest = new AccountController(mockUserAccountLogic.Object);
            
        //    var actual = classUnderTest.LogOff() as RedirectToRouteResult;

        //    Assert.AreEqual("Index", actual.RouteValues["action"]);
        //}

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
            Mock<UserAccountLogic> MockUserAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);
            var expected = "_FieldNotFilled";

            //Act
            AccountController classUnderTest = new AccountController(MockUserAccountLogic.Object);
            var actual = classUnderTest.Register(mockUser.Object) as PartialViewResult;

            //Assert
            Assert.AreEqual(expected,actual.ViewName);
        }

        [TestMethod]
        public void Test_RegisterInAccounts_UserFullNameIsValid_ReturnsAccountCreatedPartialView()
        {
            //Arrange
            Mock<User> mockUser = new Mock<User>();
            Mock<Repository<User>> mockUserRepository = new Mock<Repository<User>>();
            mockUser.Setup(s => s.fullName).Returns("Donald Donaldson");
            mockUser.Setup(s => s.password).Returns("password");
            mockUser.Setup(s => s.username).Returns("Don");
            mockUser.Setup(s => s.gender).Returns("male");
            Mock<UserAccountLogic> mockUserAccountLogic = new Mock<UserAccountLogic>(mockUserRepository.Object);
            mockUserAccountLogic.Setup(s => s.CheckForDuplicates(mockUser.Object)).Returns(false);

            var expected = "_AccountCreated";

            //Act
            AccountController classUnderTest = new AccountController(mockUserAccountLogic.Object);

            var actual = classUnderTest.Register(mockUser.Object) as PartialViewResult;

            //Assert
            Assert.AreEqual(expected, actual.ViewName);
        }

        //---------- Testing the CodeWallController ----------//

        //[TestMethod]
        //public void Test_WallInCodeWall_ReturnsWallView()
        //{
        //    var expected = "Wall";

        //    CodeWallController classUnderTest = new CodeWallController();

        //    var actual = classUnderTest.Wall() as ViewResult;

        //    Assert.AreEqual(expected, actual.ViewName);
        //}

        //---------- Testing the SearchController ----------//

        //[TestMethod]
        //public void Test_ResultsInSearchResults_ReturnsResultsView()
        //{
        //    var expected = "Results";

        //    SearchController classUnderTest = new SearchController();

        //    var actual = classUnderTest.Results() as ViewResult;

        //    Assert.AreEqual(expected, actual.ViewName);
        //}

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
        public void Test_GroupListInGroups_ReturnGroupListView()
        {
            var expected = "GroupList";

            GroupController classUnderTest = new GroupController();

            var actual = classUnderTest.GroupList() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void Test_GroupProfileInGroups_ReturnGroupProfileView()
        {
            var expected = "GroupProfile";

            GroupController classUnderTest = new GroupController();

            var actual = classUnderTest.GroupProfile() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }
    }
}
