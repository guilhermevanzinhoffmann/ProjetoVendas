using ControleVendas.Models.Views;
using ControleVendas.Repositories.Sales.SaleDirectors;
using ControleVendas.Repositories.Unities;

namespace ControleVendas.Services.SaleDirectors
{
    public class SaleDirectorService : ISaleDirectorService
    {
        private readonly ISaleDirectorRepository _repository;
        private readonly IUnitRepository _unitRepository;

        public SaleDirectorService(ISaleDirectorRepository repository,IUnitRepository unitRepository)
        {
            _repository = repository;
            _unitRepository = unitRepository;
        }

        public async Task<IEnumerable<SaleView>> GetAllSalesFromDirectorAsync(int directorId, string? initialPeriod, string? finalPeriod, string? sellers, string? units)
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

            var sales = await _repository.GetAllSalesAsync(directorId, initialPeriod, finalPeriod, idsSellers, idsUnits);

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

        public async Task<SaleView> GetSaleFromDirectorAsync(int id, int directorId)
        {
            var sale = await _repository.GetFromDirectorAsync(id, directorId);

            if (sale == null)
                return null;

            var unitRoaming = sale.RoamingUnitId == null ? null : await _unitRepository.GetAsync(sale.RoamingUnitId.Value);

            return new SaleView(sale, unitRoaming);
        }
    }
}
