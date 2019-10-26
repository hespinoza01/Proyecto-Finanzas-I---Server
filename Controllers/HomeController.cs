using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinanzas_Server.Controllers
{
    [Route("")]
    [ApiController]
    public class Home : ControllerBase
    {
     
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Connected";
        }
    }
}