using System.Collections.Generic;

namespace Financecalc_Server.Models
{
    public class Subclasificacion
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Clasificacion Clasification { get; set; }
        public ICollection<Cuenta> Cuentas { get; set; }
    }
}