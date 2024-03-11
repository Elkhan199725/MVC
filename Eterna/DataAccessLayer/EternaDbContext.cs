using Eterna.Models;
using Microsoft.EntityFrameworkCore;

namespace Eterna.DataAccessLayer
{
    public class EternaDbContext : DbContext
    {
        public EternaDbContext(DbContextOptions<EternaDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductImages> ProductImages { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Slider> Sliders { get; set; } = null!;
        public DbSet<Feature> Features { get; set; } = null!;
    }
}