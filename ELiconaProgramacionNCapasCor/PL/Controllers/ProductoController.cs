using Microsoft.AspNetCore.Mvc;
using ML;

namespace PL.Controllers
{
	public class ProductoController : Controller
	{
		//public ActionResult GetAll()
		//{

		//    ML.Producto producto = new ML.Producto();

		//    ML.Result result = BL.Producto.GetAll(producto);

		//    if (result.Correct)
		//    {
		//        producto.Productos = result.Objects;
		//        return View(producto);
		//    }
		//    else
		//    {
		//        ViewBag.Message = "Error de Consulta";
		//        return View();

		//    }
		//    return View();

		//}


		//public ActionResult Delete(int IdProducto)
		//{
		//    ML.Producto producto = new ML.Producto();
		//    producto.IdProducto = IdProducto;
		//    ML.Result result = BL.Producto.Delete(producto.IdProducto);
		//    if (result.Correct)
		//    {
		//        ViewBag.Message = "Producto Eliminado";
		//        return PartialView("Modal");

		//    }
		//    else
		//    {
		//        ViewBag.Message = "Producto No Eliminado";
		//        return PartialView("Modal");
		//    }

		//}
		


		// [HttpGet]
		//public ActionResult Form(int? IdProducto)

		//{
		//    ML.Result resultPro = BL.Proveedor.GetAll();
		//    ML.Result resultArea = BL.Area.GetAll();


		//    ML.Producto producto = new ML.Producto();

		//    producto.Proveedor = new ML.Proveedor();
		//    producto.Proveedor.Proveedors = resultPro.Objects;

		//    producto.Departamento = new ML.Departamento();
		//    producto.Departamento.Area = new ML.Area();


		//    if (resultPro.Correct)
		//    {
		//        producto.Proveedor.Proveedors = resultPro.Objects;
		//        producto.Departamento.Area.Areas = resultArea.Objects;
		//    }

		//    if (IdProducto == null)
		//    {
		//        //producto.Proveedor.Proveedors = resultPro.Objects;
		//        //producto.Departamento.Area.Areas = resultArea.Objects;
		//        return View(producto);
		//    }
		//    else
		//    {
		//        ML.Result result = BL.Producto.GetById(IdProducto.Value);


		//        if (result.Correct)
		//        {

		//            producto = (ML.Producto)result.Object;

		//            ML.Result resultDepartamento = BL.Departamento.GetByIdArea(producto.Departamento.Area.IdArea);

		//            producto.Departamento.Departamentos = resultDepartamento.Objects;

		//            producto.Proveedor.Proveedors = resultPro.Objects;
		//            producto.Departamento.Area.Areas = resultArea.Objects;
		//            return View(producto);
		//        }
		//        else
		//        {
		//            ViewBag.Message = "Ocurrio un error de consulta";
		//            return View();
		//        }
		//    }
		//}

		public JsonResult GetAllArea()
		{
			var result = BL.Area.GetAll();
			return Json(result.Objects);
		}

		public JsonResult DepartamentoGetByIdArea(int IdArea)
		{
			var result = BL.Departamento.GetByIdArea(IdArea);
			return Json(result.Objects);
		}


		//[HttpPost]
		//public ActionResult Form(ML.Producto producto)
		//{

		//    ML.Result result = new ML.Result();


		//    if (producto.IdProducto == 0)
		//    {
		//        result = BL.Producto.Add(producto);
		//    }
		//    else
		//    {
		//        result = BL.Producto.Update(producto);
		//    }

		//    if (result.Correct)
		//    {
		//        ViewBag.Message = "Producto Registrado";
		//        return PartialView("Modal");

		//    }
		//    else
		//    {
		//        ViewBag.Message = "Producto Actualizado";

		//    }
		//    return PartialView("Modal");

		//}



		//SERVICIOS WEB


		[HttpGet]
		public ActionResult GetAll()
		{
			//ML.Result resulta = new ML.Result();
			//resulta.Objects = new List<object>();

			ML.Producto resultAlumnos = new ML.Producto();
			resultAlumnos.Productos = new List<object>();

			//string urlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"];

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:7193/api/");
				//client.BaseAddress = new Uri(urlApi);

				var responseTask = client.GetAsync("Producto");
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


						ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
						resultAlumnos.Productos.Add(resultItemList);
					}
				}
			}
			ML.Producto producto = new ML.Producto();
			producto.Productos = resultAlumnos.Productos;
			return View(producto);
			//return View(resultAlumnos);

		}


		[HttpGet]
		public ActionResult Form(int? IdProducto)

		{
            ML.Producto producto = new ML.Producto();


            ML.Result resultPro = BL.Proveedor.GetAll();
			ML.Result resultArea = BL.Area.GetAll();

			ML.Result resultDepa = BL.Departamento.GetAll();


			

			producto.Proveedor = new ML.Proveedor();
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();



            //producto.Proveedor.Proveedors = resultPro.Objects;

			
			//producto.Departamento.Area = new ML.Area();


			if (resultPro.Correct)
			{
				producto.Proveedor.Proveedors = resultPro.Objects;
			}

            if (resultDepa.Correct)
            {
                
                producto.Departamento.Departamentos = resultDepa.Objects;
            }

            if (resultArea.Correct)
            {

                producto.Departamento.Area.Areas = resultArea.Objects;
            }

            if (IdProducto == null)
			{
				return View(producto);
			}
			else
			{
				ML.Result result = new ML.Result();
			
                using (var client = new HttpClient())
				{

					client.BaseAddress = new Uri("https://localhost:7193/api/");
					//client.BaseAddress = new Uri(configuration["WebApi"]);
					var responseTask = client.GetAsync("Producto/GetById/" + IdProducto);
					responseTask.Wait();
					var resultAPI = responseTask.Result;
					if (resultAPI.IsSuccessStatusCode)
					{
						var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
						readTask.Wait();
						ML.Producto resultItemList = new ML.Producto();
						resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        producto = ((ML.Producto)result.Object);
                        producto.Proveedor.Proveedors = resultPro.Objects;
                        producto.Departamento.Departamentos = resultDepa.Objects;
                        producto.Departamento.Area.Areas = resultArea.Objects;

                        return View(producto);

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Libro";
                    }
                }
                return View(producto);

			}
		}




		[HttpPost] 
		public ActionResult Form(ML.Producto producto)
		{

				ML.Result result = new ML.Result();
				//add o update
				if (producto.IdProducto == 0)
				{
					//add
					using (var client = new HttpClient())
					{
						client.BaseAddress = new Uri("https://localhost:7193/api/");

						//HTTP POST
						var postTask = client.PostAsJsonAsync<ML.Producto>("Producto/Add", producto);
						postTask.Wait();

						var resultAlumno = postTask.Result;
						if (resultAlumno.IsSuccessStatusCode)
						{
							ViewBag.Message = "Se ha insertado el Producto";
							return PartialView("Modal");
						}

						else
						{
							ViewBag.Message = "No se inserto el Producto";
							return PartialView("Modal");
						}
					}
                

            }
				else
				{
					using (var client = new HttpClient())
					{
						client.BaseAddress = new Uri("https://localhost:7193/api/");

						//HTTP POST
						var postTask = client.PutAsJsonAsync<ML.Producto>("Producto/Update/" + producto.IdProducto, producto);
						postTask.Wait();

						var resultAlumno = postTask.Result;
						if (resultAlumno.IsSuccessStatusCode)
						{
							ViewBag.Message = "Se ha actualizado el alumno"; 

                            return PartialView("Modal");
						}
					}
					//return PartialView("Modal");
				}
            return PartialView("Modal");

        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)
		{
			//ML.Result result1 = new ML.Result();
			//int id = IdProducto.IdProducto;

			ML.Producto producto = new ML.Producto();
			producto.IdProducto = IdProducto;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:7193/api/");
				//client.BaseAddress = new Uri("WebApi");


				//HTTP POST
				var postTask = client.DeleteAsync("Producto/Delete/" + IdProducto);
				postTask.Wait();

				var result = postTask.Result;
				if (result.IsSuccessStatusCode)
				{
					ViewBag.Message = "Producto Eliminado";
					return PartialView("Modal");
				}
				else
				{
					ViewBag.Message = "Producto No Eliminado";
					return PartialView("Modal");
				}

			}

		}

	}
}
