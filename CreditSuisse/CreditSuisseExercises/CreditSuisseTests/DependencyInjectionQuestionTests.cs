using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CreditSuisseExercises;

namespace CreditSuisseTests
{
    [TestClass]
    public class DependencyInjectionQuestionTests
    {
        [TestMethod]
        public void Test_Notify_RunsActOnNotificationMethod_OfEnteredINotificationActionObject()
        {
            //Arrange
            Mock<EmailSenderMock> emailSenderMock = new Mock<EmailSenderMock>();

            MissingDependencyInjectionExample dependencyInjectionObject = new MissingDependencyInjectionExample(emailSenderMock.Object);

            emailSenderMock.Setup(x => x.ActOnNotification("Test")).Verifiable();

            //Act
            dependencyInjectionObject.Notify("Test");

            //Assert
            emailSenderMock.Verify(x => x.ActOnNotification("Test"), Times.Once);
        }
    }
}
