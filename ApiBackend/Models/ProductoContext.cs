using Microsoft.EntityFrameworkCore;

namespace ApiBackend.Models
{
    public class ProductoContext : DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options) { }

        public DbSet<Productos> Productos { get; set; }
    }
}
