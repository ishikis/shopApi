using Microsoft.EntityFrameworkCore;

namespace shopApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<category> categories { get; set; }
        public DbSet<product> products { get; set; }
    }
}
