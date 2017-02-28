using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingletonPattern;

namespace QuestionsTests
{
    [TestClass]
    public class Question1Tests
    {
        [TestMethod]
        public void Test_Instance_ReturnsTheSameInstance_WhenCalledTwice()
        {
            //Arrange
            SingletonLockv2 singletonEx = SingletonLockv2.Instance();
            SingletonLockv2 singletonEx2 = SingletonLockv2.Instance();

            //Act


            //Assert
            Assert.AreEqual(singletonEx, singletonEx2);


        }
    }
}
