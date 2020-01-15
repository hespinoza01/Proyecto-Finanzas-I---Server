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

        public ClasificacionController(FinancecalcDBContext context) => this.context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Clasificacion>> Get() => this.context.Clasificacion.ToArray();

        [HttpPost("nuevo")]
        public ActionResult<_Response> New([FromBody] Clasificacion item)
        {
            this.context.Clasificacion.Add(item);
            this.context.SaveChanges();
            return ResponseType.Success();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Subclasificacion>> GetItem(int id) => this.context.Clasificacion.Find(id).Subclasifications;

        [HttpPost("{id}")]
        public ActionResult<_Response> UpdateItem(int id, [FromBody] Clasificacion item)
        {
            if (id != item.Id)
            {
                return ResponseType.Error(
                    ResMsg: "Error al guardar. Los identificadores no coinciden."
                    );
            }

            this.context.Clasificacion.Update(item);
            this.context.SaveChanges();

            return ResponseType.Success();
        }
    }
}