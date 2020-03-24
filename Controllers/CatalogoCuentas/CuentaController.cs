using System;
using System.Collections.Generic;
using Financecalc_Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financecalc_Server.Controllers.Catalogo
{
    [Route("api/catalogo/cuenta")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private FinancecalcDBContext context;

        public CuentaController(FinancecalcDBContext context) => this.context = context;

        [HttpGet]
        public ActionResult Get() => Ok(this.context.Cuenta);

        // Creating new cuenta using post method
        [HttpPost("nuevo")]
        public ActionResult New([FromBody] Cuenta item)
        {
            this.context.Cuenta.Add(item);
            this.context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetItem(Guid id) => this.Ok(this.context.Cuenta.Find(id));

        [HttpPost("{id}")]
        public ActionResult UpdateItem(Guid id, [FromBody] Cuenta item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            this.context.Cuenta.Update(item);
            this.context.SaveChanges();

            return Ok();
        }
    }
}