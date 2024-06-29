using BuildWolf.BAT.Interfaces;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.MasterModules;
using BuildWolf.Modules.UserModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildWolf.BAT.Services
{
    public class SearchedUserPage : ISearchedUserPage
    {
        private readonly IServiceProviderSurveyData _displayData;
        private readonly IUserService _userService;
        private readonly IUserLocationData _userLocationData;

        public SearchedUserPage(IServiceProviderSurveyData displayData, IUserService userService, IUserLocationData userLocationData)
        {
            _displayData = displayData;
            _userService = userService;
            _userLocationData = userLocationData;
        }

        public async Task<bool> CreateArchitectWorkedMapping(List<UserArchitectWorkedMapping> data)
        {
            var created = await _displayData.CreateUserArchitectWorked(data);
            if (created != null) return true;
            return false;
        }

        public async Task<IEnumerable<UserArchitectWorkedMapping>> GetAllArchitectWorkedMapping()
        {
            var getAllData = await _displayData.GetAllUserArchitectWorked();
            return getAllData;
        }

        public async Task<bool> DeleteArchitectWorkedMapping(List<string> id)
        {
            var delete = await _displayData.DeleteUserArchitectWorked(id);
            return delete;
        }

        public async Task<bool> CreateUserProjectWork(List<UserProjectMapping> data)
        {
            var res = await _displayData.CreateUserProject(data);
            if (res != null) return true;
            return false;
        }

        public async Task<IEnumerable<UserProjectMapping>> GetAllUserProjectWork()
        {
            return await _displayData.GetAllUserProject();
        }

        public async Task<UserProjectMapping> UpdateUserProject(UserProjectMapping data)
        {
            return await _displayData.UpdateUserProject(data);
        }

        public async Task<bool> DeleteUserProject(List<string> id)
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

        public async Task<List<UserServiceMapping>> CreateUserServiceMapping(List<UserServiceMapping> data)
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

        public async Task<bool> DeleteUserService(List<string> id)
        {
            return await _displayData.DeleteUserService(id);
        }

        public Task<ServiceProviderSurvey> GetUserPageDisplayData(ServiceProviderSurvey data)
        {
            throw new NotImplementedException();
        }

        public async Task<UserServeyModel> GetUserSurvey()
        {
            return await _displayData.GetUserSurvey();
        }

        public async Task<UserServeyModel> CreateUserSurvey(UserServeyModel userServeyModel, int pageNo)
        {
            var user = new Users();
            var userLocation = new UserLocation();
            var serviceOffered = new List<UserServiceMapping>();
            var architectMapping = new List<UserArchitectWorkedMapping>();
            var projectsMapping = new List<UserProjectMapping>();
            user.UserName = userServeyModel.UserName;
            user.BusinessName = userServeyModel.BusinessName;
            user.EmailAddress = userServeyModel.EmailAddress.ToLower();
            user.MobileNo = userServeyModel.MobileNo;
            user.LocationId = userServeyModel.LocationId;
            user.UserTypeId = userServeyModel.UserTypeId;
            if (userServeyModel.UserId == null && pageNo == 1)
            {
                user = await _userService.CreateUser(user).ConfigureAwait(false);
                if (user == null) return null;
                userServeyModel.UserId = user?.UserId;
                userServeyModel.CreatedBy = user?.CreatedBy;
                userServeyModel.ModifiedBy = user?.ModifiedBy;
                userServeyModel.CreatedDate = user.CreatedDate;
                userServeyModel.ModifiedDate = user.ModifiedDate;
                userServeyModel.userLocation.UserId = user.UserId;
                userServeyModel.userLocation.CreatedBy = user.CreatedBy;
                userServeyModel.userLocation.ModifiedBy = user.ModifiedBy;
                if (user.UserId != null && userServeyModel.userLocation._Id == null)
                {
                    userLocation = await _userLocationData.CreateUserLocation(userServeyModel.userLocation).ConfigureAwait(false);
                    if (userLocation != null)
                    {
                        userServeyModel.LocationId = userLocation._Id;
                        userServeyModel.userLocation = userLocation;
                    }
                }
            }
            else if (userServeyModel.UserId != null && pageNo < 4)
            {
                if (userServeyModel.userLocation._Id != null && pageNo == 1)
                {
                    userLocation = await _userLocationData.UpdateUserLocation(userServeyModel.userLocation).ConfigureAwait(false);
                }
                else if (userServeyModel.userLocation._Id == null && pageNo == 1)
                {
                    userLocation = await _userLocationData.CreateUserLocation(userServeyModel.userLocation).ConfigureAwait(false);
                    if (userLocation != null)
                    {
                        userServeyModel.LocationId = userLocation._Id;
                        userServeyModel.userLocation = userLocation;
                        user.LocationId = userLocation._Id;
                    }
                }
                user.UserId = userServeyModel.UserId;
                user.CreatedBy = userServeyModel.CreatedBy;
                user.ModifiedDate = DateTime.Now;
                user.CreatedBy = userServeyModel.CreatedBy;
                user.ModifiedBy = userServeyModel.ModifiedBy;
                user.Experience = userServeyModel.Experience;
                user.Charges = userServeyModel.Charges;
                user.ChargesType = userServeyModel.ChargesType;
                await _userService.UpdateUser(user).ConfigureAwait(false);
            }
            if (userServeyModel?.ServiceOffered?.Count() > 0 && pageNo == 2)
            {
                var dataNotCreated = userServeyModel?.ServiceOffered.Where(x => x.UserId == null && x.UserServiceMappingId == null);
                var deleteCreatedData = userServeyModel?.ServiceOffered.Where(x => x.UserId != null && x.UserServiceMappingId != null && x.IsActive == false);
                if (deleteCreatedData.Count() > 0)
                {
                    var deleteServiceId = deleteCreatedData.Select(x => x.UserServiceMappingId).ToList();
                    var deleteService = await _displayData.DeleteUserService(deleteServiceId);
                    if (!deleteService) return null;
                    if (dataNotCreated.Count() == 0) userServeyModel.ServiceOffered = await _displayData.GetUserServiceByUserId(userServeyModel.ServiceOffered[0].UserId).ConfigureAwait(false);
                }
                if (dataNotCreated.Count() > 0)
                {
                    foreach (var data in dataNotCreated)
                    {
                        var services = new UserServiceMapping();
                        services.ServiceName = data.ServiceName;
                        services.UserId = userServeyModel.UserId;
                        services.ServiceId = data.ServiceId;
                        serviceOffered.Add(services);
                    }
                    var res = await _displayData.CreateUserService(serviceOffered);
                    if (res == null) return null;
                    userServeyModel.ServiceOffered = res;
                }
            }
            if (userServeyModel?.ArchitectsWorkedWith?.Count() > 0 && pageNo == 3)
            {
                var isarchitectNotCreated = userServeyModel.ArchitectsWorkedWith.Where(x => x.UserId == null && x.UserArchitectWorkedMappingId == null);
                var deleteArchitectData = userServeyModel.ArchitectsWorkedWith.Where(x => x.UserId != null && x.UserArchitectWorkedMappingId != null && x.IsActive == false);
                if (deleteArchitectData.Count() > 0)
                {
                    var deleteArchitectIds = deleteArchitectData.Select(x => x.UserArchitectWorkedMappingId).ToList();
                    var dataDeleted = await _displayData.DeleteUserArchitectWorked(deleteArchitectIds);
                    if (!dataDeleted) return null;
                    if (isarchitectNotCreated.Count() == 0) userServeyModel.ArchitectsWorkedWith = await _displayData.GetUserArchitectWorkedByUserId(userServeyModel.UserId).ConfigureAwait(false);
                }
                if (isarchitectNotCreated.Count() > 0)
                {
                    foreach (var data in isarchitectNotCreated)
                    {
                        var architect = new UserArchitectWorkedMapping();
                        architect.ArchitectName = data.ArchitectName;
                        architect.UserId = userServeyModel.UserId;
                        architect.ArchitectId = data.ArchitectId;
                        architectMapping.Add(architect);
                    }
                    var res = await _displayData.CreateUserArchitectWorked(architectMapping);
                    if (res == null) return null;
                    userServeyModel.ArchitectsWorkedWith = res;
                }
            }
            if (userServeyModel?.Projects?.Count() > 0 && pageNo == 4)
            {
                var isProjectNotCreated = userServeyModel.Projects.Where(x => x.UserId == null);
                var deleteProject = userServeyModel?.Projects.Where(x => x.UserId != null && x.IsActive == false);
                if (deleteProject.Count() > 0)
                {
                    var ids = deleteProject.Select(x => x.UserProjectMappingId).ToList();
                    var res = await _displayData.DeleteUserProject(ids);
                    if (!res) return null;
                    if (isProjectNotCreated.Count() == 0) userServeyModel.Projects = await _displayData.GetAllUserProjectByUserId(userServeyModel.UserId).ConfigureAwait(false);
                }
                if (isProjectNotCreated.Count() > 0)
                {
                    foreach (var data in isProjectNotCreated)
                    {
                        var proj = new UserProjectMapping();
                        proj.ProjectName = data.ProjectName;
                        proj.UserId = userServeyModel.UserId;
                        proj.ProjectContent = data.ProjectContent;
                        projectsMapping.Add(proj);
                    }
                    var res = await _displayData.CreateUserProject(projectsMapping);
                    if (res == null) return null;
                    userServeyModel.Projects = res;
                }
            }
            return userServeyModel;
        }

        public async Task<UserServeyModel> UpdateUserSurvey(UserServeyModel userServeyModel)
        {
            return await _displayData.UpdateUserSurvey(userServeyModel);
        }

        public async Task<bool> DeleteUserSurvey(Guid id)
        {
            return await _displayData.DeleteUserSurvey(id);
        }
    }
}
