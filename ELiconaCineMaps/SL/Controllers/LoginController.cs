using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
	public class LoginController : Controller
	{
		[HttpPost]
		[Route("api/Login/Add")]
		public IActionResult Post([FromBody] ML.Login login)
		{
			ML.Result result = BL.Login.Add(login);

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
