using ControleVendas.DBManager;
using ControleVendas.Models;
using ControleVendas.Repositories.Sales.SaleExtensions;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories.Sales.SaleSellers
{
    public class SaleSellerRepository : ISaleSellerRepository
    {
        private readonly SalesContext _context;
        public SaleSellerRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Sale> GetFromSellerAsync(int id, int sellerId)
            => await _context.Sales
                .Include(s => s.Unit)
                    .ThenInclude(u => u.Board)
                .Include(s => s.Seller)
                .Where(s => s.SellerID == sellerId)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<IEnumerable<Sale>> GetAllSalesFromSellerAsync(int sellerId, string? initialPeriod, string? finalPeriod)
        {
            if (string.IsNullOrEmpty(initialPeriod) && string.IsNullOrEmpty(finalPeriod))
            {
                return await _context.Sales.FilterAsync(s => s.SellerID == sellerId,
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller))
                    .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(initialPeriod) && string.IsNullOrEmpty(finalPeriod))
            {
                if (DateTime.TryParse(initialPeriod, out var createdAt))
                {
                    return await _context.Sales.FilterAsync(s => s.SellerID == sellerId && s.CreatedAt >= createdAt.ToUniversalTime(),
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller))
                    .ToListAsync();
                }
                throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(initialPeriod)}");
            }
            else if (string.IsNullOrEmpty(initialPeriod) && !string.IsNullOrEmpty(finalPeriod))
            {
                if (DateTime.TryParse(finalPeriod, out var createdAt))
                {
                    return await _context.Sales.FilterAsync(s => s.SellerID == sellerId && s.CreatedAt <= createdAt.ToUniversalTime(),
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller))
                    .ToListAsync();
                }
                throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(finalPeriod)}");
            }
            else
            {
                if (!DateTime.TryParse(initialPeriod, out var createdAtInit))
                    throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(initialPeriod)}");

                if (!DateTime.TryParse(finalPeriod, out var createdAtFinal))
                    throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(finalPeriod)}");

                return await _context.Sales.FilterAsync(s => s.SellerID == sellerId && s.CreatedAt >= createdAtInit.ToUniversalTime() && s.CreatedAt <= createdAtFinal.ToUniversalTime(),
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller))
                    .ToListAsync();
            }

        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }
    }
}
