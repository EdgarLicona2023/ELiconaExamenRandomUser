using System.Net;
using Microsoft.AspNetCore.Mvc;


namespace SL.Controllers
{
    public class ZonaController : Controller
    {
        [HttpGet]
        [Route("Zona/GetAllZona")]
        public IActionResult GetAll()
        {
            ML.Zona producto = new ML.Zona();
            ML.Result result = BL.Zona.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
