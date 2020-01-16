using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financecalc_Server.Models
{
    public class Clasificacion
    {
        [Column("ClasificacionId")]
        public Guid Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public ICollection<Subclasificacion> Subclasifications { get; set; }
    }
}