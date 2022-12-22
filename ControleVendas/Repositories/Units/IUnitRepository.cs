using ControleVendas.Models;

namespace ControleVendas.Repositories.Unities
{
    public interface IUnitRepository
    {
        Task<Unit> GetAsync(int id);
        
        Task<IEnumerable<Unit>> GetAllAsync();
    }
}
