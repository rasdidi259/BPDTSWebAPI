using BPDTSWebAPI.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Repository
{
    public interface IUsersRepository
    {
        Task<IList<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int userId);

        Task<List<UserByCity>> GetUserByCityAsync(string city);
    }
}