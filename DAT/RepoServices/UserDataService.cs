using BuildWolf.DAT.DBContext;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.UserModules;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using BuildWolf.Modules.ViewModels;

namespace BuildWolf.DAT.RepoServices
{
    public class UserDataService : IUserDataService
    {
        private readonly DapperDBContext _context;
        public UserDataService(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(Users user)
        {

            var res = false;
            user.UserId = Guid.NewGuid().ToString();
            user.CreatedBy = Guid.NewGuid().ToString();
            user.ModifiedBy = Guid.NewGuid().ToString();

            var parameters = new DynamicParameters();
            parameters.Add("UserId", user.UserId, DbType.Guid);
            parameters.Add("UserName", user.UserName, DbType.String);
            parameters.Add("BusinessName", user.BusinessName, DbType.String);
            parameters.Add("EmailAddress", user.EmailAddress, DbType.String);
            parameters.Add("MobileNo", user.MobileNo, DbType.String);
            parameters.Add("WebsiteUrl", user.WebsiteUrl, DbType.String);
            parameters.Add("UserTypeId", user.UserTypeId, DbType.Int32);
            parameters.Add("Charges", user.Charges, DbType.String);
            parameters.Add("Experience", user.Experience, DbType.String);
            parameters.Add("IsActive", user.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", user.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", user.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", user.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", user.ModifiedBy, DbType.Guid);
            parameters.Add("Occupation", user.Occupation, DbType.String);
            parameters.Add("Rating", user.Rating, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var createdUser = await connection.ExecuteAsync("SP_InsertUser", parameters, commandType: CommandType.StoredProcedure);
                if (createdUser == 1)
                {
                    foreach (var item in user.UserCustomer)
                    {
                        item.UserCustomerMappingId = Guid.NewGuid().ToString();
                        item.UserId = user.UserId;
                        item.CreatedBy = user.CreatedBy;
                        item.ModifiedBy = user.ModifiedBy;
                        var par = new DynamicParameters();
                        par.Add("UserCustomerMappingId", item.UserCustomerMappingId, DbType.Guid);
                        par.Add("UserId", item.UserId, DbType.Guid);
                        par.Add("CustomerName", item.CustomerName, DbType.String);
                        par.Add("ContactNo", item.ContactNo, DbType.String);
                        par.Add("IsActive", user.IsActive, DbType.Boolean);
                        par.Add("CreatedDate", user.CreatedDate, DbType.DateTime);
                        par.Add("ModifiedDate", user.ModifiedDate, DbType.DateTime);
                        par.Add("CreatedBy", user.CreatedBy, DbType.Guid);
                        par.Add("ModifiedBy", user.ModifiedBy, DbType.Guid);

                        try
                        {
                            var customerAdded = await connection.ExecuteAsync("SP_InsertUserCustomer", par, commandType: CommandType.StoredProcedure);
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }

                    }
                }
                res = true;
            }

            return res;

        }



        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<Users>("SP_GetUsers", commandType: CommandType.StoredProcedure);
                return users.ToList();
            }

        }

        public async Task<Users> GetUserById(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleAsync<Users>("SP_GetUserById", commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public Task<Users> UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var deletedUser = await connection.ExecuteAsync("SP_DeleteUser", parameters, commandType: CommandType.StoredProcedure);
                if (deletedUser == 1)
                    res = true;
            }
            return res;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersFilter(UserFilterModel userFilter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Location", userFilter.Location, DbType.String);
            parameters.Add("p_Category", userFilter.Category, DbType.String);
            parameters.Add("p_Experience", userFilter.Experiance, DbType.String);
            parameters.Add("p_MinFee", userFilter.MinFee, DbType.Int64);
            parameters.Add("p_MaxFee", userFilter.MaxFee, DbType.Int64);
            //rating
            using (var connection = _context.CreateConnection())
            {
                var usersFilterResult = await connection.QueryAsync<UserViewModel>("SP_GetUsersList", parameters, commandType: CommandType.StoredProcedure);
                return usersFilterResult.ToList();
            }
        }
    }
}
