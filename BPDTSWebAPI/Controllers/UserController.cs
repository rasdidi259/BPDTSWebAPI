using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            var listOfUsers = await _usersRepository.GetAllUsersAsync();
            return Ok(listOfUsers);
        }
    }
}