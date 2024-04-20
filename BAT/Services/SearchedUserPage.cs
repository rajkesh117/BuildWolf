using BuildWolf.BAT.Interfaces;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.UserModules;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildWolf.BAT.Services
{
    public class SearchedUserPage : ISearchedUserPage
    {
        private readonly ISearchedUserPageDisplayData _displayData;

        public SearchedUserPage(ISearchedUserPageDisplayData displayData)
        {
            _displayData = displayData;
        }

        public async Task<bool> CreateArchitectWorkedMapping(UserArchitectWorkedMapping data)
        {
            var created = await _displayData.CreateUserArchitectWorked(data);
            if (created) return created;
            return false;
        }

        public async Task<IEnumerable<UserArchitectWorkedMapping>> GetAllArchitectWorkedMapping()
        {
            var getAllData = await _displayData.GetAllUserArchitectWorked();
            return getAllData;
        }

        public async Task<bool> DeleteArchitectWorkedMapping(Guid id)
        {
            var delete = await _displayData.DeleteUserArchitectWorked(id);
            return delete;
        }

        public async Task<bool> CreateUserProjectWork(UserProjectMapping data)
        {
            var res = await _displayData.CreateUserProject(data);
            return res;
        }

        public async Task<IEnumerable<UserProjectMapping>> GetAllUserProjectWork()
        {
            return await _displayData.GetAllUserProject();
        }

        public async Task<UserProjectMapping> UpdateUserProject(UserProjectMapping data)
        {
            return await _displayData.UpdateUserProject(data);
        }

        public async Task<bool> DeleteUserProject(Guid id)
        {
            return await _displayData.DeleteUserProject(id);
        }

        public async Task<bool> CreateUserReview(UserReviewMapping data)
        {
            return await _displayData.CreateUserReview(data);
        }

        public async Task<IEnumerable<UserReviewMapping>> GetAllUserReview()
        {
            return await _displayData.GetAllUserReview();
        }

        public async Task<UserReviewMapping> UpdateUserReview(UserReviewMapping data)
        {
            return await _displayData.UpdateUserReview(data);
        }

        public async Task<bool> DeleteUserReview(Guid id)
        {
            return await _displayData.DeleteUserReview(id);
        }

        public async Task<bool> CreateUserServiceMapping(UserServiceMapping data)
        {
            return await _displayData.CreateUserService(data);
        }

        public async Task<IEnumerable<UserServiceMapping>> GetAllService()
        {
            return await _displayData.GetAllUserService();
        }

        public async Task<UserServiceMapping> UpdateUserService(UserServiceMapping data)
        {
            return await _displayData.UpdateUserService(data);
        }

        public async Task<bool> DeleteUserService(Guid id)
        {
            return await _displayData.DeleteUserService(id);
        }

        public Task<SearchedUserPageDisplay> GetUserPageDisplayData(SearchedUserPageDisplay data)
        {
            throw new NotImplementedException();
        }
    }
}
