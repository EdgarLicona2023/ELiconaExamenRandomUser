using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
	public class PasajeroController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
