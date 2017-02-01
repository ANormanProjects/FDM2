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
        UserAccountLogic userAccountLogic;

        [TestInitialize]
        public void Setup()
        {          
            userRepo = new Mock<Repository<User>>();
            
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

        //[TestMethod]
        //public void Test_LoginMethod_CallsLoginDetailVerificationMethodGivenCorrectForm()
        //{
        //    //arrange
        //    string username = "username";
        //    string password = "password";

        //    userRepo.Setup(x => x.First(It.IsAny<Func<IUser, bool>>()));
        //    //act
        //    bool r = userAccountLogic.Login(username, password);

        //    //assert
        //    userRepo.Verify(q => q.First(u => u.username == username), Times.Once);


        //}

        
    }
}
