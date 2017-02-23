using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCodeTest.Question1;

namespace CSCodeTest.Tests
{
    [TestClass]
    public class SingletonExampleTests
    {
        [TestMethod]
        public void Test_Instance_ReturnsTheSameInstance_WhenCalledTwice()
        {
            // Arrange
            SingletonExample resultOne = SingletonExample.Instance();
            SingletonExample resultTwo = SingletonExample.Instance();

            // Act
            

            // Assert
            Assert.AreEqual(resultOne, resultTwo);
        }
    }
}
