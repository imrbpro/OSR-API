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
    public class DiscountingController : ControllerBase
    {
        private readonly IDiscountingService _discountingService;
        public DiscountingController(IDiscountingService discountingService)
        {
            _discountingService = discountingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscounting(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime valueDate, DateTime valueDateTo, string brCode, string ccy, string portFolio, string broker, string trader, string customer, char ps, int orderBy)
        {
            var response = new ApiResponse<IEnumerable<Discounting>>();
            try
            {
                var result = await _discountingService.GetDiscounting(dealNo, dealNoTo, dealDate, dealDateTo, valueDate, valueDateTo, brCode, ccy, portFolio, broker, trader, customer, ps, orderBy);
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
