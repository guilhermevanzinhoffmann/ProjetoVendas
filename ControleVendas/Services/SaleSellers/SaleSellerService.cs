using ControleVendas.Items;
using ControleVendas.Models;
using ControleVendas.Models.Inputs;
using ControleVendas.Models.Views;
using ControleVendas.Repositories.Sales.SaleSellers;
using ControleVendas.Repositories.Sellers;
using ControleVendas.Repositories.Unities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleVendas.Services.Sales
{
    public class SaleSellerService : ISaleSellerService
    {
        private readonly ISaleSellerRepository _repository;
        private readonly IUnitRepository _unitRepository;
        private readonly ISellerRepository _sellerRepository;
        
        public SaleSellerService(ISaleSellerRepository repository, IUnitRepository unitRepository, ISellerRepository sellerRepository) 
        {
            _repository = repository;
            _unitRepository = unitRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<SaleView> AddSaleAsync(SaleInput input, int sellerId)
        {
            var seller = await _sellerRepository.GetAsync(sellerId);
            
            if(seller == null)
                throw new ArgumentNullException($"Vendedor não encontrado.\n{nameof(seller)}");

            var unit = seller.Unit;

            if (unit == null)
                throw new ArgumentNullException($"Unidade não encontrada.\n{nameof(unit)}");

            if (!DateTime.TryParse($"{input.Date} {input.Hour}", out DateTime createdAt))
                throw new ArgumentException("Verifique formato de data e hora informados.");

            var units = await _unitRepository.GetAllAsync();

            if (units == null || !units.Any())
                throw new ArgumentException("Nenhuma unidade encontrada");

            var nearestUnit = DistanceCalculationUnits.GetNearestUnit(double.Parse(input.Latitude), double.Parse(input.Longitude), units);

            int? unitRoamingId = unit.Id == nearestUnit.Id ? null : nearestUnit.Id;

            Sale sale = new() 
            {
                CreatedAt = createdAt.ToUniversalTime(),
                UnitID = unit.Id,
                Unit = unit,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Value = input.Value,
                RoamingUnitId = unitRoamingId,
                SellerID = seller.Id
            };

            await _repository.AddAsync(sale);

            return new SaleView(sale, nearestUnit);
        }

        public async Task<IEnumerable<SaleView>> GetAllSalesFromSellerAsync(int sellerId, string? initialPeriod, string? finalPeriod)
        {
            var sales = await _repository.GetAllSalesFromSellerAsync(sellerId, initialPeriod, finalPeriod);

            if (sales == null || !sales.Any())
                return Enumerable.Empty<SaleView>();

            List<SaleView> result = new();
            
            foreach(var sale in sales)
            {
                var nearestUnit = sale.RoamingUnitId != null ? await _unitRepository.GetAsync(sale.RoamingUnitId.Value) : null;

                result.Add(new SaleView(sale, nearestUnit));
            }

            return result;
        }

        public async Task<SaleView> GetSaleFromSellerAsync(int id, int sellerId)
        {
            var sale = await _repository.GetFromSellerAsync(id, sellerId);

            if(sale == null)
                return null;

            var unitRoaming = sale.RoamingUnitId == null ? null : await _unitRepository.GetAsync(sale.RoamingUnitId.Value);

            return new SaleView(sale, unitRoaming);
        }
    }
}
