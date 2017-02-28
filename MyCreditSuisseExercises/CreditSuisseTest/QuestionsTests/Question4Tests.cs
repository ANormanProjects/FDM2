using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MissingDependencyQuestion4;

namespace QuestionsTests
{
    [TestClass]
    public class Question4Tests
    {
        [TestMethod]
        public void Test_Notify_CallsActOnNotificationMethodOfInjectedObject_WhenCalled()
        {
            //Arrange
            Mock<INotificationAction> mockAction = new Mock<INotificationAction>();
            DependencyInjectionExample example = new DependencyInjectionExample(mockAction.Object);
            string message = "Hello";

            //Act
            example.Notify(message);

            //Assert
            mockAction.Verify(c => c.ActOnNotification(message));
        }
    }
}
