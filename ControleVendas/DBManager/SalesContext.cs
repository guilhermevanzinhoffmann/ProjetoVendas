using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.DBManager
{
    public class SalesContext : DbContext
    {
        //public SalesContext() {}

        public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserModelBuilder(modelBuilder);
        }

        private void UserModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.HasKey(u => u.Id);
                e.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");
                e.Property(u => u.Username).IsRequired().HasColumnName("username");
                e.Property(u => u.Password).IsRequired().HasColumnName("password");
                e.Property(u => u.Role).HasColumnName("role").HasDefaultValue("employee");
            });
        }
    }
}
