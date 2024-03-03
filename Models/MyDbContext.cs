
using Microsoft.EntityFrameworkCore;

namespace activos.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Departamentos> departamentos { get; set; }

        public DbSet<tipo> tipo { get; set; }

        public DbSet<empleado> empleado { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            departamentos = Set<Departamentos>();
            tipo = Set<tipo>();
            empleado = Set<empleado>();

        }
    }
}
