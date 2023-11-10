using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entity;

namespace WebApplication1.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
