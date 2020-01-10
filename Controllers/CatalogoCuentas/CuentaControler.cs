using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Financecalc_Server.Controllers
{
    [Route("api/cuenta")]
    [ApiController]
    public class CuentaControler : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Connected to '/cuentas'";
        }
    }
}