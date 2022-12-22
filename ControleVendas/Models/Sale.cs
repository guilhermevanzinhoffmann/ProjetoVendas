namespace ControleVendas.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public float Value { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? RoamingUnitId { get; set; }
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; }
        public int UnitID { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
