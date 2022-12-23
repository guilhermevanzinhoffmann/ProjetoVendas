using ControleVendas.Models;

namespace ControleVendas.Repositories.Sales.SaleNationalDirector
{
    public interface ISaleNationalDirectorRepository
    {
        Task<Sale> GetFromNationalDirectorAsync(int id);
        Task<IEnumerable<Sale>> GetAllSalesAsync(string? initialPeriod, string? finalPeriod, List<int>? sellers, List<int>? units, List<int>? boards);
    }
}
