using Microsoft.AspNetCore.Mvc;

namespace ELiconaExamenCocktail.Controllers
{
    public class CocktailController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
