using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.DataAccess;
using Moq;
using SocialNetwork.Logic;
using SocialNetwork.WebUI.Controllers;
using System.Web.Mvc;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class SettingsControllerTests
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
        public void Test_SettingsPageInSettings_ReturnsSettingsPageView()
        {
            var expected = "SettingsPage";

            SettingsController classUnderTest = new SettingsController();

            var actual = classUnderTest.SettingsPage() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
    }
}
