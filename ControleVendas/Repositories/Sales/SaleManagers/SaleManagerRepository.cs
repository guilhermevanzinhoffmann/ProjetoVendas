using ControleVendas.DBManager;
using ControleVendas.Models;
using ControleVendas.Repositories.Sales.SaleExtensions;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories.Sales.SaleManagers
{
    public class SaleManagerRepository : ISaleManagerRepository
    {
        private readonly SalesContext _context;
        public SaleManagerRepository(SalesContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync(int managerId, string? initialPeriod, string? finalPeriod, List<int>? sellers)
        {
            IQueryable<Sale>? result = null;
            
            if (string.IsNullOrEmpty(initialPeriod) && string.IsNullOrEmpty(finalPeriod))
            {
                result = _context.Sales.FilterAsync(s => s.Unit.ManagerID == managerId,
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller));
            }
            else if (!string.IsNullOrEmpty(initialPeriod) && string.IsNullOrEmpty(finalPeriod))
            {
                if (DateTime.TryParse(initialPeriod, out var createdAt))
                {
                    result = _context.Sales.FilterAsync(s => s.Unit.ManagerID == managerId && s.CreatedAt >= createdAt.ToUniversalTime(),
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller));
                }
                else
                {
                    throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(initialPeriod)}");
                }
                
            }
            else if (string.IsNullOrEmpty(initialPeriod) && !string.IsNullOrEmpty(finalPeriod))
            {
                if (DateTime.TryParse(finalPeriod, out var createdAt))
                {
                    result = _context.Sales.FilterAsync(s => s.Unit.ManagerID == managerId && s.CreatedAt <= createdAt.ToUniversalTime(),
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller));
                }
                else
                {
                    throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(finalPeriod)}");
                }
                
            }
            else
            {
                if (!DateTime.TryParse(initialPeriod, out var createdAtInit))
                    throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(initialPeriod)}");

                if (!DateTime.TryParse(finalPeriod, out var createdAtFinal))
                    throw new ArgumentException($"Verifique formato de hora e data.\n{nameof(finalPeriod)}");

                result = _context.Sales.FilterAsync(s => s.Unit.ManagerID == managerId && s.CreatedAt >= createdAtInit.ToUniversalTime() && s.CreatedAt <= createdAtFinal.ToUniversalTime(),
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller));
            }

            if (sellers == null || !sellers.Any())
                return await result.ToListAsync();

            return await result.Where(s => sellers.Any(se => se == s.SellerID)).ToListAsync();
        }
        
        public async Task<Sale> GetFromManagerAsync(int id, int managerId)
            => await _context.Sales
            .Include(s => s.Unit)
                    .ThenInclude(u => u.Board)
            .Include(s => s.Seller)
            .Where(s => s.Unit.ManagerID == managerId)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
