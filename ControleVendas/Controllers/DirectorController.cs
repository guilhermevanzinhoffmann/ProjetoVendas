using ControleVendas.Models.Views;
using ControleVendas.Services.SaleDirectors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    [ApiController]
    [Route("api/director")]
    public class DirectorController : ControllerBase
    {
        private readonly ISaleDirectorService _service;
        public DirectorController(ISaleDirectorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Director")]
        [Route("sale/getSale/{id}")]
        public async Task<ActionResult<SaleView>> GetSaleAsync(int id)
        {
            if (id < 1)
            {
                BadRequest($"Id deve ser maior que 0");
            }

            var directorId = int.Parse(User.Identity.Name ?? "0");

            var saleView = await _service.GetSaleFromDirectorAsync(id, directorId);

            if (saleView == null)
                return NotFound("Venda não encontrada.");

            return Ok(saleView);
        }

        [HttpGet]
        [Authorize(Roles = "Director")]
        [Route("sale/getAll")]
        public async Task<ActionResult<IEnumerable<SaleView>>> GetAllSaleAsync(string? initPeriod, string? finalPeriod, string? sellers, string? units)
        {
            var directorId = int.Parse(User.Identity.Name ?? "0");
            return Ok(await _service.GetAllSalesFromDirectorAsync(directorId, initPeriod, finalPeriod, sellers, units));
        }
    }
}
