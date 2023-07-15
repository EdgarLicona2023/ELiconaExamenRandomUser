using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
