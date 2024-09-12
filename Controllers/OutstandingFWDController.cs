using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response;
using OSR_API.Models.dto;
using Services.Interface;
using System.Diagnostics;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutstandingFWDController : ControllerBase
    {
        public readonly IOutstandingFWDService _outstandingFWDService;
        public OutstandingFWDController(IOutstandingFWDService outstandingFWDService) 
        {
            _outstandingFWDService = outstandingFWDService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOutstandingFWD(OutstandingDto outstanding)
        {
            var response = new ApiResponse<IEnumerable<OutstandingFWD>>();
            try
            {
                var result = await _outstandingFWDService.GetOutstandingFWD(outstanding);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "outstanding fwd is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All outstanding fwd Data";
                    response.Data = (IEnumerable<OutstandingFWD>)result;
                    return Ok(response);
                }
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
