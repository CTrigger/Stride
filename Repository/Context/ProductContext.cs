using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository.Context
{
    public class ProductContext : DbContext
    {
        #region ctor
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        
        #endregion

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Midia> Midias { get; set; }
        #endregion

        #region Roles
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }

        #endregion

    }
}
