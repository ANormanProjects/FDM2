using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditSuisseExercises;
using Moq;

namespace CreditSuisseTests
{
    [TestClass]
    public class FactoryImplementation1QuestionTests
    {
        FactoryImplementation1 factory1;

        [TestInitialize]
        public void Setup()
        {
            factory1 = new FactoryImplementation1();
        }

        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewProgrammer_WhenRunWith3Input()
        {
            //Arrange

            //Act
            var actual = factory1.CreateNewPosition(3);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Programmer));
        }

        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewClerk_WhenRunWith2Input()
        {
            //Arrange

            //Act
            var actual = factory1.CreateNewPosition(2);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Clerk));
        }

        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewClerk_WhenRunWith1Input()
        {
            //Arrange

            //Act
            var actual = factory1.CreateNewPosition(1);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Clerk));
        }

        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewManager_WhenRunWith0Input()
        {
            //Arrange

            //Act
            var actual = factory1.CreateNewPosition(0);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Manager));
        }
    }
    [TestClass]
    public class FactoryImplementation2QuestionTests
    {
        FactoryImplementation2 factory2;

        [TestInitialize]
        public void Setup()
        {
            factory2 = new FactoryImplementation2();
        }

        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewProgrammer_WhenRunWith3Input()
        {
            //Arrange

            //Act
            var actual = factory2.CreateNewPosition(3);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Programmer));
        }


        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewClerk_WhenRunWith2Input()
        {
            //Arrange

            //Act
            var actual = factory2.CreateNewPosition(2);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Clerk));
        }

        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewClerk_WhenRunWith1Input()
        {
            //Arrange

            //Act
            var actual = factory2.CreateNewPosition(1);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Clerk));
        }

        [TestMethod]
        public void Test_CreateNewPosition_ReturnsNewManager_WhenRunWith0Input()
        {
            //Arrange

            //Act
            var actual = factory2.CreateNewPosition(0);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Manager));
        }
    }
}
