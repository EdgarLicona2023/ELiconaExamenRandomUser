using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Pasajero
	{
		public static ML.Result Add(ML.Pasajero usuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliconaExamenAeroMexicoContext context = new DLL.EliconaExamenAeroMexicoContext())

				{
					var query = context.Database.ExecuteSqlRaw($"AddPasajero'{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.UserName}','{usuario.Correo}', @Password", new SqlParameter("@Password", usuario.Password));


					if (query >= 1)
					{
						result.Correct = true;

					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "OCURRIO UN ERROR";
					}
				}
			}

			catch (Exception e)
			{
				result.Correct = false;
				result.Ex = e;
				result.ErrorMessage = e.Message;

			}
			return result;
		}

		public static ML.Result GetByUserName(string Correo)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliconaExamenAeroMexicoContext context = new DLL.EliconaExamenAeroMexicoContext())
				{
					var usuarioObj = context.Pasajeros.FromSqlRaw($"UsuarioGetByUserNamePasa '{Correo}'").AsEnumerable().FirstOrDefault();

					if (usuarioObj != null)
					{

						ML.Pasajero usuario = new ML.Pasajero();
						usuario.IdPasajero = usuarioObj.IdPasajero;
						usuario.Nombre = usuarioObj.Nombre;
						usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
						usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
						usuario.UserName = usuarioObj.UserName;
						usuario.Correo = usuarioObj.Correo;
						usuario.Password = usuarioObj.Password;

						result.Object = usuario;


						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "ocurrio un error";
					}
				}
			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = ex.Message;
				result.Ex = ex;
			}

			return result;

		}
	}
}
