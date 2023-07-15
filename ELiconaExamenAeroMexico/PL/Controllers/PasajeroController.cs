using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Web;

namespace PL.Controllers
{
    public class PasajeroController : Controller
    {
		[HttpGet]
		public ActionResult Login()
		{

			ML.Pasajero usuario = new ML.Pasajero();
			return View(usuario);
		}

		[HttpPost]
		public ActionResult Login(ML.Pasajero usuario, string password)
		{

			var bcrypt = new Rfc2898DeriveBytes(password, new byte[0], 10000, HashAlgorithmName.SHA256);

			var passwordHash = bcrypt.GetBytes(20);

			if (usuario.UserName != null)
			{

				usuario.Password = passwordHash;
				ML.Result result = BL.Pasajero.Add(usuario);
				return View();
			}
			else
			{

				ML.Result result = BL.Pasajero.GetByUserName(usuario.Correo);
				//usuario = (ML.Login)result.Object;
				if (result.Correct)
				{
					usuario = (ML.Pasajero)result.Object;
					if (usuario.Password.SequenceEqual(passwordHash))
					{
						ViewBag.Message = "Acceso Permitido";
						return RedirectToAction("Index", "Home");
					}
					else
					{
						ViewBag.Message = "Contraseña Invalida";
						return PartialView("ModalLogin");
					}
				}

				else
				{
					ViewBag.Message = "Usuario Invalido";
					return PartialView("ModalLogin");


				}
			}

		}
	}
}
