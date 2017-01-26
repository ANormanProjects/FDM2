using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using BudgieDatabaseLayer;
using BudgieLogic;
using ASP.NET.Budgie.Controllers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;

namespace BudgieUsersRepositoryTests
{
    [TestClass]
    public class HomeControllerTests
    {
        HomeController homeControllerTests;

        [TestInitialize]
        public void Setup()
        {
            homeControllerTests = new HomeController();
        }

        [TestMethod]
        public void Test_HomeControllerIndex_ReturnsIndexView()
        {
            //ARRANGE

            //ACT
            var action = homeControllerTests.Index() as ViewResult;

            //ASSERT
            Assert.AreEqual("Index", action.ViewName);
        }

        [TestMethod]
        public void Test_HomeControllerAbout_ReturnsAboutView()
        {
            //ARRANGE

            //ACT
            var action = homeControllerTests.About() as ViewResult;

            //ASSERT
            Assert.AreEqual("About", action.ViewName);
        }

        [TestMethod]
        public void Test_HomeControllerContact_ReturnsContactView()
        {
            //ARRANGE

            //ACT
            var action = homeControllerTests.Contact() as ViewResult;

            //ASSERT
            Assert.AreEqual("Contact", action.ViewName);
        }

        [TestMethod]
        public void Test_HomeControllerFAQ_ReturnsFAQView()
        {
            //ARRANGE

            //ACT
            var action = homeControllerTests.FAQ() as ViewResult;

            //ASSERT
            Assert.AreEqual("FAQ", action.ViewName);
        }

        [TestMethod]
        public void Test_HomeControllerCareers_ReturnsCareersView()
        {
            //ARRANGE

            //ACT
            var action = homeControllerTests.Careers() as ViewResult;

            //ASSERT
            Assert.AreEqual("Careers", action.ViewName);
        }

        [TestMethod]
        public void Test_HomeControllerAdminIndex_ReturnsAdminIndexView()
        {
            //ARRANGE

            //ACT
            var action = homeControllerTests.AdminIndex() as ViewResult;

            //ASSERT
            Assert.AreEqual("AdminIndex", action.ViewName);
        }


    }
}
