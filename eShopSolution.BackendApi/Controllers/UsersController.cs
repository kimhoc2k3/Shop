using eShopSolution.Application.System.Users;
using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService) 
        { 
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =await _userService.Authencate(request);

            if (string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
            }
           
            return Ok(result);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            
            var result = await _userService.Register(request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            else
            return Ok(result);
        }
        //public IActionResult Update()
        //{
        //    var user = _userService.GetById();
        //    return View();
        //}
        [HttpPut("{id}")]
        
        public async Task<IActionResult> Update(Guid id,[FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Update(id,request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            
                return Ok(result);
        }

        //api/users/paging/
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging( [FromQuery]GetUserPagingRequest  request)
        {

            var users = await _userService.GetUsersPaging(request);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var users = await _userService.GetById(id);
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _userService.Delete(id);
            return Ok(result);
        }
    }
}
