using Microsoft.EntityFrameworkCore;

namespace Financecalc_Server.Models
{
    public class FinancecalcDBContext : DbContext
    {
        public FinancecalcDBContext(DbContextOptions<FinancecalcDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Subclasificacion> Subclasificacion { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
    }
}