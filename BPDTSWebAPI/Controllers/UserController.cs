using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Controllers
{

    public class UserController :ControllerBase
    {
        private IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ActionResult<User>> GetAllUsers()
        {
            var newUser = new User()
            {
                Id = 1,
                FirstName = "Jon",
                LastName = "Doe"
            };
            var listOfUsers = new List<User>() { newUser };
            return Ok(listOfUsers);
        }
    }
}