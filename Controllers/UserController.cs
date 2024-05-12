using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response;
using Services.Implementation;
using Services.Interface;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var response = new ApiResponse<User>();
            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Invalid Request Payload..!";
                return BadRequest(response); 
            }

            if (_userService.AddUser(user))
            {
                response.Success = true;
                response.Message = "User Added Successfully...!";
                response.Data = user;
                return Ok(response);
            }
            else
            {
                response.Success = false;
                response.Message = "Error adding user. Please try again.";
                return StatusCode(500, response); 
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var response = new ApiResponse<User>();
            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Invalid Request Payload..!";
                return BadRequest(response);
            }

            if (_userService.UpdateUser(user))
            {
                response.Success = true;
                response.Message = "User updated successfully!";
                response.Data = user;
                return Ok(response);
            }
            else
            {
                response.Success = false;
                response.Message = "Error Updating user. Please try again.";
                return StatusCode(500, response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = new ApiResponse<string>();
            if (_userService.DeleteUser(id))
            {
                response.Success = true;
                response.Message = "User Deletion Success";
                response.Data = "Success Deletion Process";
                return Ok(response); 
            }
            else
            {
                response.Success = false;
                response.Message = "User not found.";
                response.Data = "Error Occured.. Or User Does Not Exist...";
                return NotFound(response); 
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = new ApiResponse<IEnumerable<User>>();
            try
            {
                var users = _userService.GetAll();
                response.Success = true;
                response.Message = "All Users";
                response.Data = users;
                return Ok(response);
            } 
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
