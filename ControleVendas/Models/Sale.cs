namespace ControleVendas.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? RoamingUnityId { get; set; }
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; }
        public int UnityID { get; set; }
        public virtual Unity Unity { get; set; }
    }
}
