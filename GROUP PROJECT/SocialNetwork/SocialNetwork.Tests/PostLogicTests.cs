using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System.Collections.Generic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class PostLogicTests
    {
        Mock<Repository<Post>> postRepo; 
        Mock<Repository<User>> userRepo; 
        PostLogic postLogic; 
        Mock<User> user;
        Mock<User> friend;

        [TestInitialize]
        public void Setup()
        {
            postRepo = new Mock<Repository<Post>>();
            userRepo = new Mock<Repository<User>>();
            postLogic = new PostLogic(postRepo.Object, userRepo.Object);
            user = new Mock<User>();
            friend = new Mock<User>();

            postRepo.Setup(x => x.Insert(It.IsAny<Post>())).Verifiable();
            user.Setup(f => f.friends).Returns(new List<User>());
            postRepo.Setup(x => x.GetAll()).Returns(new List<Post>());
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

        [TestMethod]
        public void Test_ViewTimeline_RunsGetAllMethod()
        {
            //Arrange
            
            
            //Act
            List<Post> userPToAdd = postLogic.ViewTimeline(user.Object);

            //Assert
            postRepo.Verify(p => p.GetAll());
        }

        [TestMethod]
        public void Test_ViewTimeline_ReturnsListOfTimelinePosts()
        {
            //Arrange
            List<Post> expectedPosts = new List<Post>();
            Mock<UserPost> pToAdd = new Mock<UserPost>();
            expectedPosts.Add(pToAdd.Object);

            // Mock user posts lists
            List<Post> userPosts = new List<Post>();
            // Mock user friends
            List<User> userFriends = new List<User>();
            // Mock user friends posts
            List<Post> userFriendsPosts = new List<Post>();

            userFriends.Add(friend.Object);
            userFriendsPosts.Add(pToAdd.Object);
            //Mock<Post> mockPostToAdd = new Mock<Post>();

            user.SetupGet(u => u.posts).Returns(userPosts);
            user.SetupGet(u => u.friends).Returns(userFriends);
            friend.SetupGet(f => f.posts).Returns(userFriendsPosts);
            
            //Act

            List<Post> actual = postLogic.ViewTimeline(user.Object);

            //Assert
            CollectionAssert.AreEqual(expectedPosts, actual);

        }
    }
}
