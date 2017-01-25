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
    public class BudgieUserControllerTests
    {
        BudgieUserController buControllerTests;
        Mock<BudgieDBCFModel> contextMock;
        Mock<BudgieUserLogic> buLogicMock;
        Mock<BudgieUserRepository> buRepoMock;
        Mock<AccountRepository> accRepoMock;

        [TestInitialize]
        public void Setup()
        {
            contextMock = new Mock<BudgieDBCFModel>();      
            accRepoMock = new Mock<AccountRepository>(contextMock.Object);
            buRepoMock = new Mock<BudgieUserRepository>(contextMock.Object);
            buLogicMock = new Mock<BudgieUserLogic>(buRepoMock.Object, accRepoMock.Object);
            buControllerTests = new BudgieUserController(buLogicMock.Object);
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

        [TestMethod]
        public void Test_BudgieUserControllerListOfAllBudgieUsers_ReturnsListOfAllBudgieUsersView()
        {
            //ARRANGE

            //ACT
            var action = buControllerTests.ListOfAllBudgieUsers() as ViewResult;

            //ASSERT
            Assert.AreEqual("ListOfAllBudgieUsers", action.ViewName);
        }
        
        [TestMethod]
        public void Test_BudgieUserControllerRegisterUser_ReturnsRegisterUserView()
        {
            //ARRANGE
            

            //ACT
            var action = buControllerTests.RegisterUser() as ViewResult;

            //ASSERT
            Assert.AreEqual("RegisterUser", action.ViewName);

        }

        [TestMethod]
        public void Test_BudgieUserControllerRegisterUserMethod_ReturnsRegisterUserPartialViewFailure_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            buControllerTests.ControllerContext = controllerCtx;

            Mock<BudgieUser> bb = new Mock<BudgieUser>();

            buLogicMock.Setup(c => c.CheckForDuplicateEmail(bb.Object.emailAddress)).Returns(true);

            //ACT
            var partialAction = buControllerTests.RegisterUser(bb.Object) as PartialViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
            Assert.AreEqual("_failure", partialAction.ViewName);
        }

        [TestMethod]
        public void Test_BudgieUserControllerRegisterUserMethod_ReturnsRegisterUserPartialViewFailure_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            buControllerTests.ControllerContext = controllerCtx;

            Mock<BudgieUser> bb = new Mock<BudgieUser>();

            buLogicMock.Setup(c => c.CheckForDuplicateEmail(bb.Object.emailAddress)).Returns(true);

            //ACT
            var partialAction = buControllerTests.RegisterUser(bb.Object) as PartialViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
            Assert.AreEqual("_failure", partialAction.ViewName);
        }

        [TestMethod]
        public void Test_BudgieUserControllerUpdateUserMethod_ReturnsUpdateUserPartialViewupdateFailure_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            buControllerTests.ControllerContext = controllerCtx;

            Mock<BudgieUser> bb = new Mock<BudgieUser>();

            buLogicMock.Setup(c => c.CheckForDuplicateEmail(bb.Object.emailAddress)).Returns(false);

            //ACT
            var partialAction = buControllerTests.UpdateUser(bb.Object) as PartialViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
            Assert.AreEqual("_failureUpdate", partialAction.ViewName);
        }

        [TestMethod]
        public void Test_BudgieUserControllerRemoveUserMethod_ReturnsRemoveUserPartialViewremoveFailure_AndIsAnAjaxRequest()
        {
            //ARRANGE
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);

            var controllerCtx = new ControllerContext();
            controllerCtx.HttpContext = mockHttpContext.Object;

            buControllerTests.ControllerContext = controllerCtx;

            Mock<BudgieUser> bb = new Mock<BudgieUser>();

            buLogicMock.Setup(c => c.CheckForDuplicateEmail(bb.Object.emailAddress)).Returns(false);

            //ACT
            var partialAction = buControllerTests.RemoveUser(bb.Object) as PartialViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
            Assert.AreEqual("_failureRemove", partialAction.ViewName);
        }

        //[TestMethod]
        //public void Test_BudgieUserControllerRegisterUserMethod_ReturnsSuccessPartialViewWhenItIsAnAjaxRequest()
        //{
        //    //ARRANGE
        //    var mockRequest = new Mock<HttpRequestBase>();
        //    mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

        //    var mockHttpContext = new Mock<HttpContextBase>();
        //    mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);

        //    var controllerCtx = new ControllerContext();
        //    controllerCtx.HttpContext = mockHttpContext.Object;

        //    Mock<BudgieUser> bb = new Mock<BudgieUser>();

        //    buLogicMock.Setup(c => c.CheckForDuplicateEmail(bb.Object.emailAddress)).Verifiable();

        //    //ACT
        //    var partialAction = buControllerTests.RegisterUser(bb.Object) as PartialViewResult;

        //    //ASSERT
        //    buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
        //    Assert.AreEqual("_success", partialAction.ViewName);

        //}

        [TestMethod]
        public void Test_BudgieUserControllerUpdateUser_ReturnsUpdateUserView()
        {
            //ARRANGE

            //ACT
            var action = buControllerTests.UpdateUser() as ViewResult;

            //ASSERT
            Assert.AreEqual("UpdateUser", action.ViewName);
        }

        [TestMethod]
        public void Test_BudgieUserControllerRemoveUser_ReturnsRemoveUserView()
        {
            //ARRANGE

            //ACT
            var action = buControllerTests.RemoveUser() as ViewResult;

            //ASSERT
            Assert.AreEqual("RemoveUser", action.ViewName);
        }

        [TestMethod]
        public void Test_BudgieUserControllerLogin_ReturnsLoginView()
        {
            //ARRANGE

            //ACT
            var action = buControllerTests.Login() as ViewResult;

            //ASSERT
            Assert.AreEqual("Login", action.ViewName);
        }

        //[TestMethod]
        //public void Test_BudgieUserControllerLogOff_ReturnsRedirectToRouteResult()
        //{
        //    //ARRANGE
        //    Mock<FormsAuthentication> formsAuthMock = new Mock<FormsAuthentication>();
        //    //ACT
        //    var action = buControllerTests.LogOff() as RedirectToRouteResult;

        //    //ASSERT
        //    Assert.AreEqual("Index", action.RouteValues["action"]);
        //}
    }
}