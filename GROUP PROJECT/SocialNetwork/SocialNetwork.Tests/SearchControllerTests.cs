using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using System.Web.Mvc;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class SearchControllerTests
    {
        [TestMethod]
        public void Test_ResultsInSearchResults_ReturnsResultsView()
        {
            var expected = "Results";

            SearchController classUnderTest = new SearchController();

            var actual = classUnderTest.Search() as ViewResult;

            Assert.AreEqual(expected, actual.ViewName);
        }
    }
}
