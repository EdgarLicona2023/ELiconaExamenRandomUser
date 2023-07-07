using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmpleadoEliminarController : Controller
    {
        // GET: EmpleadoEliminar
       // [HttpGet]
        public ActionResult EmpleadoEliminar()
        {
            ML.Result result = BL.Empleado.GetAll();

            ML.Empleado empleado = new ML.Empleado();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                ViewBag.Message = "Error de Consulta";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.IdEmpleado = IdEmpleado;
            ML.Result result = BL.Empleado.Delete(empleado.IdEmpleado);
            if (result.Correct)
            {
                ViewBag.Message = "Empleado Eliminado";
                return PartialView("Modal");

            }
            else
            {
                ViewBag.Message = "Empleado No Eliminado";
                return PartialView("Modal");
            }

        }


    }
}