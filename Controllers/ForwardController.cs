using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Response;
using OSR_API.Models;
using OSR_API.Services.Interface;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForwardController : ControllerBase
    {
        private readonly IForwardService _forwardService;
        public ForwardController(IForwardService forwardService)
        {
            _forwardService = forwardService;
        }


        [HttpGet]
        public async Task<IActionResult> GetForward(string dealNo, string dealNoTo, DateTime dealDate, DateTime dealDateTo, DateTime oDate, DateTime oDateTo, DateTime valueDate, DateTime valueDateTo, string ccy, string portFolio, string broker, string trader, string customer, int orderBy)
        {
            var response = new ApiResponse<IEnumerable<Forward>>();
            try
            {
                var result = await _forwardService.GetForward(dealNo, dealNoTo, dealDate, dealDateTo, oDate, oDateTo, valueDate, valueDateTo, ccy, portFolio, broker, trader, customer, orderBy);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Forward is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Forward Data";
                    response.Data = (IEnumerable<Forward>)result;
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
