using ControleVendas.Models.Inputs;
using ControleVendas.Models.Views;

namespace ControleVendas.Services.SaleManagers
{
    public interface ISaleManagerService
    {
        Task<SaleView> GetSaleFromManagerAsync(int id, int managerId);
        Task<IEnumerable<SaleView>> GetAllSalesFromManagerAsync(int managerId, string? initialPeriod, string? finalPeriod, string? sellers);
    }
}
