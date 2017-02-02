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
        Mock<Repository<Group>> groupRepo;
        PostLogic postLogic;
        Mock<CommentLogic> commentLogic; 
        Mock<User> user;
        Mock<User> friend;
        User anotherUser;
        Mock<UserPost> post;
        Comment userInput;
        List<Post> expectedPosts;
        List<Comment> listOfComments;
        Mock<Repository<Comment>> commentRepo;

        [TestInitialize]
        public void Setup()
        {
            postRepo = new Mock<Repository<Post>>();
            userRepo = new Mock<Repository<User>>();
            commentRepo = new Mock<Repository<Comment>>();
            groupRepo = new Mock<Repository<Group>>();
            postLogic = new PostLogic(postRepo.Object, userRepo.Object, groupRepo.Object, commentRepo.Object);
            commentLogic = new Mock<CommentLogic>(postRepo.Object, commentRepo.Object, userRepo.Object);
            user = new Mock<User>();
            friend = new Mock<User>();
            anotherUser = new User();
            post = new Mock<UserPost>();
            userInput = new Comment();
            expectedPosts = new List<Post>();
            listOfComments = new List<Comment>();

            postRepo.Setup(x => x.Insert(It.IsAny<Post>())).Verifiable();
            user.Setup(f => f.friends).Returns(new List<User>());
            postRepo.Setup(x => x.GetAll()).Returns(new List<Post>());
        }

        [TestMethod]
        public void Test_WriteGroupPost_RunsAddRepositoryMethodIfUserIsNotNull()
        {
            //Arrange
            

            //Act
            postLogic.WriteGroupPost(1, "a", "b", "c", "d", new Mock<Group>().Object);

            //Assert
            postRepo.Verify(p => p.Insert(It.IsAny<Post>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_WriteGroupPost_RunsAddRepositoryMethodIfGroupIsNull()
        {
            //Arrange
            Group group = new Group();
            group = null;

            //Act
            postLogic.WriteGroupPost(1, "a", "b", "c", "d", group);

            //Assert
            postRepo.Verify(p => p.Insert(It.IsAny<Post>()), Times.Once);
        }

        
        [TestMethod]
        public void Test_WriteUserPost_RunsAddUsesInsertMethod()
        {
            //Arrange


            //Act
            postLogic.WriteUserPost(1, "a", "b", "c", "d", user.Object);

            //Assert
            postRepo.Verify(p => p.Insert(It.IsAny<Post>()), Times.Once);
        }

        //[TestMethod]
        //public void Test_ViewTimeline_RunsGetAllMethod()
        //{
        //    //Arrange
            
            
        //    //Act
        //    List<Post> userPToAdd = postLogic.ViewTimeline(user.Object);

        //    //Assert
        //    postRepo.Verify(p => p.GetAll());
        //}

        [TestMethod]
        public void Test_ViewTimeline_ReturnsListOfTimelinePostsOfUser()
        {
            //Arrange
            expectedPosts.Add(post.Object);

            List<Post> userPosts = new List<Post>();
            userPosts.Add(post.Object);
            user.SetupGet(u => u.posts).Returns(userPosts);

            //Act
            List<Post> actual = postLogic.ViewTimeline(user.Object);

            //Assert
            CollectionAssert.AreEqual(expectedPosts, actual);

        }

        [TestMethod]
        public void Test_ViewTimeline_ReturnsListOfTimelinePostsOfAllFriends()
        {
            //Arrange
            expectedPosts.Add(post.Object);

            // Mock user posts lists
            List<Post> userPosts = new List<Post>();
            // Mock user friends
            List<User> userFriends = new List<User>();
            // Mock user friends posts
            List<Post> userFriendsPosts = new List<Post>();

            userFriends.Add(friend.Object);
            userFriendsPosts.Add(post.Object);

            user.SetupGet(u => u.posts).Returns(userPosts);
            user.SetupGet(u => u.friends).Returns(userFriends);
            friend.SetupGet(f => f.posts).Returns(userFriendsPosts);
            
            //Act

            List<Post> actual = postLogic.ViewTimeline(user.Object);

            //Assert
            CollectionAssert.AreEqual(expectedPosts, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_ViewTimeline_ReturnsAnExceptionMessageIfUserIsNull()
        {
            //Arrange
            anotherUser = null;

            //Act
            List<Post> actual = postLogic.ViewTimeline(anotherUser);

            //Assert
            
        }

        [TestMethod]
        public void Test_Reply_CallsAddComment()
        {
            //Arrange
            PostLogic postLogic2 = new PostLogic(commentLogic.Object);
            string userInput = "bla";
            commentLogic.Setup(c => c.AddComment(userInput, user.Object, post.Object)).Verifiable();

            //Act
            postLogic2.Reply(post.Object, userInput, user.Object);


            //Assert
            commentLogic.Verify(c => c.AddComment(userInput, user.Object, post.Object), Times.Once);
        }

        //[TestMethod]
        //public void Test_Reply_AddsCommentsToAPostIfTheUserInputIsNotNull()
        //{
        //    //Arrange

        //    userInput.content = "bla";
        //    listOfComments.Add(userInput);

        //    //Act
        //    post.SetupGet(u => u.comments).Returns(new List<Comment>());
        //    postLogic.Reply(post.Object, userInput.content);

        //    //Assert
        //    Assert.AreEqual(userInput.content, post.Object.comments[0].content);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(EmptyInputException))]
        //public void Test_Reply_ReturnsAnExceptionMessageIfUserInputIsNull()
        //{
        //    //Arrange

        //    userInput.content = null;

        //    //Act
        //    post.SetupGet(u => u.comments).Returns(new List<Comment>());
        //    postLogic.Reply(post.Object, userInput.content);

        //    //Assert

        //}

        //[TestMethod]
        //[ExpectedException(typeof(InputExceedsSpecifiedLimitException))]
        //public void Test_Reply_ReturnsAnExceptionMessageIfUserInputCharacterCountIsMoreThanMaxLength()
        //{
        //    //Arrange

        //    userInput.content = "abcdef";
        //    postLogic.maxContentLength = 2;

        //    //Act

        //    post.SetupGet(u => u.comments).Returns(new List<Comment>());
        //    postLogic.Reply(post.Object, userInput.content);

        //    //Assert

        //}

        [TestMethod]
        public void Test_LikePost_MakesLikeNumberGoUpByOneWhenCalled()
        {
            //Arrange
            

            //Act
            postLogic.LikePost(post.Object);

            //Assert
            Assert.AreEqual(post.Object.likes, 1);

        }
    }
}
