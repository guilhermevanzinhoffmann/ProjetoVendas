using ControleVendas.Models;
namespace ControleVendas.Repositories.Sales
{
    public interface ISaleRepository
    {
        Task<Sale> GetFromSellerAsync(int id, int sellerId);
        Task<IEnumerable<Sale>> GetAllSalesFromSellerAsync(int sellerId, string? initialPeriod, string? finalPeriod);

        Task AddAsync(Sale sale);
    }
}
