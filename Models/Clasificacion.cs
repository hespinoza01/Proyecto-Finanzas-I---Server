using System.Collections.Generic;

namespace Financecalc_Server.Models
{
    public class Clasificacion
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subclasificacion> Subclasifications { get; set; }
    }
}