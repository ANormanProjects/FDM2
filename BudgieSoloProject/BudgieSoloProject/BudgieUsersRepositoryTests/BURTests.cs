using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using BudgieDatabaseLayer;

namespace BudgieEntityFramework.Tests
{
    [TestClass]
    public class BURTests
    {
        Mock<DbSet<BudgieUser>> dbSetMock;

        [TestInitialize]
        public void Setup()
        {
            dbSetMock = new Mock<DbSet<BudgieUser>>();
        }
        [TestMethod]
        public void Test_GetAllBrokers_ReturnsAllBrokers()
        {
            //ARRANGE
            Mock<BudgieUser> bb = new Mock<BudgieUser>();
            Mock<BudgieUser> an = new Mock<BudgieUser>();
            Mock<BudgieUser> sn = new Mock<BudgieUser>();

            var expected = new List<BudgieUser>
            {
                bb.Object,
                an.Object,
                sn.Object
                //new BudgieUser{ id = 1, firstName = "Ben", lastName = "Bowes", emailAddress = "benjamin.bowes@fdmgroup.com", dob = "040191", password = "password123"},
                //new BudgieUser{ id = 1, firstName = "Andrew", lastName = "Norman", emailAddress = "andrew.norman@fdmgroup.com", dob = "010494", password = "password123"},
            };

            var testData = new List<BudgieUser>
            {
                bb.Object,
                an.Object,
                sn.Object

            }.AsQueryable();
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.budgieUsers).Returns(dbSetMock.Object);

            BudgieUserRepository classUnderTest = new BudgieUserRepository(contextMock.Object);

            //ACT
            var actual = classUnderTest.GetAllBudgieUsers();

            //ASSERT
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_AddNewBudgieUser_CallsAddABudgieUserToDatabase_AndSavesChangesOnContext()
        {
            //ARRANGE
            Mock<BudgieUser> bb = new Mock<BudgieUser>();

            var testData = new List<BudgieUser>().AsQueryable();
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.budgieUsers).Returns(dbSetMock.Object);

            BudgieUserRepository classUnderTest = new BudgieUserRepository(contextMock.Object);

            //ACT
            classUnderTest.addNewBudgieUser(bb.Object);

            //ASSERT
            dbSetMock.Verify(c => c.Add(It.IsAny<BudgieUser>()), Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_UpdateBudgieUser_RunsUpdateBudgieUserToDatabase_AndSaveChangesOnContext()
        {
            //ARRANGE 
            Mock<BudgieUser> bb = new Mock<BudgieUser>();

            bb.Setup(c => c.id).Returns(1);

            var testData = new List<BudgieUser> { bb.Object }.AsQueryable();
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.budgieUsers).Returns(dbSetMock.Object);

            BudgieUserRepository burTest = new BudgieUserRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);

            //ACT
            bb.SetupSet(c => c.firstName = "Ben").Verifiable();
            bb.SetupSet(c => c.lastName = "Bowes").Verifiable();
            bb.SetupSet(c => c.dob = "040191").Verifiable();


            burTest.updateBudgieUser(1, "Ben", "Bowes", "040191");

            //ASSERT
            dbSetMock.Verify(c => c.Find(1));
            bb.VerifySet(c => c.firstName = "Ben");
            bb.VerifySet(c => c.lastName = "Bowes");
            bb.VerifySet(c => c.dob = "040191");
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_RemoveBudgieUser_CallsRemoveABudgieUserToDatabase_AndSaveChangesOnContext()
        {
            //ARRANGE
            //ARRANGE 
            Mock<BudgieUser> bb = new Mock<BudgieUser>();

            bb.Setup(c => c.id).Returns(1);

            var testData = new List<BudgieUser> { bb.Object }.AsQueryable();
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Provider).Returns(testData.Provider);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.Expression).Returns(testData.Expression);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.ElementType).Returns(testData.ElementType);
            dbSetMock.As<IQueryable<BudgieUser>>().Setup(d => d.GetEnumerator()).Returns(testData.GetEnumerator);

            var contextMock = new Mock<BudgieDBCFModel>();
            contextMock.Setup(c => c.budgieUsers).Returns(dbSetMock.Object);

            BudgieUserRepository burTest = new BudgieUserRepository(contextMock.Object);
            dbSetMock.Setup(c => c.Find(1)).Returns(bb.Object);

            //ACT
            burTest.removeBudgieUser(1);

            //ASSERT
            dbSetMock.Verify(c => c.Find(1), Times.Once);
            dbSetMock.Verify(c => c.Remove(bb.Object), Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

    }
}
