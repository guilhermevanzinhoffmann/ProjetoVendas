using ControleVendas.Models.Inputs;
using ControleVendas.Models.Views;

namespace ControleVendas.Services.Sales
{
    public interface ISaleSellerService
    {
        Task<SaleView> GetSaleFromSellerAsync(int id, int sellerId);
        Task<IEnumerable<SaleView>> GetAllSalesFromSellerAsync(int sellerId, string? initialPeriod, string? finalPeriod);
        Task<SaleView> AddSaleAsync(SaleInput input, int sellerId);
    }
}
