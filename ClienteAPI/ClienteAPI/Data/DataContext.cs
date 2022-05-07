using ClienteAPI.models;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
