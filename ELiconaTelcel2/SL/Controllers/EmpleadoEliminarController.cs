using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EmpleadoEliminarController : Controller
    {
        [HttpGet]
        [Route("api/Empleado")]
        public IActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Empleado.GetAll(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/Empleado/Delete/{IdEmpleado}")]

        public IActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }



        [HttpPost]
        [Route("api/Empleado/GetNombre")]
        public IActionResult GetNombre(string nombre)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Nombre = nombre;
            ML.Result result = BL.Empleado.EmpleadoGetAllNombre(empleado);

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
