using BuildWolf.BAT.Interfaces;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.UserModules;
using BuildWolf.Modules.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.BAT.Services
{
	public class UserService:IUserService
	{
		private readonly IUserDataService _userDataService;

		public UserService(IUserDataService userDataService)
		{
			_userDataService = userDataService;
		}

		public async Task<bool> CreateUser(Users user)
		{
			var success =  await _userDataService.CreateUser(user);
			return success;
		}

		public async Task<bool> DeleteUser(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Users>> GetAllUsers()
		{
			throw new NotImplementedException();
		}

		public async Task<Users> GetUserById(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<UserViewModel>> GetUsersFilter(UserFilterModel userFilter)
		{
			return await _userDataService.GetUsersFilter(userFilter);
		}

		public async Task<Users> UpdateUser(Users user)
		{
			throw new NotImplementedException();
		}
	}
}
