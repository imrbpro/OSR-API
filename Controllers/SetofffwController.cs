using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Response;
using OSR_API.Models;
using OSR_API.Services.Interface;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetofffwController : ControllerBase
    {
        private readonly ISetofffwService _setofffwService;
        public SetofffwController(ISetofffwService setofffwService)
        {
            _setofffwService = setofffwService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSetofffw(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portfolio, string trad, string customer, int orderBy)
        {
            var response = new ApiResponse<IEnumerable<Setofffw>>();
            try
            {
                var result = await _setofffwService.GetSetofffw(dealNo, dealNoTo, contractDate, contractDateTo, valueDate, valueDateTo, entryDate, entryDateTo, ccy, portfolio, trad, customer, orderBy);
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Setofffw is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Setofffw Data";
                    response.Data = (IEnumerable<Setofffw>)result;
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
