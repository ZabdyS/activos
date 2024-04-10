
using Microsoft.EntityFrameworkCore;

namespace activos.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Departamento> departamentos { get; set; }

        public DbSet<Tipo> tipo { get; set; }

        public DbSet<Empleado> empleado { get; set; }

        public DbSet<ActivoFijo> ActivosFijos { get; set; }
        public DbSet<TipoActivo> TipoActivos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CalculoDepreciacion> CalculoDepreciaciones { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
           

        }
		
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=Localhost;Database=activos_fijos;User ID=root;Password=123456;", new MySqlServerVersion(new Version(8, 0, 28)));
            }
        }

    }
}
