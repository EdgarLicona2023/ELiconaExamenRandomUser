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
using DL_EF;
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
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())

                { 
                    var query = context.Database.ExecuteSqlRaw($"AddLogin '{usuario.NombreUsuario}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.UserName}','{usuario.Correo}', @Password",new SqlParameter("@Password",usuario.Password));


                    if (query >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR";
                    }
                    //result.Correct = true;
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
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())
                {
                    //var usuarioObj = context.UsuarioGetById(id_usuario).Single();
                    var usuarioObj = context.Logins.FromSqlRaw($"UsuarioGetByUserName '{Correo}'").AsEnumerable().FirstOrDefault();

                    if (usuarioObj != null)
                    {

                        ML.Login usuario = new ML.Login();
                        usuario.IdLogin = usuarioObj.IdLogin;
                        usuario.NombreUsuario = usuarioObj.NombreUsuario;
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

		public static ML.Result Update(ML.Login usuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.EliconaCineContext context = new DL.EliconaCineContext())
				{
					var queryEF = context.Database.ExecuteSqlRaw($"UsuarioUpdatePassword '{usuario.Correo}', @Password", new SqlParameter("@Password", usuario.Password));
					if (queryEF > 0)
					{
						result.Correct = true;
					}

				}




			}
			catch (Exception ex)
			{
				result.Correct = false;
			}






			return result;
		}
	}
}
