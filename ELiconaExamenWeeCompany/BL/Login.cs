using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
//using System.Data.SqlClient; //Importar libreria
using Microsoft.Data.SqlClient; //Importar libreria
using System.Data;
using ML;
//using DL;
using System.Xml;
using System.Collections.ObjectModel;


namespace BL
{
	public class Login
	{
		public static ML.Result Add(ML.Login usuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.EliconaExamenWeeCompanyContext context = new DL.EliconaExamenWeeCompanyContext())

				{
					var query = context.Database.ExecuteSqlRaw($"AddLogin2 '{usuario.Nombre}','{usuario.Telefono}','{usuario.Correo}','{usuario.Empresa}'");


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
				using (DL.EliconaExamenWeeCompanyContext context = new DL.EliconaExamenWeeCompanyContext())
				{
					var usuarioObj = context.Logins.FromSqlRaw($"UsuarioGetByUserName '{Correo}'").AsEnumerable().FirstOrDefault();

					if (usuarioObj != null)
					{

						ML.Login usuario = new ML.Login();
						usuario.IdLogin = usuarioObj.IdLogin;
						usuario.Nombre = usuarioObj.Nombre;
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