using BuildWolf.DAT.DBContext;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.MasterModules;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoServices
{
    public class UserLocationData : IUserLocationData
    {
        private readonly DapperDBContext _context;
        public UserLocationData(DapperDBContext dapperDBContext)
        {
            _context = dapperDBContext;
        }

        public async Task<UserLocation> CreateUserLocation(UserLocation userLocation)
        {
            userLocation._Id = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("_id", userLocation._Id, DbType.Guid);
            parameters.Add("UserId", userLocation.UserId, DbType.Guid);
            parameters.Add("Street", userLocation.Street, DbType.String);
            parameters.Add("State", userLocation.State, DbType.String);
            parameters.Add("District", userLocation.District, DbType.String);
            parameters.Add("City", userLocation.City, DbType.String);
            parameters.Add("Pincode", userLocation.Pincode, DbType.String);
            parameters.Add("IsActive", userLocation.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", userLocation.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", userLocation.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", userLocation.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", userLocation.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var CreatedLocation = await connection.ExecuteAsync("SP_InsertUserLocation", parameters, commandType: CommandType.StoredProcedure);
                if (CreatedLocation == 1)
                {
                    return userLocation;
                }
            }
            return null;
        }

        public Task<bool> DeleteUserLocation(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserLocation>> GetAllUserLocations()
        {
            throw new NotImplementedException();
        }

        public Task<UserLocation> GetUserLocationByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLocation> UpdateUserLocation(UserLocation userLocation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p__id", userLocation._Id, DbType.Guid);
            parameters.Add("p_UserId", userLocation.UserId, DbType.Guid);
            parameters.Add("p_Street", userLocation.Street, DbType.String);
            parameters.Add("p_State", userLocation.State, DbType.String);
            parameters.Add("p_District", userLocation.District, DbType.String);
            parameters.Add("p_City", userLocation.City, DbType.String);
            parameters.Add("p_Pincode", userLocation.Pincode, DbType.String);
            parameters.Add("p_IsActive", userLocation.IsActive, DbType.Boolean);
            parameters.Add("p_CreatedDate", userLocation.CreatedDate, DbType.DateTime);
            parameters.Add("p_ModifiedDate", userLocation.ModifiedDate, DbType.DateTime);
            parameters.Add("p_CreatedBy", userLocation.CreatedBy, DbType.Guid);
            parameters.Add("p_ModifiedBy", userLocation.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var updatedLocation = await connection.ExecuteAsync("SP_UpdateUserLocation", parameters, commandType: CommandType.StoredProcedure);
                if (updatedLocation == 1)
                {
                    return userLocation;
                }
            }
            return null;
        }
    }
}
