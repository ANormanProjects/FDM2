using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.DataAccess;
using Moq;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        public Repository<User> userRepo;
        public Mock<DbContext> mockContext;
        public Mock<DbSet<User>> mockUsers;
        public Mock<User> mockUser1;
        public Mock<User> mockUser2;
        public Mock<User> mockUser3;

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void Test_GetAll_ReturnsListOfAllUsers_WhenCalled()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
