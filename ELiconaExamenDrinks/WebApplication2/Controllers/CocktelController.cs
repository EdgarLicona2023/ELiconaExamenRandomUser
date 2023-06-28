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
                        resultItemList.idDrink = resultItem.idDrink;  
                        resultItemList.strDrink = resultItem.strDrink;  
                        resultItemList.strCategory = resultItem.strCategory;  
                        resultItemList.strInstructions = resultItem.strInstructions;  
                        //resultItemList.strDrinkAlternate = resultItem.strDrinkAlternate;  
                        resultItemList.strIBA = resultItem.strIBA;  
                        resultItemList.strAlcoholic = resultItem.strAlcoholic;  
                        resultItemList.strGlass = resultItem.strGlass;  
                        resultItemList.strTags = resultItem.strTags;  
                        resultItemList.strDrinkThumb = resultItem.strDrinkThumb;  
                        resultItemList.strIngredient1 = resultItem.strIngredient1;  
                        resultItemList.strIngredient2 = resultItem.strIngredient2;  
                        resultItemList.strIngredient3 = resultItem.strIngredient3;  
                        resultItemList.strIngredient4 = resultItem.strIngredient4;  
                        resultItemList.strIngredient5 = resultItem.strIngredient5;  
                        resultItemList.strIngredient6 = resultItem.strIngredient6;  
                        resultItemList.strIngredient7 = resultItem.strIngredient7;  
                        resultItemList.strIngredient8 = resultItem.strIngredient8;  
                        resultItemList.strIngredient9 = resultItem.strIngredient9;  
                        resultItemList.strIngredient10 = resultItem.strIngredient10;  

                        resultItemList.strMeasure1 = resultItem.strMeasure1;  
                        resultItemList.strMeasure2 = resultItem.strMeasure2;  
                        resultItemList.strMeasure3 = resultItem.strMeasure3;  
                        resultItemList.strMeasure4 = resultItem.strMeasure4;  
                        resultItemList.strMeasure5 = resultItem.strMeasure5;  
                        resultItemList.strMeasure6 = resultItem.strMeasure6;  
                        resultItemList.strMeasure7 = resultItem.strMeasure7;  
                        resultItemList.strMeasure8 = resultItem.strMeasure8;  
                        resultItemList.strMeasure9 = resultItem.strMeasure9;  
                        resultItemList.strMeasure10 = resultItem.strMeasure10;  

                        resultdrink.Objects.Add(resultItemList);
                    }
                }
            }
            ML.Drink drink = new ML.Drink();

            drink.Drinks = resultdrink.Objects;

            return View(drink);

        }


        [HttpGet]
        public ActionResult GeAll(string nombre)
        {
         

            ML.Result resultdrink = new ML.Result();
            resultdrink.Objects = new List<object>();


            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/");

                //var responseTask = client.GetAsync("v1/1/search.php?s=margarita");

                //responseTask.Wait(); 

                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/");
                var responseTask = client.GetAsync("json/v1/1/search.php?s=" + nombre);
                responseTask.Wait();


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
                        resultItemList.idDrink = resultItem.idDrink;
                        resultItemList.strDrink = resultItem.strDrink;
                        resultItemList.strCategory = resultItem.strCategory;
                        resultItemList.strInstructions = resultItem.strInstructions;
                        //resultItemList.strDrinkAlternate = resultItem.strDrinkAlternate;  
                        resultItemList.strIBA = resultItem.strIBA;
                        resultItemList.strAlcoholic = resultItem.strAlcoholic;
                        resultItemList.strGlass = resultItem.strGlass;
                        resultItemList.strTags = resultItem.strTags;
                        resultItemList.strDrinkThumb = resultItem.strDrinkThumb;
                        resultItemList.strIngredient1 = resultItem.strIngredient1;
                        resultItemList.strIngredient2 = resultItem.strIngredient2;
                        resultItemList.strIngredient3 = resultItem.strIngredient3;
                        resultItemList.strIngredient4 = resultItem.strIngredient4;
                        resultItemList.strIngredient5 = resultItem.strIngredient5;
                        resultItemList.strIngredient6 = resultItem.strIngredient6;
                        resultItemList.strIngredient7 = resultItem.strIngredient7;
                        resultItemList.strIngredient8 = resultItem.strIngredient8;
                        resultItemList.strIngredient9 = resultItem.strIngredient9;
                        resultItemList.strIngredient10 = resultItem.strIngredient10;

                        resultItemList.strMeasure1 = resultItem.strMeasure1;
                        resultItemList.strMeasure2 = resultItem.strMeasure2;
                        resultItemList.strMeasure3 = resultItem.strMeasure3;
                        resultItemList.strMeasure4 = resultItem.strMeasure4;
                        resultItemList.strMeasure5 = resultItem.strMeasure5;
                        resultItemList.strMeasure6 = resultItem.strMeasure6;
                        resultItemList.strMeasure7 = resultItem.strMeasure7;
                        resultItemList.strMeasure8 = resultItem.strMeasure8;
                        resultItemList.strMeasure9 = resultItem.strMeasure9;
                        resultItemList.strMeasure10 = resultItem.strMeasure10;

                        resultdrink.Objects.Add(resultItemList);
                    }
                }
            }
            ML.Drink drink = new ML.Drink();

            drink.Drinks = resultdrink.Objects;

            return View(drink);

        }
    }
}
