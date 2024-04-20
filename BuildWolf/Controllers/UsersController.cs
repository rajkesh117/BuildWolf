using BuildWolf.BAT.Interfaces;
using BuildWolf.Modules.UserModules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildWolf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(Users user)
        {
            try
            {
                var res = await _userService.CreateUser(user);
                if (res)
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
    }
}
