using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.DataAccess;
using Moq;
using SocialNetwork.Logic;
using System.Collections.Generic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class SearchLogicTests
    {
        Mock<Repository<IUser>> userRepo;
        Mock<Repository<Post>> postRepo;
        ISearchLogic searchLogic;
        Mock<User> user1;
        Mock<Post> post1;

        [TestInitialize]
        public void SetUp()
        {
            userRepo = new Mock<Repository<IUser>>();
            postRepo = new Mock<Repository<Post>>();
            searchLogic = new SearchLogic(postRepo.Object, userRepo.Object);
            user1 = new Mock<User>();
            post1 = new Mock<Post>();
        }

        [TestMethod]
        public void Test_SearchForUserById_RunsFirstMethodInRepository_WithIdEnteredInMethod()
        {
            //Arrange

            userRepo.Setup(x => x.First(It.IsAny<Func<IUser, bool>>())).Returns(user1.Object);

            //Act
            IUser user = searchLogic.SearchForUserById(1);


            //Assert
            Assert.AreEqual(user1.Object, user);

        }

        [TestMethod]

        public void Test_SearchForUserByName_RunsSearchMethodInRepository_WithNameEnteredInMethod()
        {
            //Arrange
            List<User> users = new List<User>{user1.Object};

            userRepo.Setup(x => x.Search(It.IsAny<Func<IUser, bool>>())).Returns(users);

            //Act

            List<IUser> actual = searchLogic.SearchForUserByName("Spencer Newton");  

            //Assert

            CollectionAssert.AreEqual(users, actual);

        }

        [TestMethod]

        public void Test_SearchForCode_RunsSearchMethodInRepository()
        {
            //Arrange
            List<Post> posts = new List<Post> { post1.Object };

            postRepo.Setup(x => x.Search(It.IsAny<Func<Post, bool>>())).Returns(posts);

            //Act
            List<Post> actual = searchLogic.SearchForCode("C#");

            //Assert

            CollectionAssert.AreEqual(posts, actual);
        }
    }
}
