using ControleVendas.DBManager;
using ControleVendas.Models;
using ControleVendas.Repositories.Sales.SaleExtensions;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ControleVendas.Repositories.Sales.SaleNationalDirector
{
    public class SaleNationalDirectorRepository : ISaleNationalDirectorRepository
    {
        private readonly SalesContext _context;

        public SaleNationalDirectorRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync(string? initialPeriod, string? finalPeriod, List<int>? sellers, List<int>? units, List<int>? boards)
        {
            IQueryable<Sale>? result = null;

            if (string.IsNullOrEmpty(initialPeriod) && string.IsNullOrEmpty(finalPeriod))
            {
                result = _context.Sales.FilterAsync(null,
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller));
            }
            else if (!string.IsNullOrEmpty(initialPeriod) && string.IsNullOrEmpty(finalPeriod))
            {
                if (DateTime.TryParse(initialPeriod, out var createdAt))
                {
                    result = _context.Sales.FilterAsync(s => s.CreatedAt >= createdAt.ToUniversalTime(),
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
                    result = _context.Sales.FilterAsync(s => s.CreatedAt <= createdAt.ToUniversalTime(),
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

                result = _context.Sales.FilterAsync(s => s.CreatedAt >= createdAtInit.ToUniversalTime() && s.CreatedAt <= createdAtFinal.ToUniversalTime(),
                        i => i.Include(s => s.Unit)
                            .ThenInclude(u => u.Board)
                           .Include(s => s.Seller));
            }

            if ((sellers == null || !sellers.Any()) && (units == null || !units.Any()) && (boards == null || !boards.Any()))
                return await result.ToListAsync();

            if ((sellers != null && sellers.Any()) && (units == null || !units.Any()) && (boards == null || !boards.Any()))
                return await result.Where(s => sellers.Any(se => se == s.SellerID)).ToListAsync();

            if ((sellers == null || !sellers.Any()) && (units != null && units.Any()) && (boards == null || !boards.Any()))
                return await result.Where(s => units.Any(u => u == s.UnitID)).ToListAsync();

            if ((sellers == null || !sellers.Any()) && (units == null || !units.Any()) && (boards != null && boards.Any()))
                return await result.Where(s => boards.Any(u => u == s.Unit.BoardID)).ToListAsync();

            if ((sellers != null && sellers.Any()) && (units != null && units.Any()) && (boards == null || !boards.Any()))
                return await result.Where(s => units.Any(u => u == s.UnitID) && sellers.Any(se => se == s.SellerID)).ToListAsync();

            if ((sellers != null && sellers.Any()) && (units == null && !units.Any()) && (boards != null || boards.Any()))
                return await result.Where(s => boards.Any(u => u == s.Unit.BoardID) && sellers.Any(se => se == s.SellerID)).ToListAsync();

            if ((sellers == null && !sellers.Any()) && (units != null && units.Any()) && (boards != null || boards.Any()))
                return await result.Where(s => boards.Any(u => u == s.Unit.BoardID) && units.Any(u => u == s.UnitID)).ToListAsync();

            return await result.Where(s => units.Any(u => u == s.UnitID) && sellers.Any(se => se == s.SellerID) && boards.Any(u => u == s.Unit.BoardID)).ToListAsync();
        }

        public async Task<Sale> GetFromNationalDirectorAsync(int id)
            => await _context.Sales
            .Include(s => s.Unit)
                .ThenInclude(u => u.Board)
            .Include(s => s.Seller)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
