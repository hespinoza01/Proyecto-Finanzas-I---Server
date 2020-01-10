using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Financecalc_Server.Models;
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
    }
}