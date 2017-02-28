using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactoryClassQuestion2;

namespace QuestionsTests
{
    [TestClass]
    public class Question2Tests
    {
        PositionFactory2b factoryB;
        PositionFactory2a factoryA;

        [TestInitialize]
        public void Setup()
        {
            factoryB = new PositionFactory2b();
            factoryA = new PositionFactory2a();
        }

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsZero()
        {
            //Arrange

            //Act
            Position position = factoryA.CreateNewPosition(0);

            //Assert
            Assert.IsInstanceOfType(position, typeof(Manager));
        }

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsOne()
        {
            //Arrange

            //Act
            Position position = factoryA.CreateNewPosition(1);

            //Assert
            Assert.IsInstanceOfType(position, typeof(Clerk));
        }

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsTwo()
        {
            //Arrange
            PositionFactory2a factorya = new PositionFactory2a();
            //Act
            Position position = factorya.CreateNewPosition(2);

            //Assert
            Assert.IsInstanceOfType(position, typeof(Clerk));
        }

        [TestMethod]
        public void Test_GetPosition_ReturnsCorrectObjectType_WhenIDIsThree()
        {
            //Arrange

            //Act
            Position position = factoryA.CreateNewPosition(3);

            //Assert
            Assert.IsInstanceOfType(position, typeof(Programmer));
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Test_GetPosition_ReturnsException_WhenIncorrectID()
        {
            //Arrange

            //Act
            Position position = factoryA.CreateNewPosition(999);
            //Assert
        }

        [TestMethod]
        public void Test_ProgrammerTitleGet_ReturnsCorrectString_WhenCalled()
        {
            //Arrange
            Programmer programmer = new Programmer();
            string expected = "Programmer";

            //Act
            string result = programmer.Title;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ManagerTitleGet_ReturnsCorrectString_WhenCalled()
        {
            //Arrange
            Manager manager = new Manager();
            string expected = "Manager";

            //Act
            string result = manager.Title;

            //Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void Test_ClerkTitleGet_ReturnsCorrectString_WhenCalled()
        {
            //Arrange
            Clerk clerk = new Clerk();
            string expected = "Clerk";

            //Act
            string result = clerk.Title;

            //Assert
            Assert.AreEqual(expected, result);


        }
    }
}
