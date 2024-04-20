using BuildWolf.Modules.UserModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoInterfaces
{
    public interface ISearchedUserPageDisplayData
    {
        public Task<SearchedUserPageDisplay> GetSearchedUserPageDisplayById(string id);
        // For UserServiceMapping
        public Task<IEnumerable<UserServiceMapping>> GetAllUserService();
        public Task<bool> CreateUserService(UserServiceMapping userService);
        public Task<UserServiceMapping> UpdateUserService(UserServiceMapping userService);
        public Task<bool> DeleteUserService(Guid id);

        //For UserProjectMapping
        public Task<IEnumerable<UserProjectMapping>> GetAllUserProject();
        public Task<bool> CreateUserProject(UserProjectMapping userProject);
        public Task<UserProjectMapping> UpdateUserProject(UserProjectMapping userProject);
        public Task<bool> DeleteUserProject(Guid id);

        // For UserReviewMapping
        public Task<IEnumerable<UserReviewMapping>> GetAllUserReview();
        public Task<bool> CreateUserReview(UserReviewMapping userReview);
        public Task<bool> DeleteUserReview(Guid id);
        public Task<UserReviewMapping> UpdateUserReview(UserReviewMapping userReview);

        // For UserArchitectWorkedMapping
        public Task<IEnumerable<UserArchitectWorkedMapping>> GetAllUserArchitectWorked();
        public Task<bool> CreateUserArchitectWorked(UserArchitectWorkedMapping userArchitectWorked);
        public Task<bool> DeleteUserArchitectWorked(Guid id);
        public Task<UserArchitectWorkedMapping> UpdateUserArchitectWorked(UserArchitectWorkedMapping userArchitectWorked);
    }
}
