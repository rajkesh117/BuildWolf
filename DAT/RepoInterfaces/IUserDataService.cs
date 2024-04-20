using BuildWolf.Modules.MasterModules;
using BuildWolf.Modules.UserModules;
using BuildWolf.Modules.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoInterfaces
{
    public interface IUserDataService
    {
        public Task<IEnumerable<Users>> GetAllUsers();
        public Task<Users> GetUserById(Guid id);
        public Task<bool> CreateUser(Users user);
        public Task<Users> UpdateUser(Users user);
        public Task<bool> DeleteUser(Guid id);

        public Task<IEnumerable<UserViewModel>> GetUsersFilter(UserFilterModel userFilter);
    }
}
