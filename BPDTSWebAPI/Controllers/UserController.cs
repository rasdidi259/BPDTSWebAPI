using AutoMapper;
using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Models;
using BPDTSWebAPI.Repository;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllUsers")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)] // Override Cache and Validating Data for Specific Endpoints
        [HttpCacheValidation(MustRevalidate = false)] // Override Cache and Validating Data for Specific Endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _usersRepository.GetAllUsersAsync();
            var userDTOs = _mapper.Map<List<UserDTO>>(users);
            return Ok(userDTOs);
        }

    
        [HttpGet("{userId:int}", Name = "GetUserById")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)] 
        [HttpCacheValidation(MustRevalidate = false)] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> GetUserById(int userId)
        {
            var user = await _usersRepository.GetUserByIdAsync(userId);
            
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        //[HttpGet("GetUserByCity/{city:string}")]
        //[HttpGet("{city:string}", Name = "GetUserByCity")]
        [HttpGet]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)] 
        [HttpCacheValidation(MustRevalidate = false)] 
        [Route("GetUserByCity/{city}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserByCityDTO>>> GetUserByCity(string city)
        {
            var users = await _usersRepository.GetUserByCityAsync(city);
            if (users == null)
            {
                return NotFound();
            }

            var userDTOs = _mapper.Map<List<UserByCityDTO>>(users);
            //var newUser = new User()
            //{
            //    Id = 1,
            //    FirstName = "Tim",
            //    LastName = "Crow",
            //    City=city
            //};

            return Ok(userDTOs);
        }
    }
}