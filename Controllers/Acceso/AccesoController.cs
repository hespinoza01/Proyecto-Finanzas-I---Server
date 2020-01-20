using System;
using System.Collections.Generic;
using System.Linq;
using Financecalc_Server.Models;
using Financecalc_Server.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Financecalc_Server.Controllers.Acceso
{
    [Route("api/acceso")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private FinancecalcDBContext context;

        public AccesoController(FinancecalcDBContext context) => this.context = context;

        [HttpGet("usuario")]
        public ActionResult GetUsuarios() => Ok(this.context.Usuario);

        [HttpPost("usuario/nuevo")]
        public ActionResult CreateUsuario([FromBody] Usuario item)
        {
            item.Password = PasswordCipher.Encrypt(item.Password);

            this.context.Usuario.Add(item);
            this.context.SaveChanges();
            return Ok();
        }

        [HttpGet("usuario/{id}")]
        public ActionResult GetUsuario(Guid id) => Ok(this.context.Usuario.Find(id));

        [HttpPost("usuario/{id}")]
        public ActionResult UpdateUsuario(Guid id, [FromBody] Usuario item)
        {
            if (!id.Equals(item.Id))
            {
                return this.BadRequest();
            }

            this.context.Usuario.Update(item);
            this.context.SaveChanges();
            return Ok();
        }

        [HttpPost("acceder")]
        public ActionResult GetAcceso()
        {
            string _usuario = HttpContext.Request.Form["FormUsuario"];
            string _contraseña = PasswordCipher.Encrypt(HttpContext.Request.Form["FormContraseña"]);

            List<Usuario> result = this.context.Usuario
                .Where(u => u.Username == _usuario)
                .Where(u => u.Password == _contraseña).ToList();

            if (result.Count > 0)
            {
                return this.Ok(result.First());
            }

            return this.BadRequest();
        }
    }
}