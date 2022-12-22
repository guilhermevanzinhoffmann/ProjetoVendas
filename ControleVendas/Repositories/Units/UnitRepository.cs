using ControleVendas.DBManager;
using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories.Unities
{
    public class UnitRepository : IUnitRepository
    {
        private readonly SalesContext _context;
        public UnitRepository(SalesContext context) 
        {
            _context = context;
        }

        public async Task<Unit> GetAsync(int id)
            => await _context.Units
            .Include(u => u.Board)
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<Unit>> GetAllAsync()
            => await _context.Units
            .Include(u => u.Board)
            .ToListAsync();
    }
}
