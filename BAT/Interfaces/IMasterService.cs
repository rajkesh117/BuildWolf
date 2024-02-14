using BuildWolf.Modules.MasterModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildWolf.BAT.Interfaces
{
    public interface IMasterService
    {
        public Task<IEnumerable<locations>> GetAllLocation();
        public Task<bool> CreateLocation(IEnumerable<locations> locations);
        public Task<locations> UpdateLocation(locations locations);
        public Task<bool> DeleteLocation(Guid Id);

        //----For Categories
        public Task<IEnumerable<categories>> GetAllCategories();
        public Task<bool> CreateCategories(IEnumerable<categories> categories);
        public Task<categories> UpdateCategories(categories locations);
        public Task<bool> DeleteCategories(Guid Id);

        //------For fees
        public Task<IEnumerable<Fees>> GetAllFees();
        public Task<bool> CreateFees(IEnumerable<Fees> fees);
        public Task<Fees> UpdateFees(Fees fees);
        public Task<bool> DeleteFees(Guid Id);
        public Task<IEnumerable<LocationsViewModel>> GetAllMasterData();
    }
}
