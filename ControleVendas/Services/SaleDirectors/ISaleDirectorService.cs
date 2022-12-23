using ControleVendas.Models.Views;

namespace ControleVendas.Services.SaleDirectors
{
    public interface ISaleDirectorService
    {
        Task<SaleView> GetSaleFromDirectorAsync(int id, int directorId);
        Task<IEnumerable<SaleView>> GetAllSalesFromDirectorAsync(int directorId, string? initialPeriod, string? finalPeriod, string? sellers, string? units);
    }
}
