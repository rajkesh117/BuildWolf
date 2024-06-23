using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BuildWolf.BAT.Interfaces;
using System.Collections;
using System.Collections.Generic;
using BuildWolf.Modules.MasterModules;

namespace BuildWolf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [Route("GetAllLocation")]
        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            try
            {
                var AllLocation = await _masterService.GetAllLocation();
                return Ok(AllLocation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("CreateLocation")]
        [HttpPost]
        public async Task<IActionResult> CreateLocation(IEnumerable<locations> locations)
        {
            try
            {
                var res = await _masterService.CreateLocation(locations);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("UpdateLocation")]
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(locations locations)
        {
            try
            {
                var res = await _masterService.UpdateLocation(locations);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("DeleteLocation")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(Guid locationId)
        {
            try
            {
                var res = await _masterService.DeleteLocation(locationId);
                if (res)
                {
                    return StatusCode(200, res);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //---cat

        [Route("GetAllCategories")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var AllCategories = await _masterService.GetAllCategories();
                return Ok(AllCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("CreateCategories")]
        [HttpPost]
        public async Task<IActionResult> CreateLocation(IEnumerable<categories> categories)
        {
            try
            {
                var res = await _masterService.CreateCategories(categories);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("UpdateCategories")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategories(categories categories)
        {
            try
            {
                var res = await _masterService.UpdateCategories(categories);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("DeleteCategories")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(Guid categoriesId)
        {
            try
            {
                var res = await _masterService.DeleteCategories(categoriesId);
                if (res)
                {
                    return StatusCode(200, res);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //fees
        [Route("GetAllFees")]
        [HttpGet]
        public async Task<IActionResult> GetAllFees()
        {
            try
            {
                var AllFees = await _masterService.GetAllFees();
                return Ok(AllFees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("CreateFees")]
        [HttpPost]
        public async Task<IActionResult> CreateFees(IEnumerable<Fees> fees)
        {
            try
            {
                var res = await _masterService.CreateFees(fees);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("UpdateFees")]
        [HttpPut]
        public async Task<IActionResult> UpdateFees(Fees fees)
        {
            try
            {
                var res = await _masterService.UpdateFees(fees);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("DeleteFeesById")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFeesById(Guid feeId)
        {
            try
            {
                var res = await _masterService.DeleteFees(feeId);
                if (res)
                {
                    return StatusCode(200, res);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("GetMasterData")]
        [HttpGet]
        public async Task<IActionResult> GetMasterData()
        {
            try
            {
                var res = await _masterService.GetAllMasterData();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("CreateArchitect")]
        [HttpPost]
        public async Task<IActionResult> CreateArchitect(Architect architect)
        {
            try
            {
                var res = await _masterService.CreateArchitect(architect);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("GetAllArchitect")]
        [HttpGet]
        public async Task<IActionResult> GetAllArchitect()
        {
            try
            {
                var res = await _masterService.GetAllArchitect();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("CreateServices")]
        [HttpPost]
        public async Task<IActionResult> CreateServices(ServicesOffered services)
        {
            try
            {
                var res = await _masterService.CreateServices(services);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("GetAllServices")]
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var res = await _masterService.GetAllServices();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
