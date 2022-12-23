using ControleVendas.Models.Views;
using ControleVendas.Services.SaleNationalDirectors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    [ApiController]
    [Route("api/nationaldirector")]
    public class NationalDirectorController : ControllerBase
    {
        private readonly ISaleNationalDirectorService _service;
        public NationalDirectorController(ISaleNationalDirectorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "NationalDirector")]
        [Route("sale/getSale/{id}")]
        public async Task<ActionResult<SaleView>> GetSaleAsync(int id)
        {
            if (id < 1)
            {
                BadRequest($"Id deve ser maior que 0");
            }

            var saleView = await _service.GetSaleFromNationalDirectorAsync(id);

            if (saleView == null)
                return NotFound("Venda não encontrada.");

            return Ok(saleView);
        }

        [HttpGet]
        [Authorize(Roles = "NationalDirector")]
        [Route("sale/getAll")]
        public async Task<ActionResult<IEnumerable<SaleView>>> GetAllSaleAsync(string? initPeriod, string? finalPeriod, string? sellers, string? units, string? boards)
        {
            return Ok(await _service.GetAllSalesFromNationalDirectorAsync(initPeriod, finalPeriod, sellers, units, boards));
        }
    }
}
