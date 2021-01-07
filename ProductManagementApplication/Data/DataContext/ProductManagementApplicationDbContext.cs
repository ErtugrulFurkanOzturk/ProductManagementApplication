using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext
{
    public class ProductManagementApplicationDbContext: IdentityDbContext
    {
        public ProductManagementApplicationDbContext(DbContextOptions options) :base(options)
        {

        }

        //name of columns in database
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
