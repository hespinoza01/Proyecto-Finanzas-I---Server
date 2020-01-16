using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Financecalc_Server.Models;
using Financecalc_Server.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Financecalc_Server.Controllers.Catalogo
{
    [Route("api/catalogo/clasificacion")]
    [ApiController]
    public class ClasificacionController : ControllerBase
    {
        private FinancecalcDBContext context;

        // controller constructor
        public ClasificacionController(FinancecalcDBContext context) => this.context = context;

        // getting all clasifications from database
        [HttpGet]
        public IActionResult Get() => Ok(this.context.Clasificacion);

        // Creating new clasification using post method
        [HttpPost("nuevo")]
        public ActionResult New([FromBody] Clasificacion item)
        {
            this.context.Clasificacion.Add(item);
            this.context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetItem(int id) => this.Ok(this.context.Clasificacion.Find(id));

        [HttpPost("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] Clasificacion item)
        {
            if (id != item.Id)
            {
                this.BadRequest();
            }

            this.context.Clasificacion.Update(item);
            this.context.SaveChanges();

            return Ok();
        }
    }
}