using LassoApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LassoApi.Services
{
    public class UsersService : IUsersService
    {
        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser()
        {
            throw new NotImplementedException();
        }
    }
}
