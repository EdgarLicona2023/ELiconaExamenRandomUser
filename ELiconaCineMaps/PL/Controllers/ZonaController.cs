using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ZonaController : Controller
    {  
          public ActionResult GetAll()
            {
            ML.Zona zona = new ML.Zona();
            zona.Zonas = new List<object>();
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    client.BaseAddress = new Uri("https://localhost:7127/api/"); 

                    var responseTask = client.GetAsync("Zona/GetAllZona");
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Zona resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Zona>(resultItem.ToString());
                            zona.Zonas.Add(resultItemList);
                        }
                    }
                }
                return View(zona);
            }
        
    }
}
