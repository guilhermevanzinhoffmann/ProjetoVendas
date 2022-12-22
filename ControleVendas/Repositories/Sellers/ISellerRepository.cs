using ControleVendas.Models;

namespace ControleVendas.Repositories.Sellers
{
    public interface ISellerRepository
    {
        Task<Seller> GetAsync(int id);
    }
}
