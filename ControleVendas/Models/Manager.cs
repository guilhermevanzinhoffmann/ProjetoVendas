namespace ControleVendas.Models
{
    public class Manager : User
    {
        public int UnityID { get; set; }
        public virtual Unity Unity { get; set; }

    }
}
