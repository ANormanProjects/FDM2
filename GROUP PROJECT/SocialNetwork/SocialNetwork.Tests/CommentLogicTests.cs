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
        [TestMethod]
        public void Test_AddCommentMethod_AddsNewCommentToPostComments()
        {
            //Arrange
            Mock<Repository<Post>> postRepo = new Mock<Repository<Post>>();
            Mock<Repository<Comment>> commentRepo = new Mock<Repository<Comment>>();
            CommentLogic commentLogic = new CommentLogic(postRepo.Object, commentRepo.Object);
            List<Comment> commentList = new List<Comment>();
            Mock<Post> post = new Mock<Post>();
            Mock<User> user = new Mock<User>();

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
    }
}
