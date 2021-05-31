using LassoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LassoApi.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser();
    }
}
