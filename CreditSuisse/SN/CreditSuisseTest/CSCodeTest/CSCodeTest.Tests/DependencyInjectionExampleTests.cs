using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCodeTest.Question4;
using Moq;

namespace CSCodeTest.Tests
{
    [TestClass]
    public class DependencyInjectionExampleTests
    {
        [TestMethod]
        public void Test_Notify_CallsActOnNotificationMethodOfInjectedObject_WhenCalled()
        {
            // Arrange
            Mock<INotificationAction> mockAction = new Mock<INotificationAction>();
            DependencyInjectionExample example = new DependencyInjectionExample(mockAction.Object);
            string message = "Hello";

            // Act
            example.Notify(message);

            // Assert
            mockAction.Verify(m => m.ActOnNotification(message));
        }
    }
}
