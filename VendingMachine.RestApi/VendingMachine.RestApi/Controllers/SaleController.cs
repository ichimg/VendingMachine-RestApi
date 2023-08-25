using Microsoft.AspNetCore.Mvc;
using VendingMachine.Domain.Abstractions;
using VendingMachine.Domain.ApiModels;
using VendingMachine.Logic.Abstractions;
using VendingMachine.Logic.Exceptions;

namespace VendingMachine.RestApi.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
        }

        [HttpGet]
        public async Task<ActionResult<List<SaleDto>>> GetSales(DateTime? startDate = null, DateTime? endDate = null)
        {
            List<SaleDto> results = await saleService.GetSales(startDate, endDate);

            return Ok(results);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSales(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                await saleService.DeleteSales(startDate, endDate);
            }
            catch (InvalidDateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
