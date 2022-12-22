namespace ControleVendas.Models
{
    public class Manager : User
    {
        public int UnitID { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
