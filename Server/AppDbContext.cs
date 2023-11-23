using DataModel;
using Microsoft.EntityFrameworkCore;

namespace Server
{
    public class AppDbContext : DbContext
    {
        //Список всех 
        public DbSet<Products> Products => Set<Products>();
        public DbSet<ProductGroup> ProductGroup => Set<ProductGroup>();
        public DbSet<ProductStatuses> ProductStatuses => Set<ProductStatuses>();
        public DbSet<Shelving> Shelving => Set<Shelving>();
        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<OrderTypes> OrderTypes => Set<OrderTypes>();
        public DbSet<OrderStatuses> OrderStatuses => Set<OrderStatuses>();
        public DbSet<ProductStatusInOrder> ProductStatusInOrder => Set<ProductStatusInOrder>();
        public DbSet<ProductsOnShelves> ProductsOnShelves => Set<ProductsOnShelves>();
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
