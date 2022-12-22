namespace ControleVendas.Models
{
    public class Seller : User
    {
        public int UnityID { get; set; }
        public virtual Unity Unity { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
