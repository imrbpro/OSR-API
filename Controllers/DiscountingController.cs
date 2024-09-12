using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response;
using OSR_API.Models.dto;
using Services.Implementation;
using Services.Interface;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountingController : ControllerBase
    {
        private readonly IDiscountingService _discountingService;
        public DiscountingController(IDiscountingService discountingService)
        {
            _discountingService = discountingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscounting([FromBody] DiscountingDto discounting)
        {
            var response = new ApiResponse<IEnumerable<Discounting>>();
            try
            {
                var result = await _discountingService.GetDiscounting(discounting);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Discounting is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Discounting Data";
                    response.Data = (IEnumerable<Discounting>)result;
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
