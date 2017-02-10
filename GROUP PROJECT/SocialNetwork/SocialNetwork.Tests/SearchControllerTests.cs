using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using System.Web.Mvc;
using SocialNetwork.WebUI.Models;
using System.Collections.Generic;
using SocialNetwork.Logic;
using SocialNetwork.DataAccess;
using Moq;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class SearchControllerTests
    {
        [TestMethod]
        public void Test_Search_ReturnsResultsView()
        {
            var expected = "Results";

            SearchController classUnderTest = new SearchController();

            var actual = classUnderTest.Search() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }

        // Can't test the rest due to FormsAuthentification
    }
}
