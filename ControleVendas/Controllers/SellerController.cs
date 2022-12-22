using ControleVendas.Models.Views;
using Microsoft.AspNetCore.Mvc;
using ControleVendas.Services.Sales;
using Microsoft.AspNetCore.Authorization;
using ControleVendas.Models.Inputs;

namespace ControleVendas.Controllers
{
    [ApiController]
    [Route("api/seller")]
    public class SellerController : ControllerBase
    {
        private readonly ISaleService _service;
        public SellerController(ISaleService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Seller")]
        [Route("sale/getSale/{id}")]
        public async Task<ActionResult<SaleView>> GetSaleAsync(int id)
        {
            if (id < 1)
            {
                BadRequest($"Id deve ser maior que 0");
            }
            
            var sellerId = int.Parse(User.Identity.Name ?? "0");
            
            var saleView = await _service.GetSaleFromSellerAsync(id, sellerId);

            if (saleView == null)
                return NotFound("Venda não encontrada.");

            return Ok(saleView);
        }

        [HttpGet]
        [Authorize(Roles = "Seller")]
        [Route("sale/getAll")]
        public async Task<ActionResult<IEnumerable<SaleView>>> GetAllSaleAsync(string? initPeriod, string? finalPeriod)
        {
            var sellerId = int.Parse(User.Identity.Name ?? "0");
            return Ok(await _service.GetAllSalesFromSellerAsync(sellerId, initPeriod, finalPeriod));
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        [Route("sale/post")]
        public async Task<ActionResult<SaleView>> PostSaleAsync([FromBody] SaleInput input)
        {
            if (input == null)
                return BadRequest("Venda deve ser informada.");

            if (string.IsNullOrEmpty(input.Latitude))
                return BadRequest("Latitude deve ser informada.");

            if (string.IsNullOrEmpty(input.Longitude))
                return BadRequest("Longitude deve ser informada.");

            if (string.IsNullOrEmpty(input.Hour))
                return BadRequest("Hora deve ser informada.");

            if (string.IsNullOrEmpty(input.Date))
                return BadRequest("Data deve ser informada.");
            
            var sellerId = User.Identity.Name ?? "0";

            var saleView = await _service.AddSaleAsync(input, int.Parse(sellerId)); 
            
            return Ok(saleView);
        }
    }
}
