using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financecalc_Server.Models
{
    public class Subclasificacion
    {
        [Column("SubclasificacionId")]
        public Guid Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        [ForeignKey("ClasificacionId")]
        public Clasificacion Clasification { get; set; }

        public ICollection<Cuenta> Cuentas { get; set; }
    }
}