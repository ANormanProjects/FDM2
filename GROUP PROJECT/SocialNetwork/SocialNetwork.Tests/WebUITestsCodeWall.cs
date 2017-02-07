using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Controllers;
using System.Web.Mvc;
using SocialNetwork.Logic;
using Moq;
using SocialNetwork.DataAccess;
using System.Collections.Generic;
using SocialNetwork.WebUI.Models;

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

        Mock<User> mockUser;
        Mock<User> mockFriend; // tfw no friends
        Mock<UserPost> mockPost1;
        Mock<UserPost> mockPost2;
        List<UserPost> posts;
        List<UserPost> friendsPosts;

        [TestInitialize]
        public void Setup()
        {
            commentRepo = new Mock<Repository<Comment>>();
            postRepo = new Mock<Repository<Post>>();
            postLogic = new Mock<PostLogic>(postRepo.Object, commentRepo.Object);
            classUnderTest = new CodeWallController(postLogic.Object);
            userRepo = new Mock<Repository<User>>();

            userAccountLogic = new Mock<UserAccountLogic>(userRepo.Object);

            mockPost1 = new Mock<UserPost>();
            mockPost2 = new Mock<UserPost>();
            mockPost1.SetupAllProperties();
            mockPost1.Object.title = "Test 1";
            mockPost2.SetupAllProperties();
            mockPost2.Object.title = "Test 2";

            posts = new List<UserPost>()
            {
                mockPost1.Object
            };

            friendsPosts = new List<UserPost>()
            {
                mockPost2.Object
            };

            mockFriend = new Mock<User>();
            mockFriend.SetupAllProperties();
            mockFriend.Object.posts = friendsPosts;

            mockUser = new Mock<User>();
            mockUser.SetupAllProperties();
            mockUser.Object.posts = posts;
            mockUser.Object.friends = new List<User>()
            {
                mockFriend.Object
            };
        }

        //---------- Testing the CodeWallController ----------//

        [TestMethod]
        public void Test_WallInCodeWall_ReturnsWallView()
        {
            //arr
            var expected = "Wall";           

            Mock<UserAccountLogic> mockLogic = new Mock<UserAccountLogic>();
            mockLogic.Setup(m => m.ViewAccountInfo(It.IsAny<string>())).Returns(mockUser.Object);

            // Cant mock User.Identity.Name...

            //act
            var actual = classUnderTest.Wall() as ViewResult;

            //ass
            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void Test_CreateViewModelsForUser_ReturnsNewViewModelsForUsersPosts_WhenCalledForAUser()
        {
            // Arrange


            // Act
            List<UserPostViewModel> result = classUnderTest.CreateViewModelsForUser(mockUser.Object);

            // Assert
            Assert.AreEqual(posts[0].title, result[0].post.title);
            Assert.AreEqual(posts[1].title, result[1].post.title);
        }

        [TestMethod]
        public void Test_CreateViewModelsForUserFriendsGroups_ReturnsNewViewModelsForUserFriendsAndGroupsPosts_WhenCalledForAUser()
        {
            // Arrange


            // Act
            List<UserPostViewModel> result = classUnderTest.CreateViewModelsForUserFriendsGroups(mockUser.Object);

            // Assert
            Assert.AreEqual(posts[0].title, result[0].post.title);
            Assert.AreEqual(friendsPosts[0].title, result[1].post.title);
        }
    }
}
