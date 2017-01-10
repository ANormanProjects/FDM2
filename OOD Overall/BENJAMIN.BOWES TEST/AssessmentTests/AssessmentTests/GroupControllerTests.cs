using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Application;

namespace AssessmentTests
{
    [TestClass]
    public class GroupControllerTests
    {
        private GroupController traineeGroupController;
        private Mock<Trainee> mockTrainee;
        private Mock<DatabaseWriter> mockWriter;
        private Mock<DatabaseReader> mockReader;
        private Mock<Dictionary<String, Trainee>> mockDictionary;

        [TestInitialize]
        public void setup()
        {
            mockDictionary = new Mock<Dictionary<string, Trainee>>();

            mockTrainee = new Mock<Trainee>();

            mockWriter = new Mock<DatabaseWriter>();

            mockReader = new Mock<DatabaseReader>();
            mockReader.Setup(r => r.ReadGroup()).Returns(mockDictionary.Object);

            traineeGroupController = new GroupController(mockWriter.Object, mockReader.Object);
        }

        [TestMethod]
        public void test_GetAllTraineesMethod_CallsReadGroupMethodOfInjectedDatabaseReader_WhenCalled()
        {
            traineeGroupController.GetAllTrainees();
            mockReader.Verify(r => r.ReadGroup(), Times.Once());
        }

        [TestMethod]
        public void test_GetAllTraineesMethod_ReturnsDictionaryGivenToItByReadGroupMethodOfInjectedReader_WhenCalled()
        {
            Dictionary<string, Trainee> allTrainees = traineeGroupController.GetAllTrainees();
            CollectionAssert.AreEqual(mockDictionary.Object, allTrainees);
        }

        [TestMethod]
        public void test_GetAllTraineesMethod_ReturnsAnEmptyDictionary_IfNoTraineesAreInGroup()
        {
            Dictionary<string, Trainee> allTrainees = traineeGroupController.GetAllTrainees();
            Assert.AreEqual(0, allTrainees.Count);
        }

        [TestMethod]
        public void test_GetAllTrainees_ReturnsDictionaryOfSizeOne_IfOneTraineeIsInTheGroup()
        {
            mockDictionary.Object.Add("1", new Trainee());
            Dictionary<string, Trainee> allTrainees = traineeGroupController.GetAllTrainees();
            Assert.AreEqual(1, allTrainees.Count);
        }

        [TestMethod]
        public void test_AddTraineeMethod_CallsAddTraineeMethodOfDatabaseWriter_WhenCalled()
        {
            traineeGroupController.AddTrainee(mockTrainee.Object);
            mockWriter.Verify(w => w.AddTrainee(It.IsAny<Trainee>()), Times.Once());
        }

        [TestMethod]
        public void test_AddTraineeMethod_CallsAddTraineeMethodOfDatabaseWriterPassingTraineeObjectDefinedAsInput_WhenCalled()
        {
            traineeGroupController.AddTrainee(mockTrainee.Object);
            mockWriter.Verify(w => w.AddTrainee(mockTrainee.Object), Times.Once());
        }

        [TestMethod]
        public void test_RemoveTraineeMethodByUsername_CallsDeleteTraineeByUsernameMethodOfInjectedWriter_WhenCalled()
        {
            traineeGroupController.RemoveTraineeByUsername("");
            mockWriter.Verify(w => w.DeleteTraineeByUsername(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void test_RemoveTraineeMethodByUsername_CallsDeleteTraineeByUsernameMethodOfInjectedWriterPassingUsernameDefinedAsInput_WhenCalled()
        {
            string username = "john.smith";
            traineeGroupController.RemoveTraineeByUsername(username);
            mockWriter.Verify(w => w.DeleteTraineeByUsername(username), Times.Once());
        }
    }
}
