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
        public void Test_EntityNotFoundExceptionThrownWhenUserNotInDatabase_WhenAddUserRun()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>());

            //Act
            groupLogic.AddUserToGroup(group.Object, user.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_EntityNotFoundExceptionThrownWhenGroupNotInDatabase_WhenAddUserRun()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>());
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            //Act
            groupLogic.AddUserToGroup(group.Object, user.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void Test_UserAlreadyInGroupExceptionThrownWhenUserAlreadyInGroup_WhenAddUserRun()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            List<User> users = new List<User>() { user.Object };

            group.Setup(c => c.usersInGroup).Returns(users);

            //Act
            groupLogic.AddUserToGroup(group.Object, user.Object);
        }

        [TestMethod]
        public void Test_RemovesUserFromGroup_RemovesUserFromGroupUsersInGroupProperty()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            List<User> users = new List<User>() { user.Object };

            group.Setup(c => c.usersInGroup).Returns(users);
            List<User> expected = new List<User>();

            //Act
            groupLogic.RemoveUserFromGroup(group.Object, user.Object);

            //Assert
            CollectionAssert.AreEqual(expected, users);

        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_RemoveUserFromGroup_EntityNotFoundExceptionThrown_WhenUserNotInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>());

            //Act
            groupLogic.RemoveUserFromGroup(group.Object, user.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_RemoveUserFromGroup_EntityNotFoundExceptionThrown_WhenGroupNotInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>());
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            //Act
            groupLogic.RemoveUserFromGroup(group.Object, user.Object);
        }

        [TestMethod]
        public void Test_GetAllUsersInGroup_ReturnsListOfUsersInGroup_WhenGroupIsInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            group.Setup(c => c.usersInGroup).Returns(new List<User>() { user.Object });

            List<User> expected = new List<User>() { user.Object };

            //Act
            List<User> actual = groupLogic.GetAllUsersInGroup(group.Object);

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_GetAllUsersInGroup_EntityNotFoundExceptionThrown_WhenGroupNotInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>());
            
            //Act
            groupLogic.GetAllUsersInGroup(group.Object);
        }

        [TestMethod]
        public void Test_WritePost_RunsWritePostMethodInPostLogic_WithCorrectParameters()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });

            Mock<PostLogic> postLogic = new Mock<PostLogic>(postRepo.Object, commentRepo.Object);
            GroupAccountLogic groupLogic1 = new GroupAccountLogic(postLogic.Object, groupRepo.Object);

            postLogic.Setup(c => c.WriteGroupPost(1, "2", "3", "4", "5", group.Object)).Verifiable();

            //Act
            groupLogic1.WritePost(1, "2", "3", "4", "5", group.Object);

            //Assert

            postLogic.Verify(c => c.WriteGroupPost(1, "2", "3", "4", "5", group.Object));
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_WritePost_EntityNotFoundExceptionThrown_WhenGroupNotInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>());

            //Act
            groupLogic.WritePost(1, "2", "3", "4", "5", group.Object);
        }

        [TestMethod]
        public void Test_GetAllPostsInGroup_RunsRepositoryGetAllMethod_WhenCalled()
        {
            //Arrange
            Mock<GroupPost> groupPost = new Mock<GroupPost>();

            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>() { group.Object });
            group.Setup(c => c.groupWall).Returns(new List<GroupPost>() { groupPost.Object });

            var expected = new List<GroupPost>() { groupPost.Object };
            
            //Act
            var actual = groupLogic.GetAllPostsInGroup(group.Object);
            
            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_GetAllPostsInGroup_EntityNotFoundExceptionThrown_WhenGroupNotInDatabase()
        {
            //Arrange
            groupRepo.Setup(c => c.GetAll()).Returns(new List<Group>());

            //Act
            groupLogic.GetAllPostsInGroup(group.Object);
        }

    }
}
