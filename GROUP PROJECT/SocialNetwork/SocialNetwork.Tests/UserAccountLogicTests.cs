using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class UserAccountLogicTests
    {
        Mock<Repository<User>> userRepo;
        Mock<Repository<Post>> postRepo;
        Mock<Repository<Comment>> commentRepo;
        UserAccountLogic userAccountLogic;

        [TestInitialize]
        public void Setup()
        {          
            userRepo = new Mock<Repository<User>>();
            
            userAccountLogic = new UserAccountLogic(userRepo.Object, postRepo.Object, commentRepo.Object);                       
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
        
    }
}
