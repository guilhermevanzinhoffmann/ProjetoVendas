using ControleVendas.DBManager;
using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories.Sellers
{
    public class SellerRepository :ISellerRepository
    {
        private readonly SalesContext _context;

        public SellerRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Seller> GetAsync(int id)
            => await _context.Sellers
            .Include(s => s.Unit)
            . FirstOrDefaultAsync(s => s.Id == id);
    }
}
