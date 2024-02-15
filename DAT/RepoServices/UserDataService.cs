using BuildWolf.DAT.DBContext;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.UserModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoServices
{
    public class UserDataService : IUserDataService
    {
        private readonly DapperDBContext _context;
        public UserDataService(DapperDBContext context)
        {
            _context = context;
        }

        public Task<bool> CreateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Users> UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
