using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class PostLogicTests
    {
        [TestMethod]
        public void Test_WriteGroupPost_RunsAddRepositoryMethod()
        {
            //Arrange
            Mock<Repository<Post>> postRepo = new Mock<Repository<Post>>();
            Mock<Repository<User>> userRepo = new Mock<Repository<User>>();
            PostLogic postLogic = new PostLogic(postRepo.Object, userRepo.Object);

            postRepo.Setup(x => x.Insert(It.IsAny<Post>())).Verifiable();

            //Act
            postLogic.WriteGroupPost(1, "a", "b", "c", "d");

            //Assert
            postRepo.Verify(p => p.Insert(It.IsAny<Post>()), Times.Once);
        }

        []
    }
}
