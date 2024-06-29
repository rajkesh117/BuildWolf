using BuildWolf.Modules.UserModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.BAT.Interfaces
{
    public interface ISearchedUserPage
    {
        Task<bool> CreateArchitectWorkedMapping(List<UserArchitectWorkedMapping> data);
        Task<IEnumerable<UserArchitectWorkedMapping>> GetAllArchitectWorkedMapping();
        Task<bool> DeleteArchitectWorkedMapping(List<string> id);

        Task<bool> CreateUserProjectWork(List<UserProjectMapping> data);
        Task<IEnumerable<UserProjectMapping>> GetAllUserProjectWork();
        Task<UserProjectMapping> UpdateUserProject(UserProjectMapping data);
        Task<bool> DeleteUserProject(List<string> id);

        Task<bool> CreateUserReview(UserReviewMapping data);
        Task<IEnumerable<UserReviewMapping>> GetAllUserReview();
        Task<UserReviewMapping> UpdateUserReview(UserReviewMapping data);
        Task<bool> DeleteUserReview(Guid id);

        Task<List<UserServiceMapping>> CreateUserServiceMapping(List<UserServiceMapping> data);
        Task<IEnumerable<UserServiceMapping>> GetAllService();
        Task<UserServiceMapping> UpdateUserService(UserServiceMapping data);
        Task<bool> DeleteUserService(List<string> id);

        Task<ServiceProviderSurvey> GetUserPageDisplayData(ServiceProviderSurvey data);

        //For Service
        public Task<UserServeyModel> GetUserSurvey();
        public Task<UserServeyModel> CreateUserSurvey(UserServeyModel userServeyModel, int pageNo);
        public Task<UserServeyModel> UpdateUserSurvey(UserServeyModel userServeyModel);
        public Task<bool> DeleteUserSurvey(Guid id);

    }
}
