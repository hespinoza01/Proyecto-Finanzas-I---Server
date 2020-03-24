using Microsoft.AspNetCore.Mvc;
using Financecalc_Server.Models;

namespace Financecalc_Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class Home : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get([FromBody] Clasificacion res)
        {
            return res.Name;
        }
    }
}