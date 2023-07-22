using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult GetAllUsuario()
        {

            ML.Usuario resultUsuarios = new ML.Usuario();
            resultUsuarios.Usuarios = new List<object>();



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/");

                var responseTask = client.GetAsync("Usuario");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        //ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        //resulta.Objects.Add(resultItemList);


                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        resultUsuarios.Usuarios.Add(resultItemList);
                    }
                }
            }
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = resultUsuarios.Usuarios;
            return View(usuario);
            //return View(resultAlumnos);
        }



        [HttpGet]
        public ActionResult Form(int? IdUsuario)

        {
            ML.Usuario usuario = new ML.Usuario();

            ML.Result resultPu = BL.Puesto.GetAll();

            ML.Result resultSx = BL.Sexo.GetAll();

            ML.Result resultEV = BL.EstadoCivil.GetAll();

            ML.Result resultArea = BL.Area.GetAll();

            ML.Result resultDepa = BL.Departamento.GetAll();



            usuario.Puesto = new ML.Puesto();

            usuario.Sexo = new ML.Sexo(); 

            usuario.EstadoCivil = new ML.EstadoCivilS();

            usuario.Departamento = new ML.Departamento();

            usuario.Departamento.Areas = new ML.Area();



            //producto.Proveedor.Proveedors = resultPro.Objects;


            //producto.Departamento.Area = new ML.Area();

            if (resultSx.Correct)
            {
                usuario.Sexo.Sexoss = resultSx.Objects;
            }

            if (resultPu.Correct)
            {
                usuario.Puesto.Puestoss = resultPu.Objects;
            }

            if (resultEV.Correct)
            {
                usuario.EstadoCivil.EstadoCivill = resultEV.Objects;
            }

            if (resultDepa.Correct)
            {

                usuario.Departamento.Departamentoss = resultDepa.Objects;
            }

            if (resultArea.Correct)
            {

                usuario.Departamento.Areas.Areass = resultArea.Objects;
            }

            if (IdUsuario == null)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = new ML.Result();

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:7160/api/");
                    //client.BaseAddress = new Uri(configuration["WebApi"]);
                    var responseTask = client.GetAsync("Usuario/GetById/" + IdUsuario);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Usuario resultItemList = new ML.Usuario();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        usuario = ((ML.Usuario)result.Object);

                        usuario.Sexo.Sexoss = resultSx.Objects;
                        usuario.EstadoCivil.EstadoCivill = resultEV.Objects;
                        usuario.Puesto.Puestoss = resultPu.Objects;
                        usuario.Departamento.Departamentoss = resultDepa.Objects;
                        usuario.Departamento.Areas.Areass = resultArea.Objects;

                        return View(usuario);

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Libro";
                    }
                }
                return View(usuario);

            }
        }

        [HttpPost]
        public IActionResult Form(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            //add o update
            if (usuario.IdUser == 0)
            {
                //add
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7160/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Add", usuario);
                    postTask.Wait();

                    var resultAlumno = postTask.Result;
                    if (resultAlumno.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha insertado el Usuario";
                        return PartialView("Modal");
                    }

                    else
                    {
                        ViewBag.Message = "No se inserto el Usuario";
                        return PartialView("Modal");
                    }
                }


            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7160/api/");

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ML.Usuario>("Usuario/Update/" + usuario.IdUser, usuario);
                    postTask.Wait();

                    var resultAlumno = postTask.Result;
                    if (resultAlumno.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha actualizado el usuario";

                        return PartialView("Modal");
                    }
                }
                //return PartialView("Modal");
            }
            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
 

            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUser = IdUsuario;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7160/api/");
               
                var postTask = client.DeleteAsync("Usuario/Delete/" + IdUsuario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Usuario Eliminado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Usuario No Eliminado";
                    return PartialView("Modal");
                }

            }

        }


    }
}
