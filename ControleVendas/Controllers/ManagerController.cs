using ControleVendas.Models.Views;
using ControleVendas.Services.SaleManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    [ApiController]
    [Route("api/manager")]
    public class ManagerController : ControllerBase
    {
        private readonly ISaleManagerService _service;
        public ManagerController(ISaleManagerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        [Route("sale/getSale/{id}")]
        public async Task<ActionResult<SaleView>> GetSaleAsync(int id)
        {
            if (id < 1)
            {
                BadRequest($"Id deve ser maior que 0");
            }

            var sellerId = int.Parse(User.Identity.Name ?? "0");

            var saleView = await _service.GetSaleFromManagerAsync(id, sellerId);

            if (saleView == null)
                return NotFound("Venda não encontrada.");

            return Ok(saleView);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        [Route("sale/getAll")]
        public async Task<ActionResult<IEnumerable<SaleView>>> GetAllSaleAsync(string? initPeriod, string? finalPeriod, string? sellers)
        {
            var sellerId = int.Parse(User.Identity.Name ?? "0");
            return Ok(await _service.GetAllSalesFromManagerAsync(sellerId, initPeriod, finalPeriod, sellers));
        }
    }
}
