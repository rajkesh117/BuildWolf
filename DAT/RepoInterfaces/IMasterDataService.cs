using BuildWolf.Modules.MasterModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.DAT.RepoInterfaces
{
    public interface IMasterDataService
    {
        public Task<IEnumerable<locations>> GetAllLocation();
        public Task<bool> CreateLocation(locations locations);
        public Task<locations> UpdateLocation(locations locations);
        public Task<bool> DeleteLocation(Guid id);

        public Task<IEnumerable<categories>> GetAllCategories();
        public Task<bool> CreateCategories(categories categorie);
        public Task<categories> UpdateCategories(categories categorie);
        public Task<bool> DeleteCategories(Guid id);

        public Task<IEnumerable<Fees>> GetAllFees();
        public Task<bool> CreateFees(Fees fees);
        public Task<Fees> UpdateFees(Fees fees);
        public Task<bool> DeleteFees(Guid id);
        public Task<IEnumerable<LocationsViewModel>> GetAllMasterData();
    }
}
