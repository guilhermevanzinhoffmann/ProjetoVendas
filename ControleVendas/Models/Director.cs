using System.Security.Policy;

namespace ControleVendas.Models
{
    public class Director : User
    {
        public int BoardID { get; set; }
        public virtual Board Board { get; set; }
    }
}
