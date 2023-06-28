using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class LoginController : Controller
    {
         [HttpPost]
        [Route("api/Login/Add")]
        public IActionResult Post([FromBody] ML.Login usuario)
        {
            ML.Result result = BL.Login.Add(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
