using BuildWolf.Modules.UserModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoInterfaces
{
    public interface IServiceProviderSurveyData
    {
        public Task<ServiceProviderSurvey> GetServiceProviderSurveyById(string id);
        // For UserServiceMapping
        public Task<IEnumerable<UserServiceMapping>> GetAllUserService();
        public Task<List<UserServiceMapping>> GetUserServiceByUserId(string id);
        public Task<List<UserServiceMapping>> CreateUserService(List<UserServiceMapping> userService);
        public Task<UserServiceMapping> UpdateUserService(UserServiceMapping userService);
        public Task<bool> DeleteUserService(List<string> id);

        //For UserProjectMapping
        public Task<IEnumerable<UserProjectMapping>> GetAllUserProject();
        public Task<List<UserProjectMapping>> GetAllUserProjectByUserId(string Id);
        public Task<List<UserProjectMapping>> CreateUserProject(List<UserProjectMapping> userProject);
        public Task<UserProjectMapping> UpdateUserProject(UserProjectMapping userProject);
        public Task<bool> DeleteUserProject(List<string> id);

        // For UserReviewMapping
        public Task<IEnumerable<UserReviewMapping>> GetAllUserReview();
        public Task<bool> CreateUserReview(UserReviewMapping userReview);
        public Task<bool> DeleteUserReview(Guid id);
        public Task<UserReviewMapping> UpdateUserReview(UserReviewMapping userReview);

        // For UserArchitectWorkedMapping
        public Task<IEnumerable<UserArchitectWorkedMapping>> GetAllUserArchitectWorked();
        public Task<List<UserArchitectWorkedMapping>> GetUserArchitectWorkedByUserId(string id);
        public Task<List<UserArchitectWorkedMapping>> CreateUserArchitectWorked(List<UserArchitectWorkedMapping> userArchitectWorked);
        public Task<bool> DeleteUserArchitectWorked(List<string> id);
        public Task<UserArchitectWorkedMapping> UpdateUserArchitectWorked(UserArchitectWorkedMapping userArchitectWorked);


        //For Service
        public Task<UserServeyModel> GetUserSurvey();
        public Task<bool> CreateUserSurvey(UserServeyModel userServeyModel);
        public Task<UserServeyModel> UpdateUserSurvey(UserServeyModel userServeyModel);
        public Task<bool> DeleteUserSurvey(Guid id);

    }
}
