using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Model
{
    public class DatabaseContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Person> Person { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;   
        public DbSet<Purpose> Purpose { get; set; } = null!;
    }
}
