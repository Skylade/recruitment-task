using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
