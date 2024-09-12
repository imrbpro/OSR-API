using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.dto;
using Models.Response;
using Services.Interface;
using System.Diagnostics;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadyController : ControllerBase
    {
        private readonly IReadyService _readyService;
        public ReadyController(IReadyService readyService)
        {
            _readyService = readyService;
        }

        [HttpPost]
        public async Task<IActionResult> GetReady([FromBody] ReadyDto ready)
        {
            var response = new ApiResponse<IEnumerable<Ready>>();
            try
            {
                var result = await _readyService.GetReady(ready);
                if(result == null)
                {
                    response.Success = false;
                    response.Message = "Ready is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Ready Data";
                    response.Data = (IEnumerable<Ready>)result;
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
