using ControleVendas.Models;

namespace ControleVendas.Repositories.Sales.SaleDirectors
{
    public interface ISaleDirectorRepository
    {
        Task<Sale> GetFromDirectorAsync(int id, int directorId);
        Task<IEnumerable<Sale>> GetAllSalesAsync(int directorId, string? initialPeriod, string? finalPeriod, List<int>? sellers, List<int>? units);
    }
}
