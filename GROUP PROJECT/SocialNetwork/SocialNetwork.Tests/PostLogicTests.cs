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
        public void Test_WriteGroupPostAddsPostToDatabase()
        {
            //Arrange
            Mock<GroupPost> mockGroupPost = new Mock<GroupPost>();

            Mock<Repository<Post>> mockPostRepository = new Mock<Repository<Post>>();
            PostLogic classUnderTest = new PostLogic();

            //Act
            classUnderTest.WriteGroupPost(mockGroupPost.Object.postId, mockGroupPost.Object.title, mockGroupPost.Object.language, mockGroupPost.Object.code, mockGroupPost.Object.content);

            //Assert
            mockPostRepository.Verify(p => p.Insert(mockGroupPost.Object), Times.Once);
        }
    }
}
