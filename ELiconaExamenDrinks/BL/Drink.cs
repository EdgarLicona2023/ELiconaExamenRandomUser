using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Drink
    {
        public static ML.Result GetName(string nombre)
        {
            ML.Result resulteat = new ML.Result();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/");
                var respomseTask = client.GetAsync("json/v1/1/search.php?s=" + nombre);
                respomseTask.Wait();

                var results = respomseTask.Result;
                if (results.IsSuccessStatusCode)
                {
                    var ReadTask = results.Content.ReadAsStringAsync();
                    ML.Root arrayEat = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Root>(ReadTask.Result);

                    resulteat.Objects = new List<object>();
                    foreach (var recorrer in arrayEat.drinks)
                    {
                        ML.Result result1 = GetByID(recorrer.idDrink);

                        resulteat.Objects.Add(result1.Object);
                    }


                    resulteat.Correct = true;
                    return resulteat;

                }
                else
                {
                    Console.WriteLine("Error");
                    return null;
                }
            }
        }

        public static ML.Result GetByIngrediente(string Ingrediente)
        {
            ML.Result resulteats = new ML.Result();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.thecocktaildb.com/api/");
                var responseTask = client.GetAsync("json/v1/1/filter.php?i=" + Ingrediente);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var ReadResponse = result.Content.ReadAsStringAsync();
                    ML.Root arraymenu = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Root>(ReadResponse.Result); ;

                    resulteats.Objects = new List<object>();
                    foreach (var recorrer in arraymenu.drinks)
                    {
                        ML.Result result1 = GetByID(recorrer.idDrink);

                        resulteats.Objects.Add(result1.Object);
                    }


                    resulteats.Correct = true;
                    return resulteats;


                }
                else
                {
                    return null;
                }
            }
        }

        public static ML.Result GetByID(string Ingrediente)
        {
            ML.Result result1 = new ML.Result();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.thecocktaildb.com/api/");
                var responseTask = client.GetAsync("json/v1/1/lookup.php?i=" + Ingrediente);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var ReadResponse = result.Content.ReadAsStringAsync();
                    ML.Root arraymenu = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Root>(ReadResponse.Result); ;

                    ML.Drink nombre = arraymenu.drinks[0];
                    result1.Object = nombre;
                    result1.Correct = true;

                    return result1;
                }
                else
                {
                    return null;
                }

            }
        }

    }
}
