using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Response;
using Services.Interface;

namespace OSR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IFilterService _filterService;
        public FiltersController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("GetCurrency")]
        public async Task<IActionResult> GetCurrency()
        {
            var response = new ApiResponse<IEnumerable<string>>();
            try
            {
                var result = await _filterService.GetCurrency();
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "CCY is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All CCY Data";
                    response.Data = (IEnumerable<string>)result;
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
        [HttpGet("GetPortfolio")]
        public async Task<IActionResult> GetPortfolio()
        {
            var response = new ApiResponse<IEnumerable<string>>();
            try
            {
                var result = await _filterService.GetPortfolio();
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Portfolio is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Portfolio Data";
                    response.Data = (IEnumerable<string>)result;
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
        [HttpGet("GetTrader")]
        public async Task<IActionResult> GetTrader()
        {
            var response = new ApiResponse<IEnumerable<string>>();
            try
            {
                var result = await _filterService.GetTrader();
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "Trader is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Traders Data";
                    response.Data = (IEnumerable<string>)result;
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
        [HttpGet("GetBranchCode")]
        public async Task<IActionResult> GetBranchCode()
        {
            var response = new ApiResponse<IEnumerable<string>>();
            try
            {
                var result = await _filterService.GetBranchCode();
                if (result == null)
                {
                    response.Success = false;
                    response.Message = "BranchCode is Empty";
                    return BadRequest(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "All Branch Codes Data";
                    response.Data = (IEnumerable<string>)result;
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
