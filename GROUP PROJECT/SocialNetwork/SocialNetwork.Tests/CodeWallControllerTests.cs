using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using SocialNetwork.Logic;
using Moq;
using SocialNetwork.DataAccess;
using System.Web.Mvc;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class CodeWallControllerTests
    {
        CodeWallController classUnderTest;
        Mock<UserAccountLogic> userAccountLogic;
        Mock<Repository<User>> userRepo;
        Mock<PostLogic> postLogic;
        Mock<Repository<Comment>> commentRepo;
        Mock<Repository<Group>> groupRepo;
        Mock<Repository<Post>> postRepo;

        [TestInitialize]
        public void Setup()
        {
            commentRepo = new Mock<Repository<Comment>>();
            postRepo = new Mock<Repository<Post>>();
            postLogic = new Mock<PostLogic>(postRepo.Object, commentRepo.Object);
            classUnderTest = new CodeWallController(postLogic.Object);
            userRepo = new Mock<Repository<User>>();

            userAccountLogic = new Mock<UserAccountLogic>(userRepo.Object);

        }

        //---------- Testing the CodeWallController ----------//

        [TestMethod]
        public void Test_WallInCodeWall_ReturnsWallView()
        {
            //arr
            var expected = "Wall";

            //act
            var actual = classUnderTest.Wall() as ViewResult;

            //ass
            Assert.AreEqual(expected, actual.ViewName);
        }
    }
}
