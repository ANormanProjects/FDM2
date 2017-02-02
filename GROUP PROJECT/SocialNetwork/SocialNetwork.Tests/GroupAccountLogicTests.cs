using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.DataAccess;
using Moq;
using SocialNetwork.Logic;
using System.Collections.Generic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class GroupAccountLogicTests
    {
        Mock<Repository<Group>> groupRepo;
        Mock<Repository<Post>> postRepo;
        Mock<Repository<Comment>> commentRepo;
        Mock<Repository<User>> userRepo;
        GroupAccountLogic groupLogic;
        Mock<Group> group;
        Mock<User> user;

        [TestInitialize]
        public void Setup()
        {
            postRepo = new Mock<Repository<Post>>();
            commentRepo = new Mock<Repository<Comment>>();
            userRepo = new Mock<Repository<User>>();
            groupRepo = new Mock<Repository<Group>>();
            group = new Mock<Group>();
            user = new Mock<User>();

            groupLogic = new GroupAccountLogic(groupRepo.Object, postRepo.Object, commentRepo.Object, userRepo.Object);

        }

        [TestMethod]
        public void Test_AddUserToGroup_AddsUserToGroupUsersInGroupProperty()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            List<User> users = new List<User>();

            group.Setup(c => c.usersInGroup).Returns(users);
            List<User> expected = new List<User>(){user.Object};

            //Act
            groupLogic.AddUserToGroup(group.Object, user.Object);

            //Assert
            CollectionAssert.AreEqual(expected, users);

        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundExceptionThrownWhenUserNotInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>());

            //Act
            groupLogic.AddUserToGroup(group.Object, user.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundExceptionThrownWhenGroupNotInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>());
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            //Act
            groupLogic.AddUserToGroup(group.Object, user.Object);
        }
    }
}
