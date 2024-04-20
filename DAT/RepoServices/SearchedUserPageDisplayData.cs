using BuildWolf.DAT.DBContext;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.MasterModules;
using BuildWolf.Modules.UserModules;
using Dapper;
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
    public class SearchedUserPageDisplayData : ISearchedUserPageDisplayData
    {
        private readonly DapperDBContext _dbContext;
        public SearchedUserPageDisplayData(DapperDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<bool> CreateUserArchitectWorked(UserArchitectWorkedMapping userArchitectWorked)
        {
            var res = false;
            userArchitectWorked.UserArchitectWorkedMappingId = Guid.NewGuid().ToString();
            userArchitectWorked.CreatedBy = Guid.NewGuid().ToString();
            userArchitectWorked.ModifiedBy = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("UserArchitectWorkedMappingId", userArchitectWorked.UserArchitectWorkedMappingId, DbType.Guid);
            parameters.Add("UserId", userArchitectWorked.UserId, DbType.Guid);
            parameters.Add("ArchitectId", userArchitectWorked.ArchitectId, DbType.Guid);
            parameters.Add("IsActive", userArchitectWorked.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", userArchitectWorked.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", userArchitectWorked.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", userArchitectWorked.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", userArchitectWorked.ModifiedBy, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var inserted = await connection.ExecuteAsync("SP_InsertArchitectWorked", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<UserArchitectWorkedMapping>> GetAllUserArchitectWorked()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var res = await connection.QueryAsync<UserArchitectWorkedMapping>("SP_GetAllUserArchitectWorked", commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public async Task<bool> DeleteUserArchitectWorked(Guid id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("P_UserArchitectWorkedMappingId", id, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                var ArchitectWorkedDelted = await connection.ExecuteAsync("SP_DeleteArchitectWorked", parameters, commandType: CommandType.StoredProcedure);
                if (ArchitectWorkedDelted == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<bool> CreateUserProject(UserProjectMapping userProject)
        {
            var res = false;
            userProject.UserProjectMappingId = Guid.NewGuid().ToString();
            userProject.CreatedBy = Guid.NewGuid().ToString();
            userProject.ModifiedBy = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("UserProjectMappingId", userProject.UserProjectMappingId, DbType.Guid);
            parameters.Add("ProjectName", userProject.ProjectName, DbType.String);
            parameters.Add("ProjectContent", userProject.ProjectContent, DbType.String);
            parameters.Add("ProjectDescription", userProject.ProjectDescription, DbType.String);
            parameters.Add("UserId", userProject.UserId, DbType.Guid);
            parameters.Add("IsActive", userProject.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", userProject.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", userProject.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", userProject.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", userProject.ModifiedBy, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var inserted = await connection.ExecuteAsync("SP_InsertUserProject", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<bool> DeleteUserProject(Guid id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("P_UserProjectMappingId", id, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                var DeleteUserProject = await connection.ExecuteAsync("SP_DeleteUserProject", parameters, commandType: CommandType.StoredProcedure);
                if (DeleteUserProject == 1)
                {
                    res = true;
                }
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

        public async Task<bool> CreateUserService(UserServiceMapping userService)
        {
            var res = false;
            userService.UserServiceMappingId = Guid.NewGuid().ToString();
            userService.CreatedBy = Guid.NewGuid().ToString();
            userService.ModifiedBy = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("UserServiceMappingId", userService.UserServiceMappingId, DbType.Guid);
            parameters.Add("ServiceName", userService.ServiceName, DbType.String);
            parameters.Add("ServiceDescription", userService.ServiceDescription, DbType.String);
            parameters.Add("UserId", userService.UserId, DbType.Guid);
            parameters.Add("IsActive", userService.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", userService.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", userService.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", userService.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", userService.ModifiedBy, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var inserted = await connection.ExecuteAsync("SP_InsertUserService", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<UserServiceMapping>> GetAllUserService()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var res = await connection.QueryAsync<UserServiceMapping>("SP_GetAllUserService", commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public async Task<UserServiceMapping> UpdateUserService(UserServiceMapping userService)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_UserServiceMappingId", userService.UserServiceMappingId, DbType.Guid);
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

        public async Task<bool> DeleteUserService(Guid id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("P_UserServiceMappingId", id, DbType.Guid);
            using (var connection = _dbContext.CreateConnection())
            {
                var DeleteUserService = await connection.ExecuteAsync("SP_DeleteUserService", parameters, commandType: CommandType.StoredProcedure);
                if (DeleteUserService == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<SearchedUserPageDisplay> GetSearchedUserPageDisplayById(string id)
        {
            try
            {
                var objDetails = await SqlMapper.QueryMultipleAsync(_dbContext.CreateConnection(),
                "P_GetSearchedUserDisplay", null, commandType: CommandType.StoredProcedure);

                var user = objDetails.Read<Users>().ToList();

                var userDetailsPage = new SearchedUserPageDisplay();

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
    }
}
