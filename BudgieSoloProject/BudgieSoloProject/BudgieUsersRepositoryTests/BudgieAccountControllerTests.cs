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
    public class BudgieAccountControllerTests
    {
        BudgieAccountController accControllerTests;
        Mock<BudgieDBCFModel> contextMock;
        Mock<AccountLogic> accLogicMock;
        Mock<BudgieUserRepository> buRepoMock;
        Mock<AccountRepository> accRepoMock;

        [TestInitialize]
        public void setup()
        {
            contextMock = new Mock<BudgieDBCFModel>();
            accRepoMock = new Mock<AccountRepository>(contextMock.Object);
            buRepoMock = new Mock<BudgieUserRepository>(contextMock.Object);
            accLogicMock = new Mock<AccountLogic>(accRepoMock.Object);
            accControllerTests = new BudgieAccountController(accLogicMock.Object);
        }

        [TestMethod]
        public void Test_AccountControllerIndex_ReturnsIndexView()
        {
            //ARRANGE

            //ACT
            var action = accControllerTests.Index() as ViewResult;

            //ASSERT
            Assert.AreEqual("Index", action.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerOverview_ReturnsOverviewView()
        {
            //ARRANGE

            //ACT
            var action = accControllerTests.Overview() as ViewResult;

            //ASSERT
            Assert.AreEqual("Overview", action.ViewName);
        }

    }
}
