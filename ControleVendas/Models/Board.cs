namespace ControleVendas.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectorID { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
