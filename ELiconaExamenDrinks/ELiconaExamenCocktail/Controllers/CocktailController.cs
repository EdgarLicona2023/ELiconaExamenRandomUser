using Microsoft.AspNetCore.Mvc;

namespace ELiconaExamenCocktail.Controllers
{
    public class CocktailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
