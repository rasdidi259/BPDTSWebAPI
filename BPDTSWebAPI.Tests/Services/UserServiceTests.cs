using BPDTSWebAPI.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BPDTSWebAPI.Tests.Services
{
    public class UserServiceTests
    {

        [Fact]
        public async Task GetAllUsers_Nocondition_ReturnsAll()
        {

            throw new NotImplementedException();
            //// Arrange
            //int count = 1;//1000;
            //var listOfUsers = new List<User>() { new User() };
            //var usersMock = new Mock<IUsersRepository>();
            //usersMock.Setup(u => u.GetAllUsersAsync()).Returns(Task.FromResult((IList<User>)listOfUsers));

            //var controller = new UserController(usersMock.Object);
            //// Act
            //var actionResult = await controller.GetAllUsers();

            //// Assert
            //var result = actionResult.Result as OkObjectResult;
            //var usersResult = result.Value as IEnumerable<User>;
            //Assert.Equal(count, usersResult.Count());
        }

        public async Task GetAllUsersAsync_MethodIsCalled_ReturnsRightUser()
        {
            throw new NotImplementedException();
            //var count = 1;
            //UsersRepository userRepoMock = new UsersRepository();

            //// Act
            //var listOfUsers = userRepoMock.GetAllUsersAsync();

            //Assert.Equal();
        }
    }
}
