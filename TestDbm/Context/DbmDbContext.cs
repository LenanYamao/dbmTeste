using Microsoft.EntityFrameworkCore;
using TestDbm.Models;

namespace TestDbm.Context
{
    public class DbmDbContext : DbContext
    {
        public DbmDbContext(DbContextOptions<DbmDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
