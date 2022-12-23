using ControleVendas.Models;
using ControleVendas.Models.Views;
using ControleVendas.Repositories.Sales.SaleManagers;
using ControleVendas.Repositories.Unities;

namespace ControleVendas.Services.SaleManagers
{
    public class SaleManagerService : ISaleManagerService
    {
        private readonly ISaleManagerRepository _repository;
        private readonly IUnitRepository _unitRepository;
        
        public SaleManagerService(ISaleManagerRepository saleManagerRepository, IUnitRepository unitRepository) 
        {
            _repository = saleManagerRepository;
            _unitRepository = unitRepository;
        }

        public async Task<IEnumerable<SaleView>> GetAllSalesFromManagerAsync(int managerId, string? initialPeriod, string? finalPeriod, string? sellers)
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

            var sales = await _repository.GetAllSalesAsync(managerId, initialPeriod, finalPeriod, idsSellers);

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

        public async Task<SaleView> GetSaleFromManagerAsync(int id, int managerId)
        {
            var sale = await _repository.GetFromManagerAsync(id, managerId);

            if (sale == null)
                return null;

            var unitRoaming = sale.RoamingUnitId == null ? null : await _unitRepository.GetAsync(sale.RoamingUnitId.Value);

            return new SaleView(sale, unitRoaming);
        }
    }
}
