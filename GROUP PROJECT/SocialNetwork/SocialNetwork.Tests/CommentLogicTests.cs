using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Logic;
using SocialNetwork.DataAccess;
using Moq;
using System.Collections.Generic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class CommentLogicTests
    {
        Mock<Repository<Post>> postRepo;
        Mock<Repository<Comment>> commentRepo;
        Mock<Repository<User>> userRepo;
        CommentLogic commentLogic;
        Mock<Post> post;
        Mock<User> user;
        List<Comment> commentList;
       

        [TestInitialize]
        public void Setup()
        {
            postRepo = new Mock<Repository<Post>>();
            commentRepo = new Mock<Repository<Comment>>();
            userRepo = new Mock<Repository<User>>();
            commentLogic = new CommentLogic(postRepo.Object, commentRepo.Object, userRepo.Object);
            post = new Mock<Post>();
            user = new Mock<User>();
            commentList = new List<Comment>();
        }

        [TestMethod]
        public void Test_AddCommentMethod_AddsNewCommentToPostCommentsAndCommentRepo()
        {
            //Arrange           

            commentRepo.Setup(x => x.Insert(It.IsAny<Comment>())).Verifiable();
            
            commentRepo.Setup(x => x.Save()).Verifiable();
            userRepo.Setup(x => x.GetAll()).Returns(new List<User>{user.Object});
            postRepo.Setup(x => x.GetAll()).Returns(new List<Post> { post.Object });
            //Act
            commentLogic.AddComment("1", user.Object, post.Object);

            //Assert
          
            commentRepo.Verify(x => x.Insert(It.IsAny<Comment>()));
            commentRepo.Verify(x => x.Save());
           
        }

        [TestMethod]
        public void Test_Constructor_SetsAttributes()
        {
            SocialNetworkDataModel sndm = new SocialNetworkDataModel();
            CommentLogic commentLogicTest = new CommentLogic(sndm);

            Assert.IsNotNull(commentLogicTest.postRepo);
            Assert.IsNotNull(commentLogicTest.commentRepo);
            Assert.IsNotNull(commentLogicTest.userRepo);

        }

        [TestMethod]
        public void Test_RemoveComment_RemovesCommentFromPostCommentsAndCommentRepo()
        {
            //Arrange
            Mock<Comment> comment = new Mock<Comment>();
            comment.Setup(x => x.post).Returns(post.Object); 
            commentRepo.Setup(x => x.Remove(comment.Object)).Verifiable();
            commentRepo.Setup(x => x.Save()).Verifiable();
            postRepo.Setup(x => x.Save()).Verifiable();
            post.Setup(x => x.comments).Returns(commentList);
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment> { comment.Object });

            //Act
            commentLogic.DeleteComment(comment.Object);

            //Assert
            comment.Verify(x => x.post);
            postRepo.Verify(x => x.Save());
            commentRepo.Verify(x => x.Save());
            commentRepo.Verify(x => x.Remove(comment.Object));
            comment.Verify(x => x.post); 

        }

        [TestMethod]
        public void Test_EditComment_SetsCommentContentToEnteredTextAndSavesChanges()
        {
            //Arrange
            Mock<Comment> comment = new Mock<Comment>();
            commentRepo.Setup(x => x.Save()).Verifiable();
            comment.SetupSet(x => x.content = "Hello");
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment> { comment.Object });
            //Act
            commentLogic.EditComment(comment.Object, "Hello");
            
            //Assert
            commentRepo.Verify(x => x.Save());
            comment.VerifySet(x => x.content = "Hello");

        }

        [TestMethod]
        public void Test_LikeComment_Adds1ToCommentLikesAndSavesChanges()
        {
            //Arrange
            Mock<Comment> comment = new Mock<Comment>();
            commentRepo.Setup(x => x.Save()).Verifiable();
            comment.Setup(x => x.likes).Returns(1);
            comment.SetupSet(x => x.likes = 2);
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment> { comment.Object });
            //Act
            commentLogic.LikeComment(comment.Object);

            //Assert
            commentRepo.Verify(x => x.Save());
            comment.VerifySet(x => x.likes = 2);

        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundException_IsThrown_WhenEnteredUsernameIsNotInDatabase()
        {
            //Arrange
            userRepo.Setup(x => x.GetAll()).Returns(new List<User>{});
            //Act
            commentLogic.AddComment("Hi", user.Object, post.Object);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundException_IsThrown_WhenEnteredPostIsNotInDatabase()
        {
            //Arrange
            postRepo.Setup(x => x.GetAll()).Returns(new List<Post>{ });
            userRepo.Setup(x => x.GetAll()).Returns(new List<User> { user.Object });
            //Act
            commentLogic.AddComment("Hi", user.Object, post.Object);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(StringNotCorrectLengthException))]
        public void Test_StringNotCorrectLengthException_IsThrown_WhenEnteredCommentDataIsEmpty_WhenAddCommentMethodRun()
        {
            //Arrange
            postRepo.Setup(x => x.GetAll()).Returns(new List<Post> { post.Object });
            userRepo.Setup(x => x.GetAll()).Returns(new List<User> { user.Object });
            //Act
            commentLogic.AddComment("", user.Object, post.Object);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(StringNotCorrectLengthException))]
        public void Test_StringNotCorrectLengthException_IsThrown_WhenEnteredCommentDataIsOver255Characters_WhenAddCommentMethodRun()
        {
            //Arrange
            postRepo.Setup(x => x.GetAll()).Returns(new List<Post> { post.Object });
            userRepo.Setup(x => x.GetAll()).Returns(new List<User> { user.Object });
            //Act
            commentLogic.AddComment("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", user.Object, post.Object);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundException_IsThrown_WhenEnteredCommentIsNotInDatabase_WhenDeleteCommentMethodRun()
        {
            //Arrange
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment>());
            Mock<Comment> comment = new Mock<Comment>();
            //Act
            commentLogic.DeleteComment(comment.Object);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundException_IsThrown_WhenEnteredCommentIsNotInDatabase_WhenEditCommentMethodRun()
        {
            //Arrange
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment>());
            Mock<Comment> comment = new Mock<Comment>();
            //Act
            commentLogic.EditComment(comment.Object, "2");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(StringNotCorrectLengthException))]
        public void Test_StringNotCorrectLengthException_IsThrown_WhenEnteredCommentDataIsEmpty_WhenEditCommentMethodRun()
        {
            //Arrange
            Mock<Comment> comment = new Mock<Comment>();
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment> { comment.Object });
            //Act
            commentLogic.EditComment(comment.Object, "");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(StringNotCorrectLengthException))]
        public void Test_StringNotCorrectLengthException_IsThrown_WhenEnteredCommentDataIsOver255Characters_WhenEditCommentMethodRun()
        {
            //Arrange
            Mock<Comment> comment = new Mock<Comment>();
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment> { comment.Object });
            //Act
            commentLogic.EditComment(comment.Object, "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundException_IsThrown_WhenEnteredCommentIsNotInDatabase_WhenLikeCommentMethodRun()
        {
            //Arrange
            commentRepo.Setup(x => x.GetAll()).Returns(new List<Comment>());
            Mock<Comment> comment = new Mock<Comment>();
            //Act
            commentLogic.LikeComment(comment.Object);
            //Assert
        }
    }
}
