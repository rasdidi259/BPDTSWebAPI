
using AutoMapper;
using BPDTSWebAPI.Controllers;
using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Models;
using BPDTSWebAPI.Repository;
using BPDTSWebAPI.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BPDTSWebAPI.Tests.Controllers
{
    public class UserControllerTests
    {
        /// <summary>
        /// Private  Member for IUsersRepository and IMapper
        /// </summary>
        private readonly Mock<IUsersRepository> _userRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<ILogger<UserController>> _loggerMock = new();


        [Fact]
        public async Task GetAllUsers_Nocondition_ReturnsAll()
        {
            // Arrange
            int count = 1;
            var listOfUsers = UserControllerTestBase.GetUsers();
            var userDTOs = UserControllerTestBase.GetUserDTOs();

            _userRepoMock.Setup(u => u.GetAllUsersAsync()).Returns(Task.FromResult((IList<User>)listOfUsers));
            _mapperMock.Setup(m=>m.Map<List<UserDTO>>(listOfUsers)).Returns(userDTOs);

            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object, _loggerMock.Object);

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
            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object, _loggerMock.Object);

            // Act
            await controller.GetAllUsers();

            // Assert
            _userRepoMock.Verify(u => u.GetAllUsersAsync());
        }

        [Fact]
        public async Task GetUserById_IdPassed_ReturnsRightUser()
        {
            // Arrange 
            var userId = 266;
            var user = UserControllerTestBase.GetUser();
            var userDTO = UserControllerTestBase.GetUserDTO();

            _userRepoMock.Setup(u => u.GetUserByIdAsync(userId)).Returns(Task.FromResult((User)user));
            _mapperMock.Setup(m => m.Map<UserDTO>(user)).Returns(userDTO);

            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object, _loggerMock.Object);

            // Act
            var actionResult = await controller.GetUserById(userId);


            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualUserResult = result.Value as UserDTO;

            Assert.Equal(userDTO.Last_Name, actualUserResult.Last_Name);
            Assert.NotNull(actualUserResult);

            // Option 1 Assert
            Assert.Equal(userDTO, actualUserResult);

            // Option 2 Assert
            Assert.Equal(userDTO, (actionResult.Result as OkObjectResult)?.Value);
        }

        [Fact]
        public async Task GetUserById_NoRequestedUser_NotFound()
        {
            //Arrange
            var userId = 90202;
            _userRepoMock.Setup(x => x.GetUserByIdAsync(userId)).Returns(Task.FromResult((User)null));

            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object, _loggerMock.Object);

            // Act
            var result = await controller.GetUserById(2);

            // Assert
            Assert.True(result.Result is NotFoundResult);
        }

        [Fact]
        public async Task GetUserByCity_GivenCityName_ReturnsUser()
        {
            // Arrange        
            var city = "L’govskiy";
            var count = 3;
            var users = UserControllerTestBase.GetUserByCities();             
            var userDTOs = UserControllerTestBase.GetUserByCityDTOs(); 

            _userRepoMock.Setup(u => u.GetUserByCityAsync(city)).Returns(Task.FromResult((List<UserByCity>)users));
            _mapperMock.Setup(m => m.Map<List<UserByCityDTO>>(users)).Returns(userDTOs);
            
            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object, _loggerMock.Object);

            // Act
            var actionResult = await controller.GetUserByCity(city);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualUserResult = result.Value as List<UserByCityDTO>;

            Assert.NotNull(actualUserResult);
            Assert.Equal(count, actualUserResult.Count);
            Assert.Equal(userDTOs.Count, actualUserResult.Count);
            Assert.Equal(userDTOs, actualUserResult);
        }

        [Fact]
        public async Task GetUserByCity_GivenLatAndLon_ReturnAllUsers()
        {
            // Arrange
            var count = 3;
            var userByCities = UserControllerTestBase.GetUserByCities();
            var userByCityDTOs = UserControllerTestBase.GetUserByCityDTOs();

            _userRepoMock.Setup(u=>u.GetUserByCordinatesAsync()).Returns(Task.FromResult(userByCities));

            _mapperMock.Setup(m => m.Map<List<UserByCityDTO>>(userByCities)).Returns(userByCityDTOs);

            var controller = new UserController(_userRepoMock.Object, _mapperMock.Object, _loggerMock.Object);

            // Act
            var actionResult = await controller.GetUserByCordinates();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var actualUserResult = result.Value as List<UserByCityDTO>;

            Assert.NotNull(actualUserResult);
            Assert.Equal(count, actualUserResult.Count);
            Assert.Equal(userByCityDTOs.Count, actualUserResult.Count);            
        }
    }
}
