namespace ControleVendas.Models.Views
{
    public class SaleView
    {
        public SaleView() { }
        
        public SaleView(Sale sale, Unit? unitRoaming)
        {
            Id = sale.Id == 0 ? null : sale.Id;
            Value = sale.Value;
            CreatedAt = sale.CreatedAt;
            BoardName = sale?.Unit?.Board?.Name ?? string.Empty;
            Latitude = sale?.Latitude ?? string.Empty;
            Longitude = sale?.Longitude ?? string.Empty;
            UnitLat = sale?.Unit?.Latitude ?? string.Empty;
            UnitLong = sale?.Unit?.Longitude ?? string.Empty;
            UnitName = sale?.Unit.Name ?? string.Empty;
            SellerName = sale?.Seller?.Name ?? string.Empty;
            IsRoaming = unitRoaming != null;
            UnitNameRoaming = unitRoaming?.Name ?? string.Empty;
            UnitRoamingLat = unitRoaming?.Latitude ?? string.Empty;
            UnitRoamingLong = unitRoaming?.Longitude ?? string.Empty;
        }


        public int? Id { get; set; }
        public float Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BoardName { get; set; }
        public string UnitName { get; set; }
        public string UnitLat { get; set; }
        public string UnitLong { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SellerName { get; set; }
        public bool? IsRoaming { get; set; }
        public string UnitNameRoaming { get; set; }
        public string UnitRoamingLat { get; set; }
        public string UnitRoamingLong { get; set; }
    }
}
