
using Microsoft.EntityFrameworkCore;

namespace activos.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Departamentos> departamentos { get; set; }

        public DbSet<Tipo> tipo { get; set; }

        public DbSet<Empleado> empleado { get; set; }
        public MyDbContext()
        {

        }

       
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
