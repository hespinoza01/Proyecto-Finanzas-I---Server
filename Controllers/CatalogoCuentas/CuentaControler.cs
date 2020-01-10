using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Financecalc_Server.Controllers.Catalogo
{
    [Route("api/catalogo/cuenta")]
    [ApiController]
    public class CuentaControler : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Connected to '/catalogo/cuenta'";
    }
}