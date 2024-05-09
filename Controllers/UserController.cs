using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        public IActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if (_userService.AddUser(user))
            {
                return Ok("User added successfully!");
            }
            else
            {
                return StatusCode(500, "Error adding user. Please try again."); 
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if (_userService.UpdateUser(user))
            {
                return Ok("User updated successfully!");
            }
            else
            {
                return StatusCode(500, "Error updating user. Please try again.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            if (_userService.DeleteUser(id))
            {
                return Ok("User deleted successfully!"); 
            }
            else
            {
                return NotFound("User not found."); 
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users); 
        }
    }
}
