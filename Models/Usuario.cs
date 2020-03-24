using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financecalc_Server.Models
{
    public class Usuario
    {
        [Column("UsuarioId")]
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Fullname { get; set; }

        public string UpdateDate { get; set; }

        public  int Enabled { get; set; }
    }
}