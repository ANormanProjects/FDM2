using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System.Collections.Generic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class UserAccountLogicTests
    {
        Mock<Repository<User>> userRepo;
        Mock<Repository<Post>> postRepo;
        Mock<Repository<Comment>> commentRepo;
        Mock<Repository<Group>> groupRepo;
        UserAccountLogic userAccountLogic1;
        UserAccountLogic userAccountLogic;
        Mock<PostLogic> postLogic;

        [TestInitialize]
        public void Setup()
        {          
            userRepo = new Mock<Repository<User>>();
            commentRepo = new Mock<Repository<Comment>>();
            postRepo = new Mock<Repository<Post>>();
            groupRepo = new Mock<Repository<Group>>();
            postLogic = new Mock<PostLogic>(postRepo.Object, commentRepo.Object);

            userAccountLogic1 = new UserAccountLogic(userRepo.Object, postRepo.Object, commentRepo.Object, groupRepo.Object);
            userAccountLogic = new UserAccountLogic(userRepo.Object);     
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyInputException))]
        public void Test_LoginMethod_ThrowsExceptionIfInputUsernameIsNull()
        {
            //arrange
            string username = null;
            string password = "password123";

            //act
            bool r = userAccountLogic.Login(username, password);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyInputException))]
        public void Test_LoginMethod_ThrowsExceptionIfInputPasswordIsNull()
        {
            //arrange
            string username = "username";
            string password = null;

            //act
            bool r = userAccountLogic.Login(username, password);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(InputExceedsSpecifiedLimitException))]
        public void Test_LoginMethod_ThrowsInputExceedsExceptionIfInputPasswordExceedsLimit()
        {
            //arrange
            string username = "usernameeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee";
            string password = "pass";

            //act
            bool r = userAccountLogic.Login(username, password);

            //assert
        }

        [TestMethod]
        public void Test_LoginMethod_ReturnsTrueIfCorrectLoginDetailsAreEntered()
        {
            //arrange
            string username = "Buble";
            string password = "Michael";

            Mock<User> user1 = new Mock<User>();

            userRepo.Setup(x => x.First(It.IsAny<Func<User, bool>>())).Returns(user1.Object);

            user1.Setup(x => x.username).Returns("Buble");
            user1.Setup(x => x.password).Returns("Michael");

            //userRepo.Setup(x => x.First(It.IsAny<Func<IUser, bool>>())).Verifiable();
            //act
            bool r = userAccountLogic.Login(username, password);

            //assert
            Assert.AreEqual(true, r);


            //userRepo.Verify(q => q.First(u => u.username == username), Times.Once);
            //Assert.AreEqual(false, r);


        }

        [TestMethod]
        public void Test_LoginMethod_ReturnsFalseIfWrongDetailsAreEntered() 
        {
            //arrange
            string username = "Bule";
            string password = "Michael";

            Mock<User> user1 = new Mock<User>();

            userRepo.Setup(x => x.First(It.IsAny<Func<User, bool>>())).Returns(user1.Object);

            user1.Setup(x => x.username).Returns("Buble");

            user1.Setup(x => x.password).Returns("Michael");

            //userRepo.Setup(x => x.First(It.IsAny<Func<IUser, bool>>())).Verifiable();
            //act
            bool r = userAccountLogic.Login(username, password);

            //assert
            Assert.AreEqual(false, r);
        
        }

        [TestMethod]
        public void Test_LoginDetailsVerificationMethod_ReturnsTrueWhenDetailsAreCorrect() 
        {
            //arrange
            string username = "Bule";
            string password = "Michael";
            Mock<User> user = new Mock<User>();

            userRepo.Setup(c => c.First(It.IsAny<Func<User, bool>>())).Returns(user.Object);
            user.Setup(u => u.username).Returns("Bule");
            user.Setup(p => p.password).Returns("Michael");

            //act
            bool r = userAccountLogic.LoginDetailVerification(username, password);

            //assert
            Assert.AreEqual(true, r);
        
        }

        [TestMethod]
        public void Test_LoginDetailsVerificationMethod_ReturnsFalseWhenDetailsAreIncorrect()
        {
            //arrange
            string username = "Bully";
            string password = "Michael";
            Mock<User> user = new Mock<User>();

            userRepo.Setup(c => c.First(It.IsAny<Func<User, bool>>())).Returns(user.Object);
            user.Setup(u => u.username).Returns("Bule");
            user.Setup(p => p.password).Returns("Michael");

            //act
            bool r = userAccountLogic.LoginDetailVerification(username, password);

            //assert
            Assert.AreEqual(false, r);

        }

        //[TestMethod]
        //public void Test_RegisterUser_AddsUserToDbWhenCalledAndGivenUser() 
        //{
            
        //}

        [TestMethod]
        public void Test_AddFriendMethod_AddsAFriendToBothUsers()
        {
            //arr
            Mock<User> user = new Mock<User>();
            user.Setup(id => id.userId).Returns(1);
            user.Setup(friends => friends.friends).Returns(new List<User>());

            Mock<User> friend = new Mock<User>();
            friend.Setup(id => id.userId).Returns(2);
            friend.Setup(friends => friends.friends).Returns(new List<User>());

            userRepo.Setup(c => c.First(It.IsAny<Func<User, bool>>())).Returns(user.Object);
            
            //act
            userAccountLogic.AddFriend(user.Object, friend.Object);

            //assert
            Assert.AreEqual(1, user.Object.friends.Count);
            Assert.AreEqual(1, friend.Object.friends.Count);
            userRepo.Verify(c => c.Save(), Times.Once);

        }

        [TestMethod]
        public void Test_GetAllUserAccounts_ReturnsAListOfUsers() 
        {
            //arr
            List<User> expected = new List<User>();

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>());
            
            //act
            List<User> actual = userAccountLogic.GetAllUserAccounts();

            //assert
            CollectionAssert.AreEquivalent(expected, actual);
        
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod] //double check
        public void Test_WritePostMethod_ThrowsAnException_GivenAUserThatsNotINDB() 
        {
            //arr
            Mock<User> user = new Mock<User>();
            user.Setup(id => id.userId).Returns(1);
            user.Setup(friends => friends.friends).Returns(new List<User>());

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>());
            postLogic.Setup(d => d.WriteUserPost(1, "Post", "c#", "codeycode", "contyconty", user.Object)).Verifiable();

            //act
            userAccountLogic.WritePost(1, "Post", "c#", "codeycode", "contyconty", user.Object);
            
            
            //ass
            userRepo.Verify(x => x.GetAll(), Times.Once);
            postLogic.Verify(a => a.WriteUserPost(1, "Post", "c#", "codeycode", "contyconty", user.Object), Times.Once);
            
        }

        [TestMethod] //double check
        public void Test_WritePostMethod_CallsWritePostLogic_GivenAUser()
        {
            //arr
            Mock<User> user = new Mock<User>();
            user.Setup(id => id.userId).Returns(1);
            user.Setup(friends => friends.friends).Returns(new List<User>());            

            List<User> users = new List<User>();
            users.Add(user.Object);
            Mock<PostLogic> iPostLogic = new Mock<PostLogic>(postRepo.Object, userRepo.Object, groupRepo.Object, commentRepo.Object);
            userRepo.Setup(c => c.GetAll()).Returns(users);
            iPostLogic.Setup(d => d.WriteUserPost(1, "Post", "c#", "codeycode", "contyconty", user.Object)).Verifiable();
            UserAccountLogic useracclogic1 = new UserAccountLogic(iPostLogic.Object, userRepo.Object); 

            //act
            useracclogic1.WritePost(1, "Post", "c#", "codeycode", "contyconty", user.Object);


            //ass
            userRepo.Verify(x => x.GetAll(), Times.Once);
            //postLogic.Verify(a => a.WriteUserPost(1, "Post", "c#", "codeycode", "contyconty", user.Object), Times.Once);

        }


    }
}
