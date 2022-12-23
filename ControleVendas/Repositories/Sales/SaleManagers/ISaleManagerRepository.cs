using ControleVendas.Models;

namespace ControleVendas.Repositories.Sales.SaleManagers
{
    public interface ISaleManagerRepository
    {
        Task<Sale> GetFromManagerAsync(int id, int managerId);
        Task<IEnumerable<Sale>> GetAllSalesAsync(int managerId, string? initialPeriod, string? finalPeriod, List<int>? sellers);
    }
}