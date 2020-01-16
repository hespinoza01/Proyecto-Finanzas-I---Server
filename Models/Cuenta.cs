using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financecalc_Server.Models
{
    public class Cuenta
    {
        [Column("CuentaId")]
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [ForeignKey("SubclasificacionId")]
        public Subclasificacion Subclasification { get; set; }

        public string Document { get; set; }
    }
}