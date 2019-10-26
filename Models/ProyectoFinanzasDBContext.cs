using Microsoft.EntityFrameworkCore;

namespace ProyectoFinanzas_Server.Models
{
    public class ProyectoFinanzasDBContext : DbContext
    {
        public ProyectoFinanzasDBContext(DbContextOptions<ProyectoFinanzasDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Subclasificacion> Subclasificacion { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
    }
}