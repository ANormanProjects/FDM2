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
        Mock<Repository<Post>> postRepo; 
        Mock<Repository<User>> userRepo; 
        PostLogic postLogic; 

        [TestInitialize]
        public void Setup()
        {
            postRepo = new Mock<Repository<Post>>();
            userRepo = new Mock<Repository<User>>();
            postLogic = new PostLogic(postRepo.Object, userRepo.Object);

            postRepo.Setup(x => x.Insert(It.IsAny<Post>())).Verifiable();
        }

        [TestMethod]
        public void Test_WriteGroupPost_RunsAddRepositoryMethod()
        {
            //Arrange
            

            //Act
            postLogic.WriteGroupPost(1, "a", "b", "c", "d");

            //Assert
            postRepo.Verify(p => p.Insert(It.IsAny<Post>()), Times.Once);
        }

        [TestMethod]
        public void Test_WriteUserPost_RunsAddRepositoryMethod()
        {
            //Arrange
           

            //Act
            postLogic.WriteUserPost(1, "a", "b", "c", "d");

            //Assert
            postRepo.Verify(p => p.Insert(It.IsAny<Post>()), Times.Once);
        }
    }
}
