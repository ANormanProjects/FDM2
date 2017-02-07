using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using System.Web.Mvc;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class GroupControllerTests
    {
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
