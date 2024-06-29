using BuildWolf.DAT.DBContext;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.MasterModules;
using BuildWolf.Modules.UserModules;
using Dapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace BuildWolf.DAT.RepoServices
{
    public class ServiceProviderSurveyData : IServiceProviderSurveyData
    {
        private readonly DapperDBContext _dbContext;
        public ServiceProviderSurveyData(DapperDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<List<UserArchitectWorkedMapping>> CreateUserArchitectWorked(List<UserArchitectWorkedMapping> userArchitectWorked)
        {
            var res = new List<UserArchitectWorkedMapping>();
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    foreach (var mapping in userArchitectWorked)
                    {
                        mapping.UserArchitectWorkedMappingId = Guid.NewGuid().ToString();
                        mapping.CreatedBy = Guid.NewGuid().ToString();
                        mapping.ModifiedBy = Guid.NewGuid().ToString();
                        mapping.CreatedDate = DateTime.Now;
                        mapping.ModifiedDate = DateTime.Now;
                        var parameters = new DynamicParameters();
                        parameters.Add("UserArchitectWorkedMappingId", mapping.UserArchitectWorkedMappingId, DbType.Guid);
                        parameters.Add("UserId", mapping.UserId, DbType.Guid);
                        parameters.Add("ArchitectId", mapping.ArchitectId, DbType.Guid);
                        parameters.Add("ArchitectName", mapping.ArchitectName, DbType.String);
                        parameters.Add("IsActive", mapping.IsActive, DbType.Boolean);
                        parameters.Add("CreatedDate", mapping.CreatedDate, DbType.DateTime);
                        parameters.Add("ModifiedDate", mapping.ModifiedDate, DbType.DateTime);
                        parameters.Add("CreatedBy", mapping.CreatedBy, DbType.Guid);
                        parameters.Add("ModifiedBy", mapping.ModifiedBy, DbType.Guid);

                        var inserted = await connection.ExecuteAsync("SP_InsertArchitectWorked", parameters, commandType: CommandType.StoredProcedure);
                        if (inserted == 1)
                        {
                            res.Add(mapping);
                        }
                    }
                    if (res.Count() == userArchitectWorked.Count())
                    {
                        var p2 = new DynamicParameters();
                        p2.Add("P_UserId", userArchitectWorked[0]?.UserId, DbType.Guid);
                        var architects = await connection.QueryAsync<UserArchitectWorkedMapping>("SP_GetUserArchitectWorkedByUserId", p2, commandType: CommandType.StoredProcedure);
                        if (architects != null) return architects.ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return null;

        }

        public async Task<IEnumerable<UserArchitectWorkedMapping>> GetAllUserArchitectWorked()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var res = await connection.QueryAsync<UserArchitectWorkedMapping>("SP_GetAllUserArchitectWorked", commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public async Task<List<UserArchitectWorkedMapping>> GetUserArchitectWorkedByUserId(string id)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    var p2 = new DynamicParameters();
                    p2.Add("P_UserId", id, DbType.Guid);
                    var data = await connection.QueryAsync<UserArchitectWorkedMapping>("SP_GetUserArchitectWorkedByUserId", p2, commandType: CommandType.StoredProcedure);
                    if (data != null) return data.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex?.ToString());
            }
            return null;
        }

        public async Task<bool> DeleteUserArchitectWorked(List<string> id)
        {
            var res = false;
            using (var connection = _dbContext.CreateConnection())
            {
                foreach (var item in id)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("P_UserArchitectWorkedMappingId", item, DbType.Guid);
                    var ArchitectWorkedDelted = await connection.ExecuteAsync("SP_DeleteArchitectWorked", parameters, commandType: CommandType.StoredProcedure);
                    if (ArchitectWorkedDelted == 1)
                    {
                        res = true;
                        continue;
                    }
                    else
                    {
                        res = false;
                        break;
                    }
                }
            }
            return res;
        }

        public async Task<List<UserProjectMapping>> CreateUserProject(List<UserProjectMapping> userProject)
        {
            var res = false;
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    foreach (var mapping in userProject)
                    {
                        mapping.UserProjectMappingId = Guid.NewGuid().ToString();
                        mapping.CreatedBy = Guid.NewGuid().ToString();
                        mapping.ModifiedBy = Guid.NewGuid().ToString();
                        mapping.CreatedDate = DateTime.Now;
                        mapping.ModifiedDate = DateTime.Now;
                        var parameters = new DynamicParameters();
                        parameters.Add("UserProjectMappingId", mapping.UserProjectMappingId, DbType.Guid);
                        parameters.Add("ProjectName", mapping.ProjectName, DbType.String);
                        parameters.Add("ProjectContent", mapping.ProjectContent, DbType.String);
                        parameters.Add("ProjectDescription", mapping.ProjectDescription, DbType.String);
                        parameters.Add("UserId", mapping.UserId, DbType.Guid);
                        parameters.Add("IsActive", mapping.IsActive, DbType.Boolean);
                        parameters.Add("CreatedDate", mapping.CreatedDate, DbType.DateTime);
                        parameters.Add("ModifiedDate", mapping.ModifiedDate, DbType.DateTime);
                        parameters.Add("CreatedBy", mapping.CreatedBy, DbType.Guid);
                        parameters.Add("ModifiedBy", mapping.ModifiedBy, DbType.Guid);

                        var inserted = await connection.ExecuteAsync("SP_InsertUserProject", parameters, commandType: CommandType.StoredProcedure);
                        if (inserted == 1)
                        {
                            res = true;
                        }
                    }
                    if (res)
                    {
                        var p2 = new DynamicParameters();
                        p2.Add("P_UserId", userProject[0].UserId, DbType.Guid);
                        var projectPhoto = await connection.QueryAsync<UserProjectMapping>("SP_GetUserProjectByUserId", p2, commandType: CommandType.StoredProcedure);
                        if (projectPhoto != null) return projectPhoto.ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public async Task<List<UserProjectMapping>> GetAllUserProjectByUserId(string Id)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    var p2 = new DynamicParameters();
                    p2.Add("P_UserId", Id, DbType.Guid);
                    var projectPhoto = await connection.QueryAsync<UserProjectMapping>("SP_GetUserProjectByUserId", p2, commandType: CommandType.StoredProcedure);
                    if (projectPhoto != null) return projectPhoto.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex?.ToString());
            }
            return null;
        }

        public async Task<IEnumerable<UserProjectMapping>> GetAllUserProject()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var res = await connection.QueryAsync<UserProjectMapping>("SP_GetAllUserProject", commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public async Task<UserProjectMapping> UpdateUserProject(UserProjectMapping userProject)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_UserProjectMappingId", userProject.UserProjectMappingId, DbType.Guid);
            parameters.Add("P_ProjectName", userProject.ProjectName, DbType.String);
            parameters.Add("P_ProjectContent", userProject.ProjectContent, DbType.String);
            parameters.Add("P_ProjectDescription", userProject.ProjectDescription, DbType.String);
            parameters.Add("P_UserId", userProject.UserId, DbType.Guid);
            parameters.Add("P_IsActive", userProject.IsActive, DbType.Boolean);
            parameters.Add("P_CreatedDate", userProject.CreatedDate, DbType.DateTime);
            parameters.Add("P_ModifiedDate", userProject.ModifiedDate, DbType.DateTime);
            parameters.Add("P_CreatedBy", userProject.CreatedBy, DbType.Guid);
            parameters.Add("P_ModifiedBy", userProject.ModifiedBy, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var inserted = await connection.ExecuteAsync("SP_UpdateUserProject", parameters, commandType: CommandType.StoredProcedure);
                    if (inserted == 1)
                    {
                        return userProject;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

        public async Task<bool> DeleteUserProject(List<String> Data)
        {
            var res = false;
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    foreach (var item in Data)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("P_UserProjectMappingId", item, DbType.Guid);
                        var DeleteUserProject = await connection.ExecuteAsync("SP_DeleteUserProject", parameters, commandType: CommandType.StoredProcedure);
                        if (DeleteUserProject == 1)
                        {
                            res = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        public async Task<bool> CreateUserReview(UserReviewMapping userReview)
        {
            var res = false;
            userReview.UserReviewMappingId = Guid.NewGuid().ToString();
            userReview.CreatedBy = Guid.NewGuid().ToString();
            userReview.ModifiedBy = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("UserReviewMappingId", userReview.UserReviewMappingId, DbType.Guid);
            parameters.Add("Review", userReview.Review, DbType.String);
            parameters.Add("UserId", userReview.UserId, DbType.Guid);
            parameters.Add("IsActive", userReview.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", userReview.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", userReview.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", userReview.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", userReview.ModifiedBy, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var inserted = await connection.ExecuteAsync("SP_InsertUserreview", parameters, commandType: CommandType.StoredProcedure);
                    if (inserted == 1)
                    {
                        res = true;
                    }
                }
                catch (Exception ex)
                {
                    res = false;
                }
            }
            return res;
        }

        public async Task<IEnumerable<UserReviewMapping>> GetAllUserReview()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var res = await connection.QueryAsync<UserReviewMapping>("SP_GetAllUserReview", commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public async Task<UserReviewMapping> UpdateUserReview(UserReviewMapping userReview)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_UserReviewMappingId", userReview.UserReviewMappingId, DbType.Guid);
            parameters.Add("P_Review", userReview.Review, DbType.String);
            parameters.Add("P_UserId", userReview.UserId, DbType.Guid);
            parameters.Add("P_IsActive", userReview.IsActive, DbType.Boolean);
            parameters.Add("P_CreatedDate", userReview.CreatedDate, DbType.DateTime);
            parameters.Add("P_ModifiedDate", userReview.ModifiedDate, DbType.DateTime);
            parameters.Add("P_CreatedBy", userReview.CreatedBy, DbType.Guid);
            parameters.Add("P_ModifiedBy", userReview.ModifiedBy, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var inserted = await connection.ExecuteAsync("SP_UpdateUserReview", parameters, commandType: CommandType.StoredProcedure);
                    if (inserted == 1)
                    {
                        return userReview;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

        public async Task<bool> DeleteUserReview(Guid id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("P_UserReviewMappingId", id, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                var DeleteUserReview = await connection.ExecuteAsync("SP_DeleteUserReview", parameters, commandType: CommandType.StoredProcedure);
                if (DeleteUserReview == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<List<UserServiceMapping>> CreateUserService(List<UserServiceMapping> userService)
        {
            var res = new List<UserServiceMapping>();
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    foreach (var mapping in userService)
                    {
                        mapping.UserServiceMappingId = Guid.NewGuid().ToString();
                        mapping.CreatedBy = Guid.NewGuid().ToString();
                        mapping.ModifiedBy = Guid.NewGuid().ToString();
                        mapping.CreatedDate = DateTime.Now;
                        mapping.ModifiedDate = DateTime.Now;
                        var parameters = new DynamicParameters();
                        parameters.Add("UserServiceMappingId", mapping.UserServiceMappingId, DbType.Guid);
                        parameters.Add("ServiceId", mapping.ServiceId, DbType.String);
                        parameters.Add("ServiceName", mapping.ServiceName, DbType.String);
                        parameters.Add("ServiceDescription", mapping.ServiceDescription, DbType.String);
                        parameters.Add("UserId", mapping.UserId, DbType.Guid);
                        parameters.Add("IsActive", mapping.IsActive, DbType.Boolean);
                        parameters.Add("CreatedDate", mapping.CreatedDate, DbType.DateTime);
                        parameters.Add("ModifiedDate", mapping.ModifiedDate, DbType.DateTime);
                        parameters.Add("CreatedBy", mapping.CreatedBy, DbType.Guid);
                        parameters.Add("ModifiedBy", mapping.ModifiedBy, DbType.Guid);

                        var inserted = await connection.ExecuteAsync("SP_InsertUserService", parameters, commandType: CommandType.StoredProcedure);
                        if (inserted == 1)
                        {
                            res.Add(mapping);
                            continue;
                        }
                    }
                    if (res.Count() == userService.Count())
                    {
                        var p2 = new DynamicParameters();
                        p2.Add("P_UserId", userService[0].UserId, DbType.Guid);
                        var services = await connection.QueryAsync<UserServiceMapping>("SP_GetUserServiceByUserId", p2, commandType: CommandType.StoredProcedure);
                        if (services != null) return services.ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public async Task<IEnumerable<UserServiceMapping>> GetAllUserService()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var res = await connection.QueryAsync<UserServiceMapping>("SP_GetAllUserService", commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public async Task<List<UserServiceMapping>> GetUserServiceByUserId(string id)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    var p2 = new DynamicParameters();
                    p2.Add("P_UserId", id, DbType.Guid);
                    var services = await connection.QueryAsync<UserServiceMapping>("SP_GetUserServiceByUserId", p2, commandType: CommandType.StoredProcedure);
                    if (services != null) return services.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex?.ToString());
            }
            return null;
        }

        public async Task<UserServiceMapping> UpdateUserService(UserServiceMapping userService)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_UserServiceMappingId", userService.UserServiceMappingId, DbType.Guid);
            parameters.Add("P_ServiceId", userService.ServiceId, DbType.String);
            parameters.Add("P_ServiceName", userService.ServiceName, DbType.String);
            parameters.Add("P_ServiceDescription", userService.ServiceDescription, DbType.String);
            parameters.Add("P_UserId", userService.UserId, DbType.Guid);
            parameters.Add("P_IsActive", userService.IsActive, DbType.Boolean);
            parameters.Add("P_CreatedDate", userService.CreatedDate, DbType.DateTime);
            parameters.Add("P_ModifiedDate", userService.ModifiedDate, DbType.DateTime);
            parameters.Add("P_CreatedBy", userService.CreatedBy, DbType.Guid);
            parameters.Add("P_ModifiedBy", userService.ModifiedBy, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var inserted = await connection.ExecuteAsync("SP_UpdateUserService", parameters, commandType: CommandType.StoredProcedure);
                    if (inserted == 1)
                    {
                        return userService;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

        public async Task<bool> DeleteUserService(List<string> id)
        {
            var res = false;

            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    foreach (var item in id)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("P_UserServiceMappingId", item, DbType.Guid);
                        var DeleteUserService = await connection.ExecuteAsync("SP_DeleteUserService", parameters, commandType: CommandType.StoredProcedure);
                        if (DeleteUserService == 1)
                        {
                            res = true;
                            continue;
                        }
                        else
                        {
                            res = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return res;
                }
            }
            return res;
        }

        public async Task<ServiceProviderSurvey> GetServiceProviderSurveyById(string id)
        {
            try
            {
                var objDetails = await SqlMapper.QueryMultipleAsync(_dbContext.CreateConnection(),
                "P_GetSearchedUserDisplay", null, commandType: CommandType.StoredProcedure);

                var user = objDetails.Read<Users>().ToList();

                var userDetailsPage = new ServiceProviderSurvey();

                userDetailsPage.ServiceOffered = objDetails?.Read<UserServiceMapping>()?.ToList();
                userDetailsPage.Projects = objDetails?.Read<UserProjectMapping>()?.ToList();
                userDetailsPage.RatingAndReviews = objDetails?.Read<UserReviewMapping>()?.ToList();
                userDetailsPage.ArchitectsWorkedWith = objDetails?.Read<UserArchitectWorkedMapping>()?.ToList();
                if (userDetailsPage != null)
                {
                    return userDetailsPage;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<UserArchitectWorkedMapping> UpdateUserArchitectWorked(UserArchitectWorkedMapping userArchitectWorked)
        {
            throw new NotImplementedException();
        }

        public async Task<UserServeyModel> GetUserSurvey()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var userSurvey = await connection.QueryAsync<UserServeyModel>("SP_GetUserSurvey", commandType: CommandType.StoredProcedure);
                return (UserServeyModel)userSurvey;
            }
        }

        public async Task<bool> CreateUserSurvey(UserServeyModel userServeyModel)
        {
            var res = false;
            userServeyModel.UserId = Guid.NewGuid().ToString();
            userServeyModel.CreatedBy = Guid.NewGuid().ToString();
            userServeyModel.ModifiedBy = Guid.NewGuid().ToString();

            var parameters = new DynamicParameters();
            parameters.Add("UserId", userServeyModel.UserId, DbType.Guid);
            parameters.Add("UserName", userServeyModel.UserName, DbType.String);
            parameters.Add("BusinessName", userServeyModel.BusinessName, DbType.String);
            parameters.Add("EmailAddress", userServeyModel.EmailAddress, DbType.String);
            parameters.Add("MobileNo", userServeyModel.MobileNo, DbType.String);
            parameters.Add("WebsiteUrl", userServeyModel.WebsiteUrl, DbType.String);
            parameters.Add("UserTypeId", userServeyModel.UserTypeId, DbType.Int32);
            parameters.Add("ChargesType", userServeyModel.ChargesType, DbType.String);
            parameters.Add("Charges", userServeyModel.Charges, DbType.String);
            parameters.Add("Experience", userServeyModel.Experience, DbType.String);
            parameters.Add("IsActive", userServeyModel.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", userServeyModel.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", userServeyModel.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", userServeyModel.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", userServeyModel.ModifiedBy, DbType.Guid);
            parameters.Add("Occupation", userServeyModel.Occupation, DbType.String);
            parameters.Add("Rating", userServeyModel.Rating, DbType.Int32);
            parameters.Add("LocationId", userServeyModel.LocationId, DbType.String);

            using (var connection = _dbContext.CreateConnection())
            {
                //using (var transaction = connection.BeginTransaction())
                //{
                try
                {
                    var createdUser = await connection.ExecuteAsync("SP_InsertUser", parameters, commandType: CommandType.StoredProcedure);


                    foreach (var item in userServeyModel.ServiceOffered)
                    {
                        item.UserServiceMappingId = Guid.NewGuid().ToString();
                        item.UserId = userServeyModel.UserId;
                        item.CreatedBy = userServeyModel.CreatedBy;
                        item.ModifiedBy = userServeyModel.ModifiedBy;
                        var paramsService = new DynamicParameters();
                        paramsService.Add("UserServiceMappingId", item.UserServiceMappingId, DbType.Guid);
                        paramsService.Add("UserId", item.UserId, DbType.Guid);
                        paramsService.Add("ServiceName", item.ServiceName, DbType.String);
                        paramsService.Add("ServiceDescription", item.ServiceDescription, DbType.String);
                        paramsService.Add("IsActive", item.IsActive, DbType.Boolean);
                        paramsService.Add("CreatedBy", item.CreatedBy, DbType.Guid);
                        paramsService.Add("ModifiedBy", item.ModifiedBy, DbType.Guid);
                        paramsService.Add("CreatedDate", item.CreatedDate, DbType.DateTime);
                        paramsService.Add("ModifiedDate", item.ModifiedDate, DbType.DateTime);



                        var serviceAdded = await connection.ExecuteAsync("SP_InsertUserService", paramsService, commandType: CommandType.StoredProcedure);
                    }

                    foreach (var item in userServeyModel.Projects)
                    {
                        item.UserProjectMappingId = Guid.NewGuid().ToString();
                        item.UserId = userServeyModel.UserId;
                        item.CreatedBy = userServeyModel.CreatedBy;
                        item.ModifiedBy = userServeyModel.ModifiedBy;
                        var paramsProject = new DynamicParameters();
                        paramsProject.Add("UserProjectMappingId", item.UserProjectMappingId, DbType.Guid);
                        paramsProject.Add("UserId", item.UserId, DbType.Guid);
                        paramsProject.Add("ProjectName", item.ProjectName, DbType.String);
                        paramsProject.Add("ProjectContent", item.ProjectContent, DbType.String);
                        paramsProject.Add("ProjectDescription", item.ProjectDescription, DbType.String);
                        paramsProject.Add("IsActive", item.IsActive, DbType.Boolean);
                        paramsProject.Add("CreatedBy", item.CreatedBy, DbType.Guid);
                        paramsProject.Add("ModifiedBy", item.ModifiedBy, DbType.Guid);
                        paramsProject.Add("CreatedDate", item.CreatedDate, DbType.DateTime);
                        paramsProject.Add("ModifiedDate", item.ModifiedDate, DbType.DateTime);


                        var projectAdded = await connection.ExecuteAsync("SP_InsertUserProject", paramsProject, commandType: CommandType.StoredProcedure);
                    }

                    foreach (var item in userServeyModel.ArchitectsWorkedWith)
                    {
                        item.UserArchitectWorkedMappingId = Guid.NewGuid().ToString();
                        item.ArchitectId = Guid.NewGuid().ToString();
                        item.UserId = userServeyModel.UserId;
                        item.CreatedBy = userServeyModel.CreatedBy;
                        item.ModifiedBy = userServeyModel.ModifiedBy;


                        var paramsArchitect = new DynamicParameters();
                        paramsArchitect.Add("UserArchitectWorkedMappingId", item.UserArchitectWorkedMappingId, DbType.Guid);
                        paramsArchitect.Add("UserId", item.UserId, DbType.Guid);
                        paramsArchitect.Add("ArchitectId", item.ArchitectId, DbType.Guid);
                        paramsArchitect.Add("ArchitectName", item.ArchitectName, DbType.String);
                        paramsArchitect.Add("IsActive", item.IsActive, DbType.Boolean);
                        paramsArchitect.Add("CreatedBy", item.CreatedBy, DbType.Guid);
                        paramsArchitect.Add("ModifiedBy", item.ModifiedBy, DbType.Guid);
                        paramsArchitect.Add("CreatedDate", item.CreatedDate, DbType.DateTime);
                        paramsArchitect.Add("ModifiedDate", item.ModifiedDate, DbType.DateTime);


                        var architectWorkedWithAdded = await connection.ExecuteAsync("SP_InsertArchitectWorked", paramsArchitect, commandType: CommandType.StoredProcedure);

                    }

                    res = true;
                    //transaction.Commit();
                    return res;
                }
                catch (Exception ex)
                {
                    // transaction.Rollback();
                    return res;
                }
                //}
            }



        }

        public async Task<UserServeyModel> UpdateUserSurvey(UserServeyModel userServeyModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserSurvey(Guid id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                var deletedUser = await connection.ExecuteAsync("SP_DeleteUserSurvey", parameters, commandType: CommandType.StoredProcedure);
                if (deletedUser == 1)
                    res = true;
            }
            return res;
        }
    }
}
