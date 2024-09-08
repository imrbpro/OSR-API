using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response;
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
        public async Task<IActionResult> GetOutstandingFWD(string dealNo, string dealNoTo, DateTime contractDate, DateTime contractDateTo, DateTime valueDate, DateTime valueDateTo, DateTime entryDate, DateTime entryDateTo, string ccy, string portFolio, string branchcode, string trader, string customer, int orderBy)
        {
            var response = new ApiResponse<IEnumerable<OutstandingFWD>>();
            try
            {
                var result = await _outstandingFWDService.GetOutstandingFWD(dealNo, dealNoTo, contractDate, contractDateTo, valueDate, valueDateTo, entryDate, entryDateTo, ccy, portFolio, branchcode, trader, customer, orderBy);
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
