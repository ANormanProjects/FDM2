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


namespace BudgieUsersRepositoryTests
{
    [TestClass]
    public class BudgieUserControllerTests
    {
        BudgieUserController buControllerTests;

        [TestInitialize]
        public void Setup()
        {
            buControllerTests = new BudgieUserController();
        }

        [TestMethod]
        public void Test_BudgieUserControllerIndex_ReturnsIndexView()
        {
            //ARRANGE

            //ACT
            var action = buControllerTests.Index() as ViewResult;

            //ASSERT
            Assert.AreEqual("Index", action.ViewName);
        }
    }
}
