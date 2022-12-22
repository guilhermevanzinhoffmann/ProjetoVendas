namespace ControleVendas.Models
{
    public class Unity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int ManagerID { get; set; }
        public virtual Manager Manager { get; set; }
        public int BoardID { get; set; }
        public virtual Board Board { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
