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
using System.Security.Principal;

namespace BudgieUsersRepositoryTests
{
    [TestClass]
    public class BudgieAccountControllerTests
    {
        BudgieAccountController accControllerTests;
        Mock<BudgieDBCFModel> contextMock;
        Mock<AccountLogic> accLogicMock;
        Mock<BudgieUserLogic> buLogicMock;
        Mock<BudgieUserRepository> buRepoMock;
        Mock<AccountRepository> accRepoMock;
        Mock<BudgieUser> bb;
        Mock<Account> bbacc;
        Mock<Account> bbacc2;

        [TestInitialize]
        public void setup()
        {
            contextMock = new Mock<BudgieDBCFModel>();
            accRepoMock = new Mock<AccountRepository>(contextMock.Object);
            buRepoMock = new Mock<BudgieUserRepository>(contextMock.Object);
            accLogicMock = new Mock<AccountLogic>(accRepoMock.Object);
            buLogicMock = new Mock<BudgieUserLogic>(buRepoMock.Object);
            accControllerTests = new BudgieAccountController(accLogicMock.Object,buLogicMock.Object);
            bb = new Mock<BudgieUser>();
            bb.SetupGet(b => b.emailAddress).Returns("User");
            bbacc = new Mock<Account>();
            bbacc2 = new Mock<Account>();
        }

        [TestMethod]
        public void Test_AccountControllerConstructor()
        {
            //ARRANGE
            BudgieAccountController buAccController = new BudgieAccountController();
            //ACT

            //ASSERT
            Assert.IsNotNull(buAccController.accLogic);
            Assert.IsNotNull(buAccController.buLogic);
            Assert.IsNotNull(buAccController.accountRepo);
            Assert.IsNotNull(buAccController.userRepo);

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
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.User).Returns(principal);

            var mockControllerCtx = new Mock<ControllerContext>();
            mockControllerCtx.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            accControllerTests.ControllerContext = mockControllerCtx.Object;

            Mock<BudgieUser> bb = new Mock<BudgieUser>();
            Mock<Account> bbacc = new Mock<Account>();

            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            accLogicMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbacc.Object });

            //ACT
            var action = accControllerTests.Overview() as ViewResult;

            //ASSERT
            Assert.AreEqual("Overview", action.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerDeposit_ReturnsDepositView()
        {
            //ARRANGE

            //ACT
            var action = accControllerTests.Deposit() as ViewResult;

            //ASSERT
            Assert.AreEqual("Deposit", action.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerDepositMethod_ReturnsDepositPartialView_successDeposit_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.User).Returns(principal);

            var mockControllerCtx = new Mock<ControllerContext>();
            mockControllerCtx.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            accControllerTests.ControllerContext = controllerCtx;
            //accControllerTests.ControllerContext = mockControllerCtx.Object;

            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            accLogicMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbacc.Object });
            accLogicMock.Setup(c => c.depositMoney(1, 100)).Verifiable();

            //ACT
            var partialAction = accControllerTests.Deposit(bbacc.Object) as PartialViewResult;

            //ASSERT
            Assert.AreEqual("_successDeposit", partialAction.ViewName);

            
        }

        [TestMethod]
        public void Test_AccountControllerWithdraw_ReturnsWithdrawView()
        {
            //ARRANGE

            //ACT
            var action = accControllerTests.Withdraw() as ViewResult;

            //ASSERT
            Assert.AreEqual("Withdraw", action.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerWithdrawMethod_ReturnsWithdrawPartialView_successWithdraw_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.User).Returns(principal);

            var mockControllerCtx = new Mock<ControllerContext>();
            mockControllerCtx.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            accControllerTests.ControllerContext = controllerCtx;
            //accControllerTests.ControllerContext = mockControllerCtx.Object;

            bbacc.Setup(c => c.id).Returns(1);
            bbacc.Setup(c => c.balance).Returns(100);

            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            accLogicMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbacc.Object });
            accLogicMock.Setup(c => c.withdrawMoney(1, 100)).Returns(true);

            //ACT
            var partialAction = accControllerTests.Withdraw(bbacc.Object) as PartialViewResult;

            //ASSERT
            Assert.AreEqual("_successWithdraw", partialAction.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerWithdrawMethod_ReturnsWithdrawPartialView_failureWithdraw_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.User).Returns(principal);

            var mockControllerCtx = new Mock<ControllerContext>();
            mockControllerCtx.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            accControllerTests.ControllerContext = controllerCtx;
            //accControllerTests.ControllerContext = mockControllerCtx.Object;

            bbacc.Setup(c => c.id).Returns(1);

            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            accLogicMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbacc.Object });
            accLogicMock.Setup(c => c.withdrawMoney(1, 100)).Returns(false);

            //ACT
            var partialAction = accControllerTests.Withdraw(bbacc.Object) as PartialViewResult;

            //ASSERT
            Assert.AreEqual("_failureWithdraw", partialAction.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerBudget_ReturnsBudgetView()
        {
            //ARRANGE

            //ACT
            var action = accControllerTests.Budget() as ViewResult;

            //ASSERT
            Assert.AreEqual("Budget", action.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerBudgetMethod_ReturnsBudgetPartialView_successBudget_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.User).Returns(principal);

            var mockControllerCtx = new Mock<ControllerContext>();
            mockControllerCtx.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            accControllerTests.ControllerContext = controllerCtx;
            //accControllerTests.ControllerContext = mockControllerCtx.Object;

            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            accLogicMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbacc.Object });
            accLogicMock.Setup(c => c.setBudget(1, 100)).Verifiable();

            //ACT
            var partialAction = accControllerTests.Budget(bbacc.Object) as PartialViewResult;

            //ASSERT
            
            Assert.AreEqual("_successBudget", partialAction.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerTransfer_ReturnsTransferView()
        {
            //ARRANGE

            //ACT
            var action = accControllerTests.Transfer() as ViewResult;

            //ASSERT
            Assert.AreEqual("Transfer", action.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerTransferMethod_ReturnsTransferPartialView_successTransfer_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.User).Returns(principal);

            var mockControllerCtx = new Mock<ControllerContext>();
            mockControllerCtx.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            accControllerTests.ControllerContext = controllerCtx;
            //accControllerTests.ControllerContext = mockControllerCtx.Object;

            bbacc.Setup(c => c.balance).Returns(100);

            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            accLogicMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbacc.Object });
            accLogicMock.Setup(c => c.transferMoney(0, 0, 100)).Returns(true);

            //ACT
            var partialAction = accControllerTests.Transfer(bbacc.Object) as PartialViewResult;

            //ASSERT
            Assert.AreEqual("_successTransfer", partialAction.ViewName);
        }

        [TestMethod]
        public void Test_AccountControllerTransferMethod_ReturnsTransferPartialView_failureTransfer_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.User).Returns(principal);

            var mockControllerCtx = new Mock<ControllerContext>();
            mockControllerCtx.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            accControllerTests.ControllerContext = controllerCtx;
            //accControllerTests.ControllerContext = mockControllerCtx.Object;

            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            accLogicMock.Setup(c => c.GetAllAccounts()).Returns(new List<Account> { bbacc.Object });
            accLogicMock.Setup(c => c.transferMoney(1, 1, 100)).Returns(false);

            //ACT
            var partialAction = accControllerTests.Transfer(bbacc.Object) as PartialViewResult;

            //ASSERT
            Assert.AreEqual("_failureTransfer", partialAction.ViewName);
        }


    }
}
