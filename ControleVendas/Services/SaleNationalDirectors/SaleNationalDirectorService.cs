using ControleVendas.Models.Views;
using ControleVendas.Repositories.Sales.SaleNationalDirector;
using ControleVendas.Repositories.Unities;

namespace ControleVendas.Services.SaleNationalDirectors
{
    public class SaleNationalDirectorService : ISaleNationalDirectorService
    {
        private readonly ISaleNationalDirectorRepository _repository;
        private readonly IUnitRepository _unitRepository;

        public SaleNationalDirectorService(ISaleNationalDirectorRepository repository, IUnitRepository unitRepository)
        {
            _repository = repository;
            _unitRepository = unitRepository;
        }
        
        public async Task<IEnumerable<SaleView>> GetAllSalesFromNationalDirectorAsync(string? initialPeriod, string? finalPeriod, string? sellers, string? units, string? boards)
        {
            List<int>? idsSellers = new();

            if (string.IsNullOrEmpty(sellers))
            {
                idsSellers = null;
            }
            else
            {
                foreach (var id in sellers.Split(','))
                {
                    idsSellers.Add(int.Parse(id));
                }
            }

            if (idsSellers != null && !idsSellers.Any())
                throw new ArgumentException("A lista de ids de vendedores deve ser separada por vírgula.");

            List<int>? idsUnits = new();

            if (string.IsNullOrEmpty(units))
            {
                idsUnits = null;
            }
            else
            {
                foreach (var id in units.Split(','))
                {
                    idsUnits.Add(int.Parse(id));
                }
            }

            if (idsUnits != null && !idsUnits.Any())
                throw new ArgumentException("A lista de ids de unidades deve ser separada por vírgula.");

            List<int>? idsBoards = new();

            if (string.IsNullOrEmpty(boards))
            {
                idsBoards = null;
            }
            else
            {
                foreach (var id in boards.Split(','))
                {
                    idsBoards.Add(int.Parse(id));
                }
            }

            if (idsBoards != null && !idsBoards.Any())
                throw new ArgumentException("A lista de ids de diretorias deve ser separada por vírgula.");

            var sales = await _repository.GetAllSalesAsync(initialPeriod, finalPeriod, idsSellers, idsUnits, idsBoards);

            if (sales == null || !sales.Any())
                return Enumerable.Empty<SaleView>();

            List<SaleView> result = new();

            foreach (var sale in sales)
            {
                var nearestUnit = sale.RoamingUnitId != null ? await _unitRepository.GetAsync(sale.RoamingUnitId.Value) : null;

                result.Add(new SaleView(sale, nearestUnit));
            }

            return result;
        }

        public async Task<SaleView> GetSaleFromNationalDirectorAsync(int id)
        {
            var sale = await _repository.GetFromNationalDirectorAsync(id);

            if (sale == null)
                return null;

            var unitRoaming = sale.RoamingUnitId == null ? null : await _unitRepository.GetAsync(sale.RoamingUnitId.Value);

            return new SaleView(sale, unitRoaming);
        }
    }
}
