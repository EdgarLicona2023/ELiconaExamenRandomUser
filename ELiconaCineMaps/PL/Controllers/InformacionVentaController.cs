using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class InformacionVentaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ML.Result result = BL.Cine.GetAllTotal();
            ML.Cine2 puntoVenta = new ML.Cine2();
            puntoVenta.Estadistica = new ML.Estadistica();


            if (result.Correct)
            {

                puntoVenta.Estadistica.TotalVentas = result.Objects;
                ML.Estadistica resultPorcentaje = BL.Cine.CalcularPorcentaje(puntoVenta);
                ML.Result result1 = BL.Cine.GetAll(puntoVenta);
                puntoVenta.PuntoVentas = result1.Objects;
                return View(puntoVenta);
            }
            else
            {
                return View(puntoVenta.Estadistica);
            }
        }
    }
}
