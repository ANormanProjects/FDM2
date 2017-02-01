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
            post.Setup(x => x.comments).Returns(commentList);

            commentRepo.Setup(x => x.Insert(It.IsAny<Comment>())).Verifiable();
            postRepo.Setup(x => x.Save()).Verifiable();
            commentRepo.Setup(x => x.Save()).Verifiable();

            //Act
            commentLogic.addComment("1", user.Object, post.Object);

            //Assert
            post.Verify(x => x.comments);           
            commentRepo.Verify(x => x.Insert(It.IsAny<Comment>()));
            postRepo.Verify(x => x.Save());
            commentRepo.Verify(x => x.Save());
           
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
            //Act
            commentLogic.LikeComment(comment.Object);

            //Assert
            commentRepo.Verify(x => x.Save());
            comment.VerifySet(x => x.likes = 2);

        }
    }
}
