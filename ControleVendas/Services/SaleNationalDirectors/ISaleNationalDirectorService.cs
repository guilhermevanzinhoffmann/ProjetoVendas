using ControleVendas.Models.Views;

namespace ControleVendas.Services.SaleNationalDirectors
{
    public interface ISaleNationalDirectorService
    {
        Task<SaleView> GetSaleFromNationalDirectorAsync(int id);
        Task<IEnumerable<SaleView>> GetAllSalesFromNationalDirectorAsync(string? initialPeriod, string? finalPeriod, string? sellers, string? units, string? boards);
    }
}
