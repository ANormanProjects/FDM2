using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCodeTest.Question2;

namespace CSCodeTest.Tests
{
    [TestClass]
    public class PositionFactoryTests
    {

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsZero()
        {
            // Arrange
            PositionFactory factory = new PositionFactory();

            // Act
            Position position = factory.GetPosition(0);

            // Assert
            Assert.IsInstanceOfType(position, typeof(Manager));
        }

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsOne()
        {
            // Arrange
            PositionFactory factory = new PositionFactory();

            // Act
            Position position = factory.GetPosition(1);

            // Assert
            Assert.IsInstanceOfType(position, typeof(Clerk));
        }

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsTwo()
        {
            // Arrange
            PositionFactory factory = new PositionFactory();

            // Act
            Position position = factory.GetPosition(2);

            // Assert
            Assert.IsInstanceOfType(position, typeof(Clerk));
        }

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsThree()
        {
            // Arrange
            PositionFactory factory = new PositionFactory();
             
            // Act
            Position position = factory.GetPosition(3);

            // Assert
            Assert.IsInstanceOfType(position, typeof(Programmer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_GetPosition_ThrowsArgumentOutOfRangeException_WhenIDIsInvalid()
        {
            // Arrange
            PositionFactory factory = new PositionFactory();

            // Act
            Position position = factory.GetPosition(999);
        }

        [TestMethod]
        public void Test_ProgrammerTitleGet_ReturnsCorrectString_WhenCalled()
        {
            // Arrange
            Programmer programmer = new Programmer();
            string expected = "Programmer";

            // Act
            string result = programmer.Title;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ManagerTitleGet_ReturnsCorrectString_WhenCalled()
        {
            // Arrange
            Manager manager = new Manager();
            string expected = "Manager";

            // Act
            string result = manager.Title;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ClerkTitleGet_ReturnsCorrectString_WhenCalled()
        {
            // Arrange
            Clerk clerk = new Clerk();
            string expected = "Clerk";

            // Act
            string result = clerk.Title;

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
