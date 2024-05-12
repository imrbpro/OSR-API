using Microsoft.AspNetCore.Mvc;
using Models.dto;
using Services.Interface;

//using System.DirectoryServices.AccountManagement;
//using System.DirectoryServices;
using Models.Response;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpGet]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto user)
        {
            var _response = new ApiResponse<LoginDto>();
            if (!ModelState.IsValid)
            {
                _response.Success = false;
                _response.Message = "Invalid Authentication Failed Rerty...!";
                _response.Data = null;
                return Unauthorized(_response);
            }

            if (_userService.IsUserExists(user.email))
            {
                var token =  _authService.GenerateJwtToken(user.email);
                _response.Success = true;
                _response.Message = "Token : "+token;
                return Ok(_response);
            }
            else
            {
                _response.Success = false;
                _response.Message = "Authentication Failed Rerty...!";
                _response.Data = null;
                return StatusCode(500,_response);
            }

        }
    }
}
