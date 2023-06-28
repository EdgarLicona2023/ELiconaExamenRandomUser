using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace PL.Controllers
{
    public class CineController1 : Controller
    {
        public ActionResult GetFavorite()
        {
            ML.Cine cine = new ML.Cine();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                var responseTask = client.GetAsync("account/19727950/favorite/movies?language=en-US&page=1&session_id=3a999067e882cef6f35bc5764a19160a75ad7b4e&api_key=94d8e665d0cc2ac40847f696c21e8a01&sort_by=created_at.asc");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resulJson = JObject.Parse(readTask.Result.ToString());
                    readTask.Wait();
                    cine.Cines = new List<object>();
                    foreach (var resultitem in resulJson.results)
                    {
                        ML.Cine cine1 = new ML.Cine();
                        cine1.Descripcion = resultitem.overview;
                        cine1.NombreCine = resultitem.title;
                        cine1.Imagen = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2" + resultitem.poster_path;
                        cine.Cines.Add(cine1);

                    }
                }
            }
            return View(cine);
        }

        [HttpGet]
        public ActionResult GetPopular()
        {
            ML.Cine cine = new ML.Cine();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                var responseTask = client.GetAsync("movie/popular?api_key=94d8e665d0cc2ac40847f696c21e8a01");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resulJson = JObject.Parse(readTask.Result.ToString());
                    readTask.Wait();
                    cine.Cines = new List<object>();
                    foreach (var resultitem in resulJson.results)
                    {
                        ML.Cine cine1 = new ML.Cine();
                        cine1.id = resultitem.id;
                        cine1.Descripcion = resultitem.overview;
                        cine1.NombreCine = resultitem.title;
                        cine1.Imagen = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2" + resultitem.poster_path;
                        cine.Cines.Add(cine1);

                    }
                }
            }
            return View(cine);
        }

        [HttpPost]
        public ActionResult AddFavororite(ML.Cine idPelicula)

        {
            ML.Favorito favorito = new ML.Favorito();
            favorito.media_Id = idPelicula.id;
            favorito.media_type = "movie";
            favorito.favorite = true;

            ML.Cine resultPeliculas = new ML.Cine();
            resultPeliculas.Objects = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/account/19727950/");


                var postTask = client.PostAsJsonAsync<ML.Favorito>("favorite?session_id=6e874d27af017bb9713cfdbd001f72c24b2eb21f&api_key=94d8e665d0cc2ac40847f696c21e8a01", favorito);
                postTask.Wait();

                var resultAlumno = postTask.Result;
                if (resultAlumno.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha insertado la Pelicula";
                    return PartialView("Modal");
                }

                else
                {
                    ViewBag.Message = "No se inserto la Pelicula";
                    return PartialView("Modal");
                }
            }
            //return View();  
        }


        //[HttpPost]
        //public ActionResult RemoveFromFavorites(int movieId)
        //{
        //    // Aquí debes eliminar la película de la lista de favoritos en tu aplicación
        //    // Supongamos que tienes una lista de películas favoritas en la sesión del usuario

        //    List<Cines> favoriteMovies = Session["FavoriteMovies"] as List<Movie>;
        //    if (favoriteMovies != null)
        //    {
        //        Movie movieToRemove = favoriteMovies.FirstOrDefault(m => m.Id == movieId);
        //        if (movieToRemove != null)
        //        {
        //            favoriteMovies.Remove(movieToRemove);
        //            Session["FavoriteMovies"] = favoriteMovies;
        //        }
        //    }

        //    // Redirigir a la página de favoritos
        //    return RedirectToAction("Favorites");
        //}


    }
}
