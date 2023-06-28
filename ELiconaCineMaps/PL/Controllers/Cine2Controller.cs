using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;


namespace PL.Controllers
{
    public class Cine2Controller : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Cine2 cine2 = new ML.Cine2();
            cine2.Zona = new ML.Zona();
            ML.Result result1 = BL.Zona.GetAll();

            cine2.Cines = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7127/api/");


                var responseTask = client.GetAsync("Cine");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Cine2 resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cine2>(resultItem.ToString());
                        cine2.Cines.Add(resultItemList);
                    }
                }
            }
            return View(cine2);
        }


        [HttpPost]
        public ActionResult Form(ML.Cine2 cine)
        {
            ML.Result result = new ML.Result();
            //puntoVenta.Zona = new Modelo.Zona();
            //Modelo.Result result1 = Negocio.Zona.GetAll();

            if (cine.IdCine == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7127/api/");

                    var postTask = client.PostAsJsonAsync<ML.Cine2>("Cine/Add", cine);
                    postTask.Wait();

                    var resultProducto = postTask.Result;
                    if (resultProducto.IsSuccessStatusCode)

                    {
                        ViewBag.Message = "Se registro correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "No se ha registrado" + result.ErrorMessage;
                    }
                }
            }
            else
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:7127/api/");


                    var postTask = client.PutAsJsonAsync<ML.Cine2>("Cine/Update/" + cine.IdCine, cine);
                    postTask.Wait();

                    var resultUsario = postTask.Result;

                    if (resultUsario.IsSuccessStatusCode)
                    {
                        ViewBag.Message = " Se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "No se ha actualizado correctamente" + result.ErrorMessage;
                    }
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdCine)
        {


            ML.Result cine = new ML.Result();


            //ML.Cine2 cine = new ML.Cine2();
            //cine.IdCine = IdCine;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7127/api/");

                var postTask = client.DeleteAsync("Cine/Delete/" + IdCine);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Cine Eliminado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Cine No Eliminado";
                    return PartialView("Modal");
                }
            }

            //return PartialView("Modal");


        }



        [HttpGet]
        public ActionResult Form(int? IdCine)
        {
            ML.Cine2 cine = new ML.Cine2();

            ML.Result result1 = BL.Zona.GetAll();
            cine.Zona = new ML.Zona();

            if (IdCine == null) //Add
            {
                cine.Zona.Zonas = result1.Objects;
                return View(cine);
            }
            else
            {
                ML.Result result = new ML.Result();


                using (var client = new HttpClient())
                    try
                    {
                        client.BaseAddress = new Uri("https://localhost:7127/api/");
                        var responseTask = client.GetAsync("Cine/GetById/" + IdCine);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            ML.Cine2 resultItemList = new ML.Cine2();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cine2>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;


                            cine = ((ML.Cine2)result.Object);
                            cine.Zona.Zonas = result1.Objects;



                            return View(cine);
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla";
                        }
                    }

                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                    }

                return View();



            }
        }


    }
}
