using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Json;

namespace PL.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public ActionResult Login()
		{
			ML.Login usuario = new ML.Login();
			return View(usuario);
		}

        [HttpPost]
        public ActionResult Login(ML.Login usuario)
        {

            ML.Result result1 = new ML.Result();    

            if (usuario.IdLogin == 0)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7098/api/");

                    var postTask = client.PostAsJsonAsync<ML.Login>("Login/Add", usuario);
                    postTask.Wait();

                    var resultProducto = postTask.Result;
                    if (resultProducto.IsSuccessStatusCode)

                    {
                        ViewBag.Message = "Se registro correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "No se ha registrado" + result1.ErrorMessage;
                    }
                }
            }
            else
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:7098/api/");


                    var postTask = client.PutAsJsonAsync<ML.Login>("Cine/Update/" + usuario.IdLogin, usuario);
                    postTask.Wait();

                    var resultUsario = postTask.Result;

                    if (resultUsario.IsSuccessStatusCode)
                    {
                        ViewBag.Message = " Se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "No se ha actualizado correctamente" + result1.ErrorMessage;
                    }
                }
            }
            return PartialView("Modal");
        }







        //[HttpPost]
        //public ActionResult Login(ML.Login usuario, string password)
        //{

        //	var bcrypt = new Rfc2898DeriveBytes(password, new byte[0], 10000, HashAlgorithmName.SHA256);

        //	var passwordHash = bcrypt.GetBytes(20);

        //	if (usuario.Nombre != null)
        //	{

        //		usuario.Password = passwordHash;
        //		ML.Result result = BL.Login.Add(usuario);
        //		//return View();
        //              return RedirectToAction("Index", "Home");
        //          }
        //	else
        //	{

        //		ML.Result result = BL.Login.GetByUserName(usuario.Correo);
        //		//usuario = (ML.Login)result.Object;
        //		if (result.Correct)
        //		{
        //			usuario = (ML.Login)result.Object;
        //			if (usuario.Password.SequenceEqual(passwordHash))
        //			{
        //				return RedirectToAction("Index", "Home");
        //			}
        //			else
        //			{
        //				ViewBag.Message = "Contraseña Invalida";
        //				return PartialView("ModalLogin");
        //			}
        //		}

        //		else
        //		{
        //			ViewBag.Message = "Usuario Invalido";
        //			return PartialView("ModalLogin");


        //		}
        //	}

        //}

    }
}
