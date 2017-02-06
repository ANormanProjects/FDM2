using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using System.Web.Mvc;
using SocialNetwork.Logic;
using Moq;
using SocialNetwork.DataAccess;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class WebUITestsCodeWall
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
