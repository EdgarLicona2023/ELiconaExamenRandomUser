//using AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();

            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
                //usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Error de Consulta";
            }
            return View();
        }

        public ActionResult Delete(int Id_Usuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Id_Usuario = Id_Usuario;
            ML.Result result = BL.Usuario.Delete(usuario.Id_Usuario);
            if (result.Correct)
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

        [HttpGet]
        public ActionResult Form(int? Id_Usuario)

        {
            ML.Result resultRol = BL.Rol.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            if (resultRol.Correct)
            {
                usuario.Rol.Rols = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            }

            if (Id_Usuario == null)
            {

                return View(usuario);

                //usuario.Rol.Rols = resultRol.Objects;
                //usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                //return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetById(Id_Usuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;

                    ML.Result resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;

                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;

                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

                    usuario.Rol.Rols = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error de consulta";
                    return View();
                }
            }
        }

        public JsonResult GetAllPais()
        {
            var result = BL.Pais.GetAll();
            return Json(result.Objects);
        }

        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects);
        }
        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects);
        }

        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects);
        }



        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();



            if (usuario.Id_Usuario == 0)
            {
                result = BL.Usuario.Add(usuario);
            }
            else
            {
                result = BL.Usuario.Update(usuario);
            }

            if (result.Correct)
            {
                ViewBag.Message = "Usuario Registrado";
                return PartialView("Modal");

            }
            else
            {
                ViewBag.Message = "Usuario Actualizado";

            }
            return PartialView("Modal");

        }


		[HttpGet]
		public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(string Email, string Password)
		{
            ML.Result result = BL.Usuario.GetByUserName(Email);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (Password == usuario.Password)
                {
                    return RedirectToAction("Index", "Home");//como dovelver a una vista dif en mvc .net core
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
