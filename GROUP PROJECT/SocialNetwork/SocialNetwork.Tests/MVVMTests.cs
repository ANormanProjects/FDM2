using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.MVVM.ViewModel;
using Moq;
using SocialNetwork.DataAccess;
using SocialNetwork.Logic;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using SocialNetwork.MVVM;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class MVVMTests
    {

        Mock<Repository<User>> userRepo;
        Mock<Repository<Group>> groupRepo;
        Mock<Repository<Post>> postRepo;
        Mock<Repository<Comment>> commentRepo;
        Mock<UserAccountLogic> userAccountLogic;
        Mock<GroupAccountLogic> groupAccountLogic;
        ObservableCollection<User> userList;
        ObservableCollection<Group> groupList;
        UserWPFViewModel userWPFVMTests;
        GroupWPFViewModel groupWPFVMTests;
        Mock<ICommand> command;
        Mock<User> testUser;
        Mock<Group> testGroup;

        [TestInitialize]
        public void Setup()
        {
            userRepo = new Mock<Repository<User>>();
            groupRepo = new Mock<Repository<Group>>();
            postRepo = new Mock<Repository<Post>>();
            commentRepo = new Mock<Repository<Comment>>();
            userAccountLogic = new Mock<UserAccountLogic>(userRepo.Object);
            groupAccountLogic = new Mock<GroupAccountLogic>(groupRepo.Object, postRepo.Object, commentRepo.Object, userRepo.Object);
            userWPFVMTests = new UserWPFViewModel(userAccountLogic.Object);
            groupWPFVMTests = new GroupWPFViewModel(groupAccountLogic.Object);
            userList = new ObservableCollection<User>();
            groupList = new ObservableCollection<Group>();
            command = new Mock<ICommand>();
            testUser = new Mock<User>();
            testGroup = new Mock<Group>();
        }

        [TestMethod]
        public void Test_WPF_UserWPFViewModelConstructor()
        {
            //ARRANGE
            UserWPFViewModel UserWPFVM = new UserWPFViewModel();
            //ACT

            //ASSERT
            Assert.IsNotNull(UserWPFVM._userRepository);
            Assert.IsNotNull(UserWPFVM.userAccLogic);
        }

        [TestMethod]
        public void Test_WPF_GroupWPFViewModelConstructor()
        {
            //ARRANGE
            GroupWPFViewModel GroupWPFVM = new GroupWPFViewModel(); 
            
            //ACT

            //ASSERT
            Assert.IsNotNull(GroupWPFVM.groupRepo);
            Assert.IsNotNull(GroupWPFVM.postRepo);
            Assert.IsNotNull(GroupWPFVM.commentRepo);
            Assert.IsNotNull(GroupWPFVM.userRepo);
            Assert.IsNotNull(GroupWPFVM.groupAccLogic);
        }

        [TestMethod]
        public void Test_WPF_ListOfAllUsers_RunsGetAllUsersToDisplayListToWPFApp()
        {
            //ARRANGE

            List<User> newUserList = new List<User>();
            userAccountLogic.Setup(c => c.GetAllUserAccounts()).Returns(newUserList);
            userWPFVMTests.userAccLogic = userAccountLogic.Object;

            //ACT
            userWPFVMTests.ListAllUsers();

            //ASSERT
            userAccountLogic.Verify(c => c.GetAllUserAccounts(), Times.Once);
            CollectionAssert.AreEquivalent(userWPFVMTests.user, newUserList);
        }

        [TestMethod]
        public void Test_WPF_ListAllGroups_RunsGetAllGroupsToDisplayListToWPFApp()
        {
            //ARRANGE
            List<Group> newGroupList = new List<Group>();
            groupAccountLogic.Setup(c => c.GetAllGroups()).Returns(newGroupList);
            groupWPFVMTests.groupAccLogic = groupAccountLogic.Object;

            //ACT
            groupWPFVMTests.ListAllGroups();

            //ASSERT
            groupAccountLogic.Verify(c => c.GetAllGroups(), Times.Once);
            CollectionAssert.AreEquivalent(groupWPFVMTests.group, newGroupList);
        }

        
        [TestMethod]
        public void Test_WPF_AddUserMethod_RunsRegisterMethodWhenCalledToAddNewUserToTheDatabaseFromWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.Register(It.IsAny<User>()));
            userWPFVMTests.userAccLogic = userAccountLogic.Object;

            //ACT
            userWPFVMTests.AddUser();

            //ASSERT
            userAccountLogic.Verify(c => c.Register(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void Test_WPF_AddGroupMethod_RunsCreateGroupMethodWhenCalledToAddNewGroupToDatabaseFromWPFApp()
        {
            //ARRANGE
            groupAccountLogic.Setup(c => c.CreateGroup(It.IsAny<Group>()));
            groupWPFVMTests.groupAccLogic = groupAccountLogic.Object;

            //ACT
            groupWPFVMTests.AddGroup();

            //ASSERT
            groupAccountLogic.Verify(c => c.CreateGroup(It.IsAny<Group>()), Times.Once);
        }      

        [TestMethod]
        public void Test_WPF_AddGroupMethod_ThrowsEntityAlreadyExistsExceptionWhenGroupNameIsAlreadyInTheDatabase()
        {
            //ARRANGE
            groupAccountLogic.Setup(c => c.CreateGroup(It.IsAny<Group>())).Throws(new EntityAlreadyExistsException());
            groupWPFVMTests.groupID = 1;
            groupWPFVMTests.groupName = "Test";

            //ACT
            groupWPFVMTests.AddGroup();

            //ASSERT
            groupAccountLogic.Setup(c => c.CreateGroup(It.IsAny<Group>()));
        }

        [TestMethod]
        public void Test_WPF_EditUserMethod_RunsEditMethodWhenCalledToEditExistingUserInTheDatabaseFromWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.ViewAccountInfo("Test")).Returns(testUser.Object);
            userAccountLogic.Setup(c => c.EditUser(testUser.Object, "Test", "Test", "Test", "Test"));
            userWPFVMTests.userAccLogic = userAccountLogic.Object;
            userWPFVMTests.userId = 1;
            userWPFVMTests.username = "Test";
            userWPFVMTests.fullName = "Test";
            userWPFVMTests.gender = "Test";
            userWPFVMTests.role = "Test";
            userWPFVMTests.password = "Test";

            //ACT
            userWPFVMTests.EditUser();

            //ASSERT
            userAccountLogic.Verify(c => c.ViewAccountInfo("Test"));
            userAccountLogic.Verify(c => c.EditUser(testUser.Object, "Test", "Test", "Test", "Test"));
        }

        [TestMethod]
        public void Test_WPF_EditUserMethod_ThrowsEntityNotFoundException_WhenUsernameIsNotInDatabase()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.ViewAccountInfo("Test")).Throws(new EntityNotFoundException());
            userWPFVMTests.username = "Test";

            //ACT
            userWPFVMTests.EditUser();

            //ASSERT
            userAccountLogic.Verify(c => c.ViewAccountInfo("Test"));
            
        }

        [TestMethod]
        public void Test_Remove_UserMethod_RunsRemoveMethodWhenCalledToRemoveExistingUserInTheDatabaseFromWPFApp()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.ViewAccountInfo("Test")).Returns(testUser.Object);
            userAccountLogic.Setup(c => c.RemoveUser(testUser.Object));
            userWPFVMTests.userAccLogic = userAccountLogic.Object;
            userWPFVMTests.username = "Test";


            //ACT
            userWPFVMTests.RemoveUser();

            //ASSERT
            userAccountLogic.Verify(c => c.ViewAccountInfo("Test"));
            userAccountLogic.Verify(c => c.RemoveUser(testUser.Object));
        }

        [TestMethod]
        public void Test_WPF_RemoveUserMethod_ThrowsEntityNotFoundException_WhenUsernameIsNotInDatabase()
        {
            //ARRANGE
            userAccountLogic.Setup(c => c.ViewAccountInfo("Test")).Throws(new EntityNotFoundException());
            userWPFVMTests.username = "Test";

            //ACT
            userWPFVMTests.RemoveUser();

            //ASSERT
            userAccountLogic.Verify(c => c.ViewAccountInfo("Test"));
        }


        [TestMethod]
        public void Test_WPF_RemoveGroupMethod_RunsRemoveGroupMethodWhenCalledToRemoveGroupFromDatabase()
        {
            //ARRANGE
            groupAccountLogic.Setup(c => c.ViewGroupInfo("Test")).Returns(testGroup.Object);
            groupAccountLogic.Setup(c => c.RemoveGroup(testGroup.Object));
            groupWPFVMTests.groupAccLogic = groupAccountLogic.Object;
            groupWPFVMTests.groupName = "Test";

            
            //ACT
            groupWPFVMTests.RemoveGroup();

            //ASSERT
            groupAccountLogic.Verify(c => c.ViewGroupInfo("Test"));
            groupAccountLogic.Verify(c => c.RemoveGroup(testGroup.Object));
        }

        [TestMethod]
        public void Test_WPF_RemoveGroupMethod_ThrowsEntityNotFoundException_WhenGroupNameIsNotInDatabase()
        {
            //ARRANGE
            groupAccountLogic.Setup(c => c.ViewGroupInfo("Test")).Throws(new EntityNotFoundException());
            groupWPFVMTests.groupName = "Test";

            //ACT
            groupWPFVMTests.RemoveGroup();

            //ASSERT
            groupAccountLogic.Verify(c => c.ViewGroupInfo("Test"));
        }

        [TestMethod]
        public void Test_ListAllUsersCommand_Returns_ListAllUsersCommand_WhenNotNull()
        {
            //ARRANGE
            userWPFVMTests.ListAllUsersCommand = command.Object;

            //ACT
            var test = userWPFVMTests.ListAllUsersCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_ListAllUsersCommand_Returns_NewListAllUsersCommand_WhenNull()
        {
            //ARRANGE
            userWPFVMTests.ListAllUsersCommand = null;
           
            //ASSERT         
            Assert.IsNotNull(userWPFVMTests.ListAllUsersCommand);

        }

        [TestMethod]
        public void Test_AddUserCommand_Returns_AddUserCommand_WhenNotNull()
        {
            //ARRANGE
            userWPFVMTests.addUserCommand = command.Object;

            //ACT
            var test = userWPFVMTests.addUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_AddUserCommand_Returns_AddUserCommand_WhenNull()
        {
            //ARRANGE
            userWPFVMTests.addUserCommand = null;

            //ACT

            //ASSERT
            Assert.IsNotNull(userWPFVMTests.addUserCommand);

        }

        [TestMethod]
        public void Test_EditUserCommand_Returns_EditUserCommand_WhenNotNull()
        {
            //ARRANGE
            userWPFVMTests.editUserCommand = command.Object;

            //ACT
            var test = userWPFVMTests.editUserCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_EditUserCommand_Returns_EditUserCommand_WhenNull()
        {
            //ARRANGE
            userWPFVMTests.editUserCommand = null;

            //ACT

            //ASSERT
            Assert.IsNotNull(userWPFVMTests.editUserCommand);
        }

        [TestMethod]
        public void Test_RemoveUserCommand_Returns_RemoveUserCommand_WhenNotNull()
        {
            //ARRANGE
            userWPFVMTests.removeUserCommand = command.Object;

            //ACT
            var test = userWPFVMTests.removeUserCommand;

            //ACT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_RemoveUserCommand_Returns_RemoveUserCommand_WhenNull()
        {
            //ARRANGE
            userWPFVMTests.removeUserCommand = null;

            //ACT

            //ASSERT
            Assert.IsNotNull(userWPFVMTests.removeUserCommand);
        }

        [TestMethod]
        public void Test_ListAllGroupsCommand_Returns_ListAllGroupsCommand_WhenNotNull()
        {
            //ARRANGE
            groupWPFVMTests.listAllGroupsCommand = command.Object;


            //ACT
            var tests = groupWPFVMTests.listAllGroupsCommand;

            //ASSERT
            Assert.AreEqual(command.Object, tests);

        }

        [TestMethod]
        public void Test_ListAllGroupsCommand_ReturnsListAllGroupsCommand_WhenNull()
        {
            //ARRANGE
            groupWPFVMTests.listAllGroupsCommand = null;

            //ACT

            //ASSERT
            Assert.IsNotNull(groupWPFVMTests.listAllGroupsCommand);
        }

        [TestMethod]
        public void Test_AddGroupCommand_Returns_AddGroupCommand_WhenNotNull()
        {
            //ARRANGE
            groupWPFVMTests.addGroupCommand = command.Object;

            //ACT
            var tests = groupWPFVMTests.addGroupCommand;

            //ASSERT
            Assert.AreEqual(command.Object, tests);
        }

        [TestMethod]
        public void Test_AddGroupCommand_Return_AddGroupCommand_WhenNull()
        {
            //ARRANGE
            groupWPFVMTests.addGroupCommand = null;

            //ACT

            //ASSERT
            Assert.IsNotNull(groupWPFVMTests.addGroupCommand);
        }

        [TestMethod]
        public void Test_RemoveGroupCommand_Return_RemoveGroupCommand_WhenNotNull()
        {
            //ARRANGE
            groupWPFVMTests.removeGroupCommand = command.Object;


            //ACT
            var test = groupWPFVMTests.removeGroupCommand;

            //ASSERT
            Assert.AreEqual(command.Object, test);
        }

        [TestMethod]
        public void Test_RemoveGroupCommand_Return_RemoveGroupCommand_WhenNull()
        {
            //ARRANGE
            groupWPFVMTests.removeGroupCommand = null;

            //ACT

            //ASSERT
            Assert.IsNotNull(groupWPFVMTests.removeGroupCommand);
        }

    }
}
