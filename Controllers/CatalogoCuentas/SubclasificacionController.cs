using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Financecalc_Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financecalc_Server.Controllers.Catalogo
{
    [Route("api/catalogo/subclasificacion")]
    [ApiController]
    public class SubclasificacionController : ControllerBase
    {
        private FinancecalcDBContext context;

        public SubclasificacionController(FinancecalcDBContext context) => this.context = context;

        // Getting all subclasifications
        [HttpGet]
        public IActionResult Get() => Ok(this.context.Subclasificacion);

        // Creating new subclasification using post method
        [HttpPost("nuevo")]
        public ActionResult New([FromBody] Subclasificacion item)
        {
            this.context.Subclasificacion.Add(item);
            this.context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetItem(int id) => this.Ok(this.context.Subclasificacion.Find(id));

        [HttpPost("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] Subclasificacion item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            this.context.Subclasificacion.Update(item);
            this.context.SaveChanges();

            return Ok();
        }
    }
}