using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PL.Controllers
{
    public class CocktelController : Controller
    {
        //[HttpGet]
        //public ActionResult GeAll()
        //{
        //    return View();
        //}


        //[HttpGet]
        //public ActionResult GeAll(string nombre)
        //{
        //    //ML.Result resulta = new ML.Result();
        //    //resulta.Objects = new List<object>();

        //    ML.Drink resultdrink = new ML.Drink();
        //    resultdrink.Drinks = new List<object>();

        //    //string urlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"];

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/");
        //        //client.BaseAddress = new Uri(urlApi);

        //        var responseTask = client.GetAsync("json/v1/1/search.php?s=" + nombre);
        //        responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

        //        var result = responseTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsStringAsync();
        //            readTask.Wait();

        //            foreach (var resultItem in readTask.Result)
        //            {
        //                //ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
        //                //resulta.Objects.Add(resultItemList);


        //                ML.Drink resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Drink>(resultItem.ToString());
        //                resultdrink.Drinks.Add(resultItemList);
        //            }
        //        }
        //    }

        //    return View(resultdrink);
        //    //return View(resultAlumnos);

        //}



        [HttpGet]
        public ActionResult GeAll()
        {
            //ML.Result resulta = new ML.Result();
            //resulta.Objects = new List<object>();

            ML.Result resultdrink = new ML.Result();
            resultdrink.Objects = new List<object>();

            //string urlApi = System.Configuration.ConfigurationManager.AppSettings["WebApi"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/");
                //client.BaseAddress = new Uri(urlApi);

                var responseTask = client.GetAsync("v1/1/search.php?s=margarita");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<dynamic>();
                    readTask.Wait();

                    foreach (dynamic resultItem in readTask.Result.drinks)
                    {
                        //ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        //resulta.Objects.Add(resultItemList);


                        //ML.Drink resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Drink>(resultItem.ToString());
                        ML.Drink resultItemList = new ML.Drink();
                        resultItemList.strDrink = resultItem.strDrink;  
                        resultdrink.Objects.Add(resultItemList);
                    }
                }
            }

            return View(resultdrink);
            //return View(resultAlumnos);

        }
    }
}
