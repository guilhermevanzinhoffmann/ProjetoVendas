namespace ControleVendas.Models
{
    public class Seller : User
    {
        public int UnitID { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
