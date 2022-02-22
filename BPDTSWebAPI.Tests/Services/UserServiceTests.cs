using BPDTSWebAPI.Controllers;
using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BPDTSWebAPI.Tests.Services
{
    public class UserServiceTests
    {

        [Fact]
        public async Task GetAllUsers_Nocondition_ReturnsAll()
        {
            // Arrange
            int count = 1;//1000;
            var listOfUsers = new List<User>() { new User() };
            var usersMock = new Mock<IUsersRepository>();
            usersMock.Setup(u => u.GetAllUsersAsync()).Returns(Task.FromResult((IList<User>)listOfUsers));

            var controller = new UserController(usersMock.Object);
            // Act
            var actionResult = await controller.GetAllUsers();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var usersResult = result.Value as IEnumerable<User>;
            Assert.Equal(count, usersResult.Count());
        }
    }
}
