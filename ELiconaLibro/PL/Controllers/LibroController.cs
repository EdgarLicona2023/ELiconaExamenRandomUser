using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        


        [HttpGet]
        public ActionResult GetAll()
        {
            //ML.Result resulta = new ML.Result();
            //resulta.Objects = new List<object>();

            ML.Libro resultLibro = new ML.Libro();
            resultLibro.Libros = new List<object>();

            //string urlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7096/api/");
                //client.BaseAddress = new Uri(urlApi);

                var responseTask = client.GetAsync("Libro");
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


                        ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                        resultLibro.Libros.Add(resultItemList);
                    }
                }
            }
            ML.Libro libro = new ML.Libro();
            libro.Libros = resultLibro.Libros;
            return View(libro);
            //return View(resultAlumnos);

        }


        [HttpGet]
        public ActionResult Form(int? IdLibro)
        { 
            
            ML.Libro libros = new ML.Libro();

            ML.Result resultAutor = BL.Autor.GetAll();
            ML.Result resultEditorial = BL.Editorial.GetAll();

           

            libros.Autor = new ML.Autor();
            libros.Editorial = new ML.Editorial();


            if (resultEditorial.Correct)
            {
                // libros.Autor.Autors = resultAutor.Objects;
                libros.Editorial.Editorials = resultEditorial.Objects;
            }

            if (resultAutor.Correct)
            {
                libros.Autor.Autors = resultAutor.Objects;
                //libros.Editorial.Editorials = resultEditorial.Objects;
            }
           


            if (IdLibro == null)
            {
                return View(libros);
            }
            else
            {
                //ML.Result result = BL.Producto.GetById(IdProducto.Value);
                ML.Result result = new ML.Result();
                
                    using (var client = new HttpClient())
                    {
                        //client.BaseAddress = new Uri(_configuration["WebApi"]);
                        client.BaseAddress = new Uri("https://localhost:7096/api/");
                        var responseTask = client.GetAsync("Libro/GetById/" + IdLibro);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Libro resultItemList = new ML.Libro();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                        libros = ((ML.Libro)result.Object);
                        libros.Autor.Autors = resultAutor.Objects;
                        libros.Editorial.Editorials = resultEditorial.Objects;
                        return View(libros);

                    }
                    else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Libro";
                        }
                    }

             
                return View();
            }
        }

     

        [HttpPost] //metodo con servicios web
        public ActionResult Form(ML.Libro libro)
        {

            ML.Result result = new ML.Result();
            //add o update
            if (libro.IdLibro == 0)
            {
                //add
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7096/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Libro>("Libro/Add", libro);
                    postTask.Wait();

                    var resultAlumno = postTask.Result;
                    if (resultAlumno.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha insertado el libro";
                        return PartialView("Modal");
                    }

                    else
                    {
                        ViewBag.Message = "No se inserto el libro";
                        return PartialView("Modal");
                    }
                }

            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7096/api/");

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ML.Libro>("Libro/Update/" + libro.IdLibro, libro);
                    postTask.Wait();

                    var resultAlumno = postTask.Result;
                    if (resultAlumno.IsSuccessStatusCode)
                    {
                        ViewBag.Menssaje = "Se ha actualizado el libro";
                        return PartialView("Modal");
                    }

                    else
                    {
                        ViewBag.Message = "No se actualizo el libro";
                        return PartialView("Modal");
                    }
                }
               
            }
        }



        [HttpGet]
        public ActionResult Delete(int IdLibro)
        {
            //ML.Result result1 = new ML.Result();
            //int id = IdProducto.IdProducto;

            ML.Libro libro = new ML.Libro();
            libro.IdLibro = IdLibro;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7096/api/");
                //client.BaseAddress = new Uri("WebApi");


                //HTTP POST
                var postTask = client.DeleteAsync("Libro/Delete/" + IdLibro);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Libro Eliminado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Libro No Eliminado";
                    return PartialView("Modal");
                }

            }

        }

    }
}
