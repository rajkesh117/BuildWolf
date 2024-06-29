using BuildWolf.BAT.Interfaces;
using BuildWolf.Modules.UserModules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildWolf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchedUserPageController : ControllerBase
    {
        private readonly ISearchedUserPage _searchUserPage;
        public SearchedUserPageController(ISearchedUserPage searchUserPage)
        {
            _searchUserPage = searchUserPage;
        }

        [HttpPost]
        [Route("CreateUserArchitectWorked")]
        public async Task<IActionResult> CreateUserArchitectWorked(List<UserArchitectWorkedMapping> mapping)
        {
            try
            {
                var res = await _searchUserPage.CreateArchitectWorkedMapping(mapping);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not created");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        [Route("GetAllUserArchitectWorked")]
        public async Task<IActionResult> GetAllUserArchitectWorked()
        {
            try
            {
                var res = await _searchUserPage.GetAllArchitectWorkedMapping();
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not created");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteUserArchitectWorked")]
        public async Task<IActionResult> DeleteUserArchitectWorked(List<string> id)
        {
            try
            {
                var res = await _searchUserPage.DeleteArchitectWorkedMapping(id);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateUserProjectWorked")]
        public async Task<IActionResult> CreateUserProjectWorked(List<UserProjectMapping> userProjectMapping)
        {
            try
            {
                var res = await _searchUserPage.CreateUserProjectWork(userProjectMapping);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not inserted response " + res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUserProjects")]
        public async Task<IActionResult> GetAllUserProjects()
        {
            try
            {
                var res = await _searchUserPage.GetAllUserProjectWork();
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUserProjects")]
        public async Task<IActionResult> UpdateUserProjects(UserProjectMapping userProjectMapping)
        {
            try
            {
                var res = await _searchUserPage.UpdateUserProject(userProjectMapping);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUserProject")]
        public async Task<IActionResult> DeleteUserProject(List<string> id)
        {
            try
            {
                var res = await _searchUserPage.DeleteUserProject(id);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateUserReview")]
        public async Task<IActionResult> CreateUserReview(UserReviewMapping userReviewMapping)
        {
            try
            {
                var res = await _searchUserPage.CreateUserReview(userReviewMapping);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not inserted response " + res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUserReview")]
        public async Task<IActionResult> GetAllUserReview()
        {
            try
            {
                var res = await _searchUserPage.GetAllUserReview();
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUserReview")]
        public async Task<IActionResult> UpdateUserReview(UserReviewMapping userReviewMapping)
        {
            try
            {
                var res = await _searchUserPage.UpdateUserReview(userReviewMapping);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUserReview")]
        public async Task<IActionResult> DeleteUserReview(Guid id)
        {
            try
            {
                var res = await _searchUserPage.DeleteUserReview(id);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateUserService")]
        public async Task<IActionResult> CreateUserService(List<UserServiceMapping> userServiceMapping)
        {
            try
            {
                var res = await _searchUserPage.CreateUserServiceMapping(userServiceMapping);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not inserted response " + res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUserService")]
        public async Task<IActionResult> GetAllUserService()
        {
            try
            {
                var res = await _searchUserPage.GetAllService();
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUserService")]
        public async Task<IActionResult> UpdateUserService(UserServiceMapping userServiceMapping)
        {
            try
            {
                var res = await _searchUserPage.UpdateUserService(userServiceMapping);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUserService")]
        public async Task<IActionResult> DeleteUserService(List<string> id)
        {
            try
            {
                var res = await _searchUserPage.DeleteUserService(id);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        //for UserServeyModel
        [HttpPost]
        [Route("CreateUserServey")]
        public async Task<IActionResult> CreateUserSurvey(UserServeyModel UserSurvey, int pageNo)
        {
            try
            {
                var res = await _searchUserPage.CreateUserSurvey(UserSurvey, pageNo);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not inserted response " + res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUserServey")]
        public async Task<IActionResult> GetUserSurvey()
        {
            try
            {
                var res = await _searchUserPage.GetUserSurvey();
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUserServey")]
        public async Task<IActionResult> UpdateUserSurvey(UserServeyModel UserSurvey)
        {
            try
            {
                var res = await _searchUserPage.UpdateUserSurvey(UserSurvey);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUserServey")]
        public async Task<IActionResult> DeleteUserSurvey(Guid id)
        {
            try
            {
                var res = await _searchUserPage.DeleteUserSurvey(id);
                if (res)
                {
                    return StatusCode(200, res);
                }
                else
                {
                    return BadRequest("Not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }



    }
}
