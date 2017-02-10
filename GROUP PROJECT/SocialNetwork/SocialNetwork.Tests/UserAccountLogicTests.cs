using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System.Collections.Generic;
using System.Linq;

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

            //act
            bool r = userAccountLogic.Login(username, password);

            //assert
            Assert.AreEqual(true, r);

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

        [TestMethod]
        public void Test_RegisterUser_AddsUserToDbWhenCalledAndGivenUser()
        {
            //Arrange
            Mock<User> user = new Mock<User>();

            
            userRepo.Setup(u => u.Insert(user.Object));

            //Act
            userAccountLogic.Register(user.Object);
            
            //Assert
            userRepo.Verify(u => u.Insert(user.Object), Times.Once);
            userRepo.Verify(i => i.Save(), Times.Once);
        }

        [TestMethod]
        public void Test_CheckForDuplicates_ReturnsTrue_IfAUsernameAlreadyExists()
        {
            //Arrange
            User existingUser = new User { username = "dave"};
            userRepo.Setup(u => u.Insert(existingUser)).Verifiable();
            userRepo.Setup(p => p.GetAll()).Returns(new List<User>() { existingUser });
            var expected = true;
            User user = new User { username = "dave"};
            

            //Act
            bool actual = userAccountLogic.CheckForDuplicates(user);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CheckForDuplicates_ReturnsFalse_IfAUsernameDoesNotExists()
        {
            //Arrange
            User existingUser = new User { username = "dve" };
            userRepo.Setup(u => u.Insert(existingUser)).Verifiable();
            userRepo.Setup(p => p.GetAll()).Returns(new List<User>() { existingUser });
            var expected = false;
            User user = new User { username = "dave" };


            //Act
            bool actual = userAccountLogic.CheckForDuplicates(user);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_AddFriendMethod_AddsAFriendToBothUsers()
        {
            //arr
            Mock<User> user = new Mock<User>();
            user.Setup(id => id.username).Returns("1");
            user.Setup(friends => friends.friends).Returns(new List<User>());

            Mock<User> friend = new Mock<User>();
            friend.Setup(id => id.username).Returns("2");
            friend.Setup(friends => friends.friends).Returns(new List<User>());

            //act
            userAccountLogic.AddFriend(user.Object, friend.Object);

            //assert
            Assert.AreEqual(1, user.Object.friends.Count);
            Assert.AreEqual(1, friend.Object.friends.Count);
            userRepo.Verify(c => c.Save(), Times.Once);

        }

        [ExpectedException(typeof(EntityAlreadyExistsException))]
        [TestMethod]
        public void Test_AddFriendMethod_ThrowsEntityAlreadyExistsException_WhenFriendIsAlreadyOnFriendsList()
        {
            //Arrange
            Mock<User> user = new Mock<User>();
            user.Setup(id => id.username).Returns("1");
            Mock<User> friend = new Mock<User>();
            friend.Setup(id => id.username).Returns("2");

            user.Setup(friends => friends.friends).Returns(new List<User>() { friend.Object });
            friend.Setup(friends => friends.friends).Returns(new List<User>());

            //Act
            userAccountLogic.AddFriend(user.Object, friend.Object);
            //Assert
        }

        [ExpectedException(typeof(SameEntityException))]
        [TestMethod]
        public void Test_AddFriend_ThrowsSameEntityException_WhenInputUsersHaveSameUsername()
        {
            //Arrange
            Mock<User> user = new Mock<User>();
            user.Setup(id => id.username).Returns("1");
            user.Setup(friends => friends.friends).Returns(new List<User>());

            //Act
            userAccountLogic.AddFriend(user.Object, user.Object);
            //Assert
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
        [TestMethod] 
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

        [TestMethod] 
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

        }

        [TestMethod]
        public void Test_EditUserMethod_EditAUser_GivenAUserAndDetails() 
        {
            //arr
            Mock<User> user = new Mock<User>();
            user.SetupSet(fname => fname.fullName = "newName").Verifiable();
            user.SetupSet(gender => gender.gender = "newGender").Verifiable();
            user.SetupSet(role => role.role = "newRole").Verifiable();
            user.SetupSet(pword => pword.password = "newPassword").Verifiable();


            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });
            userRepo.Setup(v => v.Save()).Verifiable();

            //act
            userAccountLogic.EditUser(user.Object,"newName","newGender", "newRole", "newPassword");

            //ass

            userRepo.Verify(n => n.GetAll(), Times.Once);
            userRepo.Verify(s => s.Save(), Times.Once);

            user.VerifySet(fname => fname.fullName = "newName");
            user.VerifySet(gender => gender.gender = "newGender");
            user.VerifySet(role => role.role = "newRole");
            user.VerifySet(pword => pword.password = "newPassword");
        }

        [TestMethod]
        public void Test_RemoveUserMethod_GivenAUser() 
        {
            //arr
            Mock<User> user = new Mock<User>();
            
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });
            userRepo.Setup(v => v.Save()).Verifiable();

            userRepo.Setup(r => r.Remove(user.Object)).Verifiable();

            //act
            userAccountLogic.RemoveUser(user.Object);

            //ass
            userRepo.Verify(n => n.GetAll(), Times.Once);
            userRepo.Verify(s => s.Save(), Times.Once);
            userRepo.Verify(r => r.Remove(user.Object), Times.Once);
        
        }

        [TestMethod]
        public void Test_ViewAccountInfo_GivenAUsername() 
        {
            //arr
            Mock<User> user = new Mock<User>();
            user.Setup(f => f.username).Returns("fb");

            userRepo.Setup(x => x.First(It.IsAny<Func<User, bool>>())).Returns(user.Object);
            //act

            User userTest = userAccountLogic.ViewAccountInfo("fb");
            //ass
            Assert.AreEqual(user.Object, userTest);
            userRepo.Verify(c => c.First(It.IsAny<Func<User, bool>>()), Times.Once);
        
        }


        [TestMethod]
        public void Test_ViewAllPostByFollowedGroups_ReturnsListOfGroupPost_GivenAUser() 
        {
            //Arrange
            Mock<User> user = new Mock<User>();
            Mock<Group> group = new Mock<Group>();
            Mock<GroupAccountLogic> groupLogic = new Mock<GroupAccountLogic>(postLogic.Object, groupRepo.Object);
            UserAccountLogic userLogic = new UserAccountLogic(groupLogic.Object, userRepo.Object);
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });
            groupLogic.Setup(x => x.GetAllPostsInGroup(group.Object)).Returns(new List<GroupPost>());
            user.Setup(x => x.groups).Returns(new List<Group>() { group.Object });
            var expected = new List<GroupPost>();

            //Act
            var actual = userLogic.ViewAllPostByFollowedGroups(user.Object);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod] 
        public void Test_ViewAllPostByFollowedGroupsMethod_ThrowsException() 
        {
            //Arrange
            Mock<User> user = new Mock<User>();
            Mock<Group> group = new Mock<Group>();
            Mock<GroupAccountLogic> groupLogic = new Mock<GroupAccountLogic>(postLogic.Object, groupRepo.Object);
            UserAccountLogic userLogic = new UserAccountLogic(groupLogic.Object, userRepo.Object);
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() {  });

            //Act
            var actual = userLogic.ViewAllPostByFollowedGroups(user.Object);

            //Assert
          
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void Test_EditUserMethod_ThrowsException_IfUserDoesntExist()
        {
            //arr
            Mock<User> user = new Mock<User>();
           
            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() {  });
          
            //act
            userAccountLogic.EditUser(user.Object, "newName", "newGender", "newRole", "newPassword");
                               
   
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void Test_RemoveUserMethod_ThrowsException_IfUserDoesntExist()
        {
            //arr
            Mock<User> user = new Mock<User>();

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { });

            //act
            userAccountLogic.RemoveUser(user.Object);


        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void Test_RemoveFriendMethod_ThrowsException_IfUserDoesntExist()
        {
            //arr
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { friend.Object });

            //act
            userAccountLogic.RemoveFriend(user.Object, friend.Object);

        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void Test_RemoveFriendMethod_ThrowsException_IfFriendDoesntExist()
        {
            //arr
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            //act
            userAccountLogic.RemoveFriend(user.Object, friend.Object);

        }

        [ExpectedException(typeof(UserIsNotYourFriendException))]
        [TestMethod]
        public void Test_RemoveFriendMethod_ThrowsException_IfFriendIsNotOnFriendsList()
        {
            //arr
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object, friend.Object });

            user.Setup(c => c.friends).Returns(new List<User>());
            friend.Setup(c => c.friends).Returns(new List<User>() { user.Object });

            //act
            userAccountLogic.RemoveFriend(user.Object, friend.Object);

        }

        [ExpectedException(typeof(UserIsNotYourFriendException))]
        [TestMethod]
        public void Test_RemoveFriendMethod_ThrowsException_IfUserIsNotOnFriendsFriendList()
        {
            //arr
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object, friend.Object });

            user.Setup(c => c.friends).Returns(new List<User>() { friend.Object });
            friend.Setup(c => c.friends).Returns(new List<User>() {});

            //act
            userAccountLogic.RemoveFriend(user.Object, friend.Object);

        }

        [TestMethod]
        public void Test_RemoveFriendMethod_RemovesFriendFromUserAndFriend()
        {
            //Arrange
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object, friend.Object });
            userRepo.Setup(c => c.Save()).Verifiable();

            user.Setup(c => c.friends).Returns(new List<User>() { friend.Object });
            friend.Setup(c => c.friends).Returns(new List<User>() { user.Object });

            //Act
            userAccountLogic.RemoveFriend(user.Object, friend.Object);

            //Assert
            userRepo.Verify(c => c.GetAll());
            user.Verify(c => c.friends);
            friend.Verify(c => c.friends);
            userRepo.Verify(c => c.Save());
            Assert.AreEqual(0, friend.Object.friends.Count);
            Assert.AreEqual(0, user.Object.friends.Count);
        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void Test_CheckIfUserIsFriendMethod_ThrowsException_IfUserDoesntExist()
        {
            //arr
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object });

            //act
            userAccountLogic.checkIfUserIsFriend(user.Object, friend.Object);

        }

        [ExpectedException(typeof(EntityNotFoundException))]
        [TestMethod]
        public void Test_CheckIfUserIsFriendMethod_ThrowsException_IfFriendDoesntExist()
        {
            //arr
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { friend.Object });

            //act
            userAccountLogic.checkIfUserIsFriend(user.Object, friend.Object);

        }

        [TestMethod]
        public void Test_CheckIfUserIsFriendMethod_ReturnsTrue_WhenUserIsFriend()
        {
            //Arrange
            Mock<User> user = new Mock<User>();
            Mock<User> friend = new Mock<User>();

            user.Setup(c => c.username).Returns("Red");
            friend.Setup(c => c.username).Returns("Blue");

            userRepo.Setup(c => c.GetAll()).Returns(new List<User>() { user.Object, friend.Object });

            user.Setup(c => c.friends).Returns(new List<User>() { friend.Object });
            friend.Setup(c => c.friends).Returns(new List<User>() { user.Object });

            //Act
            bool check = userAccountLogic.checkIfUserIsFriend(user.Object, friend.Object);

            //Assert
            Assert.AreEqual(true, check);
        }
    }
}
