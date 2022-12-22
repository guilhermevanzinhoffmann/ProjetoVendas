using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.DBManager
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<NationalDirector> NationalDirectors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserModelBuilder(modelBuilder);
            SaleModelBuilder(modelBuilder);
            UnitModelBuilder(modelBuilder);
            BoardModelBuilder(modelBuilder);
        }

        private void UserModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().UseTptMappingStrategy();

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.HasKey(u => u.Id);
                e.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");
                e.Property(u => u.Name).IsRequired().HasColumnName("name");
                e.Property(u => u.Email).IsRequired().HasColumnName("email");
                e.Property(u => u.Password).IsRequired().HasColumnName("password");
                e.Property(u => u.Role).HasColumnName("role").HasDefaultValue("seller");
            });

            modelBuilder.Entity<NationalDirector>(e =>
            {
                e.ToTable("nationaldirectors");
                e.Ignore(n => n.Boards);
            });

            modelBuilder.Entity<Director>(e =>
            {
                e.ToTable("directors");
            });

            modelBuilder.Entity<Manager>(e =>
            {
                e.ToTable("managers");
            });

            modelBuilder.Entity<Seller>(e =>
            {
                e.ToTable("sellers");
            });
        }

        private void SaleModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(s =>
            {
                s.ToTable("sales");
                s.HasKey(s => s.Id);
                s.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("id");
                s.Property(s => s.CreatedAt).HasColumnName("created_at");
                s.Property(s => s.Value).HasColumnName("value");
                s.Property(s => s.Latitude).HasColumnName("latitude");
                s.Property(s => s.Longitude).HasColumnName("longitude");
                s.Property(s => s.RoamingUnitId).HasColumnName("roaming_unit_id").IsRequired(false);
                s.HasOne(s => s.Seller).WithMany(se => se.Sales);
                s.HasOne(s => s.Unit).WithMany(u => u.Sales);
            });
        }

        private void UnitModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>(u =>
            {
                u.ToTable("units");
                u.HasKey(u => u.Id);
                u.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");
                u.Property(u => u.Name).HasColumnName("name");
                u.Property(u => u.Latitude).HasColumnName("latitude");
                u.Property(u => u.Longitude).HasColumnName("longitude");
                u.HasOne(u => u.Manager).WithOne(m => m.Unit).HasForeignKey<Unit>(u => u.ManagerID);
                u.HasOne(u => u.Board).WithMany(b => b.Units);
                u.HasMany(u => u.Sellers).WithOne(se => se.Unit);
            });
        }

        private void BoardModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>(b =>
            {
                b.ToTable("boards");
                b.HasKey(b => b.Id);
                b.Property(b => b.Id).ValueGeneratedOnAdd().HasColumnName("id");
                b.Property(b => b.Name).HasColumnName("name");
                b.HasOne(u => u.Director).WithOne(d => d.Board).HasForeignKey<Board>(b => b.DirectorID);
            });
        }
    }
}
