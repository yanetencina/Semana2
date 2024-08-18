using Microsoft.EntityFrameworkCore;
using SucursalesABMWeb.Models;

namespace SucursalesABMWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sucursal> Sucursales { get; set; }
    }
}
