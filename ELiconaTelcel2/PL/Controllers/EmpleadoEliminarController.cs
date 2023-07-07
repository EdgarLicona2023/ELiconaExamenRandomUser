using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoEliminarController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            //ML.Result resulta = new ML.Result();
            //resulta.Objects = new List<object>();

            ML.Empleado resultEmpleado = new ML.Empleado();
            resultEmpleado.Empleados = new List<object>();

            //string urlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7150/api/");
                //client.BaseAddress = new Uri(urlApi);

                var responseTask = client.GetAsync("Empleado");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        //ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        //resulta.Objects.Add(resultItemList);


                        ML.Empleado resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultItem.ToString());
                        resultEmpleado.Empleados.Add(resultItemList);
                    }
                }
            }
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empleados = resultEmpleado.Empleados;
            return View(empleado);
            //return View(resultAlumnos);

        }

        [HttpGet]
        public ActionResult Delete(int IdEmpleado)
        {
            //ML.Result result1 = new ML.Result();
            //int id = IdProducto.IdProducto;

            ML.Empleado empleado = new ML.Empleado();
            empleado.IdEmpleado = IdEmpleado;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7150/api/");
                //client.BaseAddress = new Uri("WebApi");


                //HTTP POST
                var postTask = client.DeleteAsync("Empleado/Delete/" + IdEmpleado);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
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


        //[HttpPost]

        [HttpPost]

        public ActionResult GetNombre(ML.Empleado empleado)
        {

            ML.Result result = BL.Empleado.EmpleadoGetAllNombre(empleado);
            empleado.Empleados = result.Objects;



            return View(empleado);
           

        }

        [HttpGet]
        public ActionResult GetNombre()
        {
           

            ML.Empleado resultEmpleado = new ML.Empleado();
            resultEmpleado.Empleados = new List<object>();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7150/api/");
                //client.BaseAddress = new Uri(urlApi);

                var responseTask = client.GetAsync("Empleado/GetNombre");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                      
                        ML.Empleado resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultItem.ToString());
                        resultEmpleado.Empleados.Add(resultItemList);
                    }
                }
            }
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empleados = resultEmpleado.Empleados;
            return View(empleado);

        }


    }
}
