using BuildWolf.Modules.MasterModules;
using BuildWolf.Modules.UserModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoInterfaces
{
    public interface IUserLocationData
    {
        public Task<IEnumerable<UserLocation>> GetAllUserLocations();
        public Task<UserLocation> GetUserLocationByUserId(Guid id);
        public Task<UserLocation> CreateUserLocation(UserLocation userLocation);
        public Task<UserLocation> UpdateUserLocation(UserLocation userLocation);
        public Task<bool> DeleteUserLocation(Guid id);
    }
}
