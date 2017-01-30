using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.DataAccess;
using Moq;
using SocialNetwork.Logic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class SearchLogicTests
    {
        [TestMethod]
        public void Test_SearchForUserById_RunsFirstMethodInRepository_WithIdEnteredInMethod()
        {
            //Arrange
            Mock<Repository<IUser>> userRepo = new Mock<Repository<IUser>>();
            Mock<Repository<Post>> postRepo = new Mock<Repository<Post>>();

            ISearchLogic searchLogic = new SearchLogic(postRepo.Object, userRepo.Object);
            Mock<User> user1 = new Mock<User>();

            userRepo.Setup(x => x.First(It.IsAny<Func<IUser, bool>>())).Returns(user1.Object);

            //Act
            IUser user = searchLogic.SearchForUserById(1);


            //Assert
            Assert.AreEqual(user1.Object, user);

        }
    }
}
