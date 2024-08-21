using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response;
using Services.Interface;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloseoutController : ControllerBase
    {
        private readonly ICloseoutService _closeoutService;
        public CloseoutController(ICloseoutService closeoutService)
        {
            _closeoutService = closeoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCloseout(String dealNo, String dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, String ccy, String portfolio, String broker, String customer, int orderBy)
        {
            var response = new ApiResponse<IEnumerable<Closeout>>();
            try
            {
                var result = await _closeoutService.GetCloseouts(dealNo, dealNoTo, contractDate, contractDateTo, valueDate, valueDateTo, entryDate, entryDateTo, ccy, portfolio, broker, customer, orderBy);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Closeout is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Closeout Data";
                    response.Data = (IEnumerable<Closeout>)result;
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
