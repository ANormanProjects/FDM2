using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP.NET.Advancedv2;
using ASP.NET.Advancedv2.Controllers;
using System.Web.Mvc;
using Moq;
using System.Web;
using ASP.NET.Advancedv2.Models;

namespace ASPAdvancedDemo.Test
{
    [TestClass]
    public class BooksTest
    {
        [TestMethod]
        public void Test_Index_ReturnsIndexView()
        {
            //ARRANGE
            var expected = "Index";

            //ACT
            BooksController classUnderTest = new BooksController();
            var actual = classUnderTest.Index() as ViewResult;

            //ASSERT
            Assert.AreEqual(expected, actual.ViewName);

            ////Redirect to Action
            //var actual = classUnderTest.Index() as RedirectToRouteResult;
            //Assert.AreEqual("Index", actual.RouteValues["action"]);

            ////Partial view
            //var actual = classUnderTest.Index() as PartialViewResult;
            //Assert.AreEqual("Index", actual.ViewName);
        }

        [TestMethod]
        public void Test_Create_ReturnsSuccessPartialView_WhenRequestIsAjax()
        {
            //ARRANGE
            var mockRequest = new Mock<HttpRequestBase>(); //Request - 1
            mockRequest.Setup(x => x["X-Requested-With"]).Returns("XMLHttpRequest");

            var mockHttpContext = new Mock<HttpContextBase>(); //Request inside context - 2
            mockHttpContext.SetupGet(x => x.Request).Returns(mockRequest.Object);

            var controllerContext = new ControllerContext(); //Context inside controller - 3
            controllerContext.HttpContext = mockHttpContext.Object;

            BooksController classUnderTest = new BooksController(); //Controller Context inside of controller - 4
            classUnderTest.ControllerContext = controllerContext;

            Mock<Book> mockBook = new Mock<Book>();

            //Need to mock DB for this test to work



            //ACT
            var actual = classUnderTest.Create(mockBook.Object) as PartialViewResult;


            //ASSERT
            Assert.AreEqual("_Success", actual.ViewName);

        }
    }
}
