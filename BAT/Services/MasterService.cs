using BuildWolf.BAT.Interfaces;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.Modules.MasterModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace BuildWolf.BAT.Services
{
    public class MasterService : IMasterService
    {
        private readonly IMasterDataService _masterDataRepo;

        public MasterService(IMasterDataService masterDataRepo)
        {
            _masterDataRepo = masterDataRepo;
        }

        public async Task<IEnumerable<locations>> GetAllLocation()
        {
            return await _masterDataRepo.GetAllLocation();
        }

        public async Task<bool> CreateLocation(IEnumerable<locations> locations)
        {
            var success = false;
            foreach (var data in locations)
            {
                success = await _masterDataRepo.CreateLocation(data);
                if (success)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return success;
        }

        public async Task<locations> UpdateLocation(locations locations)
        {
            return await _masterDataRepo.UpdateLocation(locations);
        }

        public async Task<bool> DeleteLocation(Guid locationId)
        {
            return await _masterDataRepo.DeleteLocation(locationId);
        }

        //------------------------------- for categories --------------------------------
        public async Task<IEnumerable<categories>> GetAllCategories()
        {
            return await _masterDataRepo.GetAllCategories();
        }

        public async Task<bool> CreateCategories(IEnumerable<categories> categories)
        {
            var success = false;
            foreach (var data in categories)
            {
                success = await _masterDataRepo.CreateCategories(data);
                if (success)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return success;
        }

        public async Task<categories> UpdateCategories(categories categories)
        {
            return await _masterDataRepo.UpdateCategories(categories);
        }

        public async Task<bool> DeleteCategories(Guid categoriesId)
        {
            return await _masterDataRepo.DeleteCategories(categoriesId);
        }


        //------------------------- for fees -------------------------
        public async Task<IEnumerable<Fees>> GetAllFees()
        {
            return await _masterDataRepo.GetAllFees();
        }

        public async Task<bool> CreateFees(IEnumerable<Fees> fees)
        {
            var success = false;
            foreach (var data in fees)
            {
                success = await _masterDataRepo.CreateFees(data);
                if (success)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return success;
        }

        public async Task<Fees> UpdateFees(Fees fees)
        {
            return await _masterDataRepo.UpdateFees(fees);
        }

        public async Task<bool> DeleteFees(Guid feeId)
        {
            return await _masterDataRepo.DeleteFees(feeId);
        }

        public async Task<IEnumerable<LocationsViewModel>> GetAllMasterData()
        {
            return await _masterDataRepo.GetAllMasterData();
        }

        public async Task<bool> CreateArchitect(Architect architect)
        {
            return await _masterDataRepo.CreateArchitect(architect);
        }

        public async Task<IEnumerable<Architect>> GetAllArchitect()
        {
            return await _masterDataRepo.GetAllArchitect();
        }

        public async Task<bool> CreateServices(ServicesOffered services)
        {
            return await _masterDataRepo.CreateServices(services);
        }

        public async Task<IEnumerable<ServicesOffered>> GetAllServices()
        {
            return await _masterDataRepo.GetAllServices();
        }


    }

}
