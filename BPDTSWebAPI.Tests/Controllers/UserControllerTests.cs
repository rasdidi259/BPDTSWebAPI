
using AutoMapper;
using BPDTSWebAPI.Controllers;
using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Models;
using BPDTSWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BPDTSWebAPI.Tests.Controllers
{
    public class UserControllerTests
    {
        /// <summary>
        /// Private  Member for IUsersRepository
        /// </summary>
        private readonly Mock<IUsersRepository> _userRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        [Fact]
        public async Task GetAllUsers_Nocondition_ReturnsAll()
        {
            // Arrange
            int count = 1;//1000;
            var listOfUsers = new List<User>() { new User() {
                Id  =1,
                FirstName = "Tim",
                LastName = "Crow"} };
            var userDTOs = new List<UserDTO>() { new UserDTO() {
                Id  =1,
                FirstName = "Tim",
                LastName = "Crow"}  };
            _userRepoMock.Setup(u => u.GetAllUsersAsync()).Returns(Task.FromResult((IList<User>)listOfUsers));

            _mapperMock.Setup(m=>m.Map<List<UserDTO>>(listOfUsers)).Returns(userDTOs);

            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object);

            // Act
            var actionResult = await controller.GetAllUsers();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var usersResult = result.Value as List<UserDTO>;
            Assert.Equal(count, usersResult.Count());
        }

        [Fact]
        public async Task GetAllUsers_WithoutCondition_ReturnsAllUsers()
        {

            // Arrange 
            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object);

            // Act
            await controller.GetAllUsers();

            // Assert
            _userRepoMock.Verify(u => u.GetAllUsersAsync());
        }

        [Fact]
        public async Task GetUserById_IdPassed_ReturnsRightUser()
        {
            // Arrange 
            var userId = 1;
            var user = new User()
            {
                Id = userId,
                FirstName = "Tim",
                LastName = "Crow"
            };

            var userDTO = new UserDTO()
            {
                Id = userId,
                FirstName = "Tim",
                LastName = "Crow"
            };

            _userRepoMock.Setup(u => u.GetUserByIdAsync(userId)).Returns(Task.FromResult((User)user));
            _mapperMock.Setup(y => y.Map<User, UserDTO>(user)).Returns(userDTO);

            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object);

            // Act
            var actionResult = await controller.GetUserById(userId);


            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualUserResult = result.Value as User;

            Assert.Equal(user.LastName, actualUserResult.LastName);
            Assert.NotNull(actualUserResult);

            // Option 1 Assert
            Assert.Equal(user, actualUserResult);

            // Option 2 Assert
            Assert.Equal(user, (actionResult.Result as OkObjectResult)?.Value);
        }

        [Fact]
        public async Task GetUserById_NoRequestedUser_NotFound()
        {
            //Arrange
            var userId = 90202;
            _userRepoMock.Setup(x => x.GetUserByIdAsync(userId)).Returns(Task.FromResult((User)null));

            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.GetUserById(2);

            // Assert
            Assert.True(result.Result is NotFoundResult);
        }




    }
}
