using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace PL.Controllers
{
    public class LoginController : Controller
    {
		private IHostingEnvironment environment;
		private IConfiguration configuration;
		public LoginController(IHostingEnvironment _environment, IConfiguration _configuration)
		{
			environment = _environment;
			configuration = _configuration;
		}
		[HttpGet]
		public ActionResult Login()
		{
			ML.Login usuario = new ML.Login();
			return View(usuario);
		}
		[HttpPost]
		public ActionResult Login(ML.Login usuario, string password)
		{

			var bcrypt = new Rfc2898DeriveBytes(password, new byte[0], 10000, HashAlgorithmName.SHA256);

			var passwordHash = bcrypt.GetBytes(20);

			if (usuario.UserName != null)
			{

				usuario.Password = passwordHash;
				ML.Result result = BL.Login.Add(usuario);
				return View();
			}
			else
			{

				ML.Result result = BL.Login.GetByUserName(usuario.Correo);
				//usuario = (ML.Login)result.Object;
				if (result.Correct)
				{
					usuario = (ML.Login)result.Object;
					if (usuario.Password.SequenceEqual(passwordHash))
					{
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
		[HttpGet]
		public ActionResult CambiarPassword()
		{
			return View();
		}

        [HttpPost]
        public ActionResult CambiarPassword(string correo)
        {



			//comprobar correo si existe en la DB 
			ML.Login usuario = new ML.Login();
			ML.Result result = BL.Login.GetByUserName(correo);
			usuario = (ML.Login)result.Object;



			if (result.Correct)
			{

			string emailOrigen = "ealiconagrande@gmail.com";

            MailMessage mailMessage = new MailMessage(emailOrigen, correo, "Recuperar Contraseña", "<p>Correo para recuperar contraseña</p>");
            mailMessage.IsBodyHtml = true;

            string contenidoHTML = System.IO.File.ReadAllText(@"C:\Users\digis\Documents\LiconaGrandeEdgarAlejandro\ELiconaCineMaps\PL\Views\Login\Email.html");
        
            mailMessage.Body = contenidoHTML;
			string url = "http://localhost:7047/Login/NewPassword/" + HttpUtility.UrlEncode(correo);
			//string url = configuration["NewPassword"] + HttpUtility.UrlEncode(correo);


				mailMessage.Body = mailMessage.Body.Replace("{Url}", url);
			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(emailOrigen, "bawqagkasvqwytrc");

            smtpClient.Send(mailMessage);
            smtpClient.Dispose();

            ViewBag.Modal = "show";
            ViewBag.Mensaje = "Se ha enviado un correo de confirmación a tu correo electronico";
            return View();
			}
			else
			{
				ViewBag.Mensaje = " No Se ha enviado un correo ";

				return View("Login");


			}

		}
        [HttpGet]
        public ActionResult NewPassword(string correo)
        {
            ML.Login usuario = new ML.Login();
            usuario.Correo = correo;
            return View(usuario);

            //return View();
        }
        [HttpPost]
        public ActionResult NewPassword(ML.Login usuario, string password)
        {
			// Crear una instancia del algoritmo de hash bcrypt
			var bcrypt = new Rfc2898DeriveBytes(password, new byte[0], 10000, HashAlgorithmName.SHA256);
			// Obtener el hash resultante para la contraseña ingresada 
			var passwordHash = bcrypt.GetBytes(20);

			// Insertar usuario en la base de datos
			usuario.Password = passwordHash;


			ML.Result result = BL.Login.Update(usuario);
			if (result.Correct)
			{
				ViewBag.Modal = "show";
				ViewBag.Message = "Se ha actualizado correctamente";
				return RedirectToAction("Login", "Login");
			}
			else
			{
				ViewBag.Modal = "show";
				ViewBag.Mensaje = "Error al actualizar la contraseña";
				return View();
			}
		}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //    [HttpGet]
        //    public ActionResult Login()
        //    {
        //        return View();
        //    }

        //      [HttpPost]
        //      public ActionResult Login(string Correo, string Password)
        //      {
        //          ML.Result result = BL.Login.GetByUserName(Correo);
        //          if (result.Correct)
        //          {
        //              ML.Login usuario = (ML.Login)result.Object;
        //              if (Password == usuario.Password)
        //              {
        //                  return RedirectToAction("Index", "Home");
        //              }
        //              else
        //              {
        //                  ViewBag.Message = "Contraseña Invalida";
        //                  return PartialView("ModalLogin");
        //              }
        //          }
        //          else
        //          {
        //              ViewBag.Message = "Usuario Invalido";
        //              return PartialView("ModalLogin");


        //          }


        //}
        //[HttpPost]
        //public ActionResult LoginAdd(ML.Login login)
        //{
        //	ML.Result result = new ML.Result();
        //	//puntoVenta.Zona = new Modelo.Zona();
        //	//Modelo.Result result1 = Negocio.Zona.GetAll();

        //	if (login.IdLogin == 0)
        //	{
        //		using (var client = new HttpClient())
        //		{
        //			client.BaseAddress = new Uri("https://localhost:7127/api/");

        //			var postTask = client.PostAsJsonAsync<ML.Login>("Login/Add", login);
        //			postTask.Wait();

        //			var resultProducto = postTask.Result;
        //			if (resultProducto.IsSuccessStatusCode)

        //			{
        //				ViewBag.Message = "Se registro correctamente";
        //			}
        //			else
        //			{
        //				ViewBag.Message = "No se ha registrado" + result.ErrorMessage;
        //			}
        //		}
        //	}
        //	//else
        //	//{

        //	//	using (var client = new HttpClient())
        //	//	{

        //	//		client.BaseAddress = new Uri("https://localhost:7127/api/");


        //	//		var postTask = client.PutAsJsonAsync<ML.Cine2>("Cine/Update/" + login.IdCine, login);
        //	//		postTask.Wait();

        //	//		var resultUsario = postTask.Result;

        //	//		if (resultUsario.IsSuccessStatusCode)
        //	//		{
        //	//			ViewBag.Message = " Se ha actualizado correctamente";
        //	//		}
        //	//		else
        //	//		{
        //	//			ViewBag.Message = "No se ha actualizado correctamente" + result.ErrorMessage;
        //	//		}
        //	//	}
        //	//}
        //	return PartialView("ModalLogin");
        //}
    }
		}
