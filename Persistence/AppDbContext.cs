using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace MyApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Khai báo DbSet cho bảng Customers
        public DbSet<Customer> Customers { get; set; }
    }
}
