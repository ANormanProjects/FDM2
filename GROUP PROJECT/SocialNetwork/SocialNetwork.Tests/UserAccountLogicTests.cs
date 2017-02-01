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
        public void TestMethod1()
        {
        }
    }
}
