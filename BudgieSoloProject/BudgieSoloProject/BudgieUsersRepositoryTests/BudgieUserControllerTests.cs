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
        Mock<AccountLogic> accountLogicMock;

        [TestInitialize]
        public void Setup()
        {
            contextMock = new Mock<BudgieDBCFModel>();      
            accRepoMock = new Mock<AccountRepository>(contextMock.Object);
            buRepoMock = new Mock<BudgieUserRepository>(contextMock.Object);
            buLogicMock = new Mock<BudgieUserLogic>(buRepoMock.Object, accRepoMock.Object);
            accountLogicMock = new Mock<AccountLogic>(accRepoMock.Object);
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
            buLogicMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser>());

            //ACT
            var action = buControllerTests.ListOfAllBudgieUsers() as ViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.GetAllBudgieUsers());
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
        public void Test_BudgieUserControllerRegisterUserMethod_ReturnsRegisterUserPartialViewSuccess_AndIsAnAjaxRequest()
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
            var partialAction = buControllerTests.RegisterUser(bb.Object) as PartialViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
            Assert.AreEqual("_success", partialAction.ViewName);
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
        public void Test_BudgieUserControllerUpdateUserMethod_ReturnsUpdateUserPartialViewupdateSuccess_AndIsAnAjaxRequest()
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

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.firstName).Returns("Ben");
            bb.Setup(c => c.lastName).Returns("Bowes");
            bb.Setup(c => c.dob).Returns("010101");
            bb.Setup(c => c.emailAddress).Returns("benbowes@gmail.com");


            buLogicMock.Setup(c => c.CheckForDuplicateEmail(bb.Object.emailAddress)).Returns(true);
            buRepoMock.Setup(c => c.GetAllBudgieUsers()).Returns(new List<BudgieUser> { bb.Object });
            buRepoMock.Setup(c => c.updateBudgieUser(1, "Ben", "Bowes", "010101")).Verifiable();
            accRepoMock.Setup(c => c.updateNewAccount(1, "Bowes", "010101")).Verifiable();

            //ACT
            var partialAction = buControllerTests.UpdateUser(bb.Object) as PartialViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
            buRepoMock.Verify(c => c.GetAllBudgieUsers());
            buRepoMock.Verify(c => c.updateBudgieUser(1, "Ben", "Bowes", "010101"));
            accRepoMock.Verify(c => c.updateNewAccount(1, "Bowes", "010101"));
            Assert.AreEqual("_successUpdate", partialAction.ViewName);
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

        [TestMethod]
        public void Test_BudgieUserControllerRemoveUserMethod_ReturnsSuccessPartialViewWhenItIsAnAjaxRequest()
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

            bb.Setup(c => c.id).Returns(1);
            bb.Setup(c => c.emailAddress).Returns("benbowes@gmail.com");

            buLogicMock.Setup(c => c.CheckForDuplicateEmail(bb.Object.emailAddress)).Returns(true);
            buLogicMock.Setup(c => c.RemoveUser(bb.Object)).Verifiable();


            //ACT
            var partialAction = buControllerTests.RemoveUser(bb.Object) as PartialViewResult;

            //ASSERT
            buLogicMock.Verify(c => c.CheckForDuplicateEmail(bb.Object.emailAddress));
            buLogicMock.Verify(c => c.RemoveUser(bb.Object));
            Assert.AreEqual("_successRemove", partialAction.ViewName);

        }

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