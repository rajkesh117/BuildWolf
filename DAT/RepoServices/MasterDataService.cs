using BuildWolf.DAT.DBContext;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.MasterModules;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoServices
{
    public class MasterDataService : IMasterDataService
    {
        private readonly DapperDBContext _context;
        public MasterDataService(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<locations>> GetAllLocation()
        {
            using (var connection = _context.CreateConnection())
            {
                var locations = await connection.QueryAsync<locations>("SP_GetAllLocations", commandType: CommandType.StoredProcedure);
                return locations.ToList();
            }
        }

        public async Task<bool> CreateLocation(locations locations)
        {
            //var query = "INSERT INTO locations ( LocationName, StateName,IsActive,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy) VALUES " +
            //   "(@LocationName, @StateName, @IsActive,@CreatedDate,@ModifiedDate,@CreatedBy,@ModifiedBy)";
            var res = false;
            locations.LocationId = Guid.NewGuid().ToString();
            locations.CreatedBy = Guid.NewGuid().ToString();
            locations.ModifiedBy = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("LocationId", locations.LocationId, DbType.Guid);
            parameters.Add("LocationName", locations.LocationName, DbType.String);
            parameters.Add("StateName", locations.StateName, DbType.String);
            parameters.Add("IsActive", locations.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", locations.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", locations.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", locations.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", locations.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var CreatedLocation = await connection.ExecuteAsync("SP_InsertLocation", parameters, commandType: CommandType.StoredProcedure);
                if (CreatedLocation == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<locations> UpdateLocation(locations locations)
        {
            //var query = "UPDATE locations SET LocationName = @LocationName, StateName = @StateName, IsActive = @IsActive, CreatedDate = @CreatedDate, ModifiedDate = @ModifiedDate," +
            //    "CreatedBy = @CreatedBy, ModifiedBy = @ModifiedBy  WHERE LocationId = @LocationId";
            var parameters = new DynamicParameters();
            parameters.Add("p_LocationId", locations.LocationId, DbType.Guid);
            parameters.Add("p_LocationName", locations.LocationName, DbType.String);
            parameters.Add("p_StateName", locations.StateName, DbType.String);
            parameters.Add("p_IsActive", locations.IsActive, DbType.Boolean);
            parameters.Add("p_CreatedDate", locations.CreatedDate, DbType.DateTime);
            parameters.Add("p_ModifiedDate", locations.ModifiedDate, DbType.DateTime);
            parameters.Add("p_CreatedBy", locations.CreatedBy, DbType.Guid);
            parameters.Add("p_ModifiedBy", locations.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var UpdatedLocation = await connection.ExecuteAsync("SP_UpdateLocation", parameters, commandType: CommandType.StoredProcedure);
                //var UpdatedLocation = await connection.ExecuteAsync(query, parameters);
                if (UpdatedLocation == 1)
                {
                    return locations;
                }
                return null;
            }
        }
        public async Task<bool> DeleteLocation(Guid LocationId)
        {
            var res = false;
            //var query = "DELETE FROM locations WHERE LocationId = @LocationId";
            var parameters = new DynamicParameters();
            parameters.Add("p_LocationId", LocationId, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var LocationDelted = await connection.ExecuteAsync("SP_DeleteLocationById", parameters, commandType: CommandType.StoredProcedure);
                //await connection.ExecuteAsync(query, new { LocationId });
                if (LocationDelted == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<IEnumerable<categories>> GetAllCategories()
        {
            using (var connection = _context.CreateConnection())
            {
                var categories = await connection.QueryAsync<categories>("SP_GetAllCategories", commandType: CommandType.StoredProcedure);
                return categories.ToList();
            }
        }

        public async Task<bool> CreateCategories(categories categorie)
        {
            //var query = "INSERT INTO categories ( CategoryId, CategoryName,IsActive,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy) VALUES " +
            //  "(@CategoryId, @CategoryName, @IsActive,@CreatedDate,@ModifiedDate,@CreatedBy,@ModifiedBy)";
            var res = false;
            categorie.CategoryId = Guid.NewGuid().ToString();
            categorie.CreatedBy = Guid.NewGuid().ToString();
            categorie.ModifiedBy = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("CategoryId", categorie.CategoryId, DbType.Guid);
            parameters.Add("LocationId", categorie.LocationId, DbType.Guid);
            parameters.Add("CategoryName", categorie.CategoryName, DbType.String);
            parameters.Add("IsActive", categorie.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", categorie.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", categorie.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", categorie.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", categorie.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var createdCategories = await connection.ExecuteAsync("SP_InsertCategories", parameters, commandType: CommandType.StoredProcedure);
                //var createdCategories = await connection.ExecuteAsync(query, parameters);
                if (createdCategories == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<categories> UpdateCategories(categories categorie)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CategoryId", categorie.CategoryId, DbType.Guid);
            parameters.Add("p_LocationId", categorie.LocationId, DbType.Guid);
            parameters.Add("p_CategoryName", categorie.CategoryName, DbType.String);
            parameters.Add("p_IsActive", categorie.IsActive, DbType.Boolean);
            parameters.Add("p_CreatedDate", categorie.CreatedDate, DbType.DateTime);
            parameters.Add("p_ModifiedDate", categorie.ModifiedDate, DbType.DateTime);
            parameters.Add("p_CreatedBy", categorie.CreatedBy, DbType.Guid);
            parameters.Add("p_ModifiedBy", categorie.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var updateCategories = await connection.ExecuteAsync("SP_UpdateCategorie", parameters, commandType: CommandType.StoredProcedure);
                if (updateCategories != null)
                {
                    return categorie;
                }
                return null;
            }
        }
        public async Task<bool> DeleteCategories(Guid categorieId)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("p_CategoryId", categorieId, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var deleteCategories = await connection.ExecuteAsync("SP_DeleteCategorie", parameters, commandType: CommandType.StoredProcedure);
                if (deleteCategories == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<IEnumerable<Fees>> GetAllFees()
        {
            using (var connection = _context.CreateConnection())
            {
                var feesList = await connection.QueryAsync<Fees>("SP_GetAllFees", commandType: CommandType.StoredProcedure);
                return feesList.ToList();
            }
        }

        public async Task<bool> CreateFees(Fees fees)
        {
            var res = false;
            fees.FeeId = Guid.NewGuid().ToString();
            fees.CreatedBy = Guid.NewGuid().ToString();
            fees.ModifiedBy = Guid.NewGuid().ToString();
            var parameters = new DynamicParameters();
            parameters.Add("FeeId", fees.FeeId, DbType.Guid);
            parameters.Add("LocationId", fees.LocationId, DbType.Guid);
            parameters.Add("CategoryId", fees.CategoryId, DbType.Guid);
            parameters.Add("MinFee", fees.MinFee, DbType.Int64);
            parameters.Add("MaxFee", fees.MaxFee, DbType.Int64);
            parameters.Add("Parameter", fees.Parameter, DbType.String);
            parameters.Add("IsActive", fees.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", fees.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", fees.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", fees.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", fees.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var createdCategories = await connection.ExecuteAsync("SP_InsertFees", parameters, commandType: CommandType.StoredProcedure);
                if (createdCategories == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<Fees> UpdateFees(Fees fees)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("p_FeeId", fees.FeeId, DbType.Guid);
            parameters.Add("p_LocationId", fees.LocationId, DbType.Guid);
            parameters.Add("p_CategoryId", fees.CategoryId, DbType.Guid);
            parameters.Add("p_MinFee", fees.MinFee, DbType.Int64);
            parameters.Add("p_MaxFee", fees.MaxFee, DbType.Int64);
            parameters.Add("p_Parameter", fees.Parameter, DbType.String);
            parameters.Add("p_IsActive", fees.IsActive, DbType.Boolean);
            parameters.Add("p_CreatedDate", fees.CreatedDate, DbType.DateTime);
            parameters.Add("p_ModifiedDate", fees.ModifiedDate, DbType.DateTime);
            parameters.Add("P_CreatedBy", fees.CreatedBy, DbType.Guid);
            parameters.Add("p_ModifiedBy", fees.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var updateFees = await connection.ExecuteAsync("SP_UpdateFees", parameters, commandType: CommandType.StoredProcedure);
                if (updateFees == 1)
                {
                    return fees;
                }
            }
            return null;
        }

        public async Task<bool> DeleteFees(Guid id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("p_FeeId", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var deleteFees = await connection.ExecuteAsync("SP_DeleteFeeById", parameters, commandType: CommandType.StoredProcedure);
                if (deleteFees == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public async Task<IEnumerable<LocationsViewModel>> GetAllMasterData()
        {
            var objDetails = await SqlMapper.QueryMultipleAsync(_context.CreateConnection(),
                "P_GetMasterData", null, commandType: CommandType.StoredProcedure);

            var locations = objDetails.Read<locations>().ToList();
            var categories = objDetails.Read<categories>().ToList();
            var fees = objDetails.Read<Fees>().ToList();
            var locationList = new List<LocationsViewModel>();
            foreach (var data in locations)
            {
                var locationViewModel = new LocationsViewModel();
                locationViewModel.LocationId = data.LocationId;
                locationViewModel.LocationName = data.LocationName;
                locationViewModel.StateName = data.StateName;
                locationViewModel.IsActive = data.IsActive;
                locationViewModel.CreatedDate = data.CreatedDate;
                locationViewModel.ModifiedDate = data.ModifiedDate;
                locationViewModel.CreatedBy = data.CreatedBy;
                locationViewModel.ModifiedBy = data.ModifiedBy;
                locationViewModel.Categories = categories.Where(c => c.LocationId == data.LocationId).Select(category => new CategoriesViewModel()
                {
                    LocationId = category.LocationId,
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    IsActive = category.IsActive,
                    CreatedDate = category.CreatedDate,
                    ModifiedDate = category.ModifiedDate,
                    CreatedBy = category.CreatedBy,
                    ModifiedBy = category.ModifiedBy,
                    Fees = fees.Where(f => f.CategoryId == category.CategoryId && f.LocationId == data.LocationId).ToList()
                }).ToList();
                locationList.Add(locationViewModel);
            }
            return locationList;
        }
    }
}
