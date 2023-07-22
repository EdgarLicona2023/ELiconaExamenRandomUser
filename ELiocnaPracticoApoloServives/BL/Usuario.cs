using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Data.SqlClient; //Importar libreria
using System.Data;
using ML;
using DL;
using System.Xml;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
	public class Usuario
	{
		public static ML.Result GetAll(ML.Usuario usuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					var usuarios = context.Usuarios.FromSqlRaw($"GetAllUsuario").ToList();
					result.Objects = new List<object>();


					//if (productos != null)
					//{
					// result.Objects = new List<object>();
					foreach (var usuarioObj in usuarios)
					{
						usuario = new ML.Usuario();

						usuario.IdUser = usuarioObj.IdUser;
						usuario.UserName = usuarioObj.UserName;
						usuario.Nombre = usuarioObj.Nombre;
						usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
						usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
						usuario.Email = usuarioObj.Email;
						usuario.Password = usuarioObj.Password;
						usuario.FechaNacimiento = usuarioObj.FechaNacimiento;//.ToString("dd-MM-yyyy");
						usuario.Telefono = usuarioObj.Telefono.Value;
						usuario.Imagen = usuarioObj.Imagen;

						usuario.Sexo = new ML.Sexo();
						usuario.Sexo.IdSexo = usuarioObj.IdSexo.Value; //Solo cuando estamos seguros que viene un valor
						usuario.Sexo.Sexos = usuarioObj.Sexos;

						usuario.EstadoCivil = new ML.EstadoCivilS();
						usuario.EstadoCivil.IdEstadoCivil = usuarioObj.IdEstadoCivil.Value; //Solo cuando estamos seguros que viene un valor
						usuario.EstadoCivil.EstadoCivil = usuarioObj.EstadoCivil;

						usuario.Puesto = new ML.Puesto();
						usuario.Puesto.IdPuesto = usuarioObj.IdPuesto.Value; //Solo cuando estamos seguros que viene un valor
						usuario.Puesto.Puestos = usuarioObj.Puestos;


						usuario.Departamento = new ML.Departamento();
						usuario.Departamento.IdDepartamento = usuarioObj.IdDepartamento.Value;
						usuario.Departamento.Departamentos = usuarioObj.Departamentos;

						usuario.Departamento.Areas = new ML.Area();
						usuario.Departamento.Areas.IdArea = usuarioObj.IdArea.Value;
						usuario.Departamento.Areas.Areas = usuarioObj.Areas;




						result.Objects.Add(usuario);
					}
					result.Correct = true;
					//}
					//else
					//{
					//    result.Correct = false;
					//    result.ErrorMessage = "Ocurrio un error";
					//}
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

		public static ML.Result GetById(int IdUsuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					// var productoObj = context.Productos.FromSqlRaw($"ProductoGetById{IdProducto}").Single();
					// var obj = context.Materia.FromSqlRaw($"MateriaGetById {IdMateria}").AsEnumerable().FirstOrDefault();
					var usuarioObj = context.Usuarios.FromSqlRaw($"GetByIdUsuario {IdUsuario}").AsEnumerable().FirstOrDefault();

					if (usuarioObj != null)
					{

						ML.Usuario usuario = new ML.Usuario();
						usuario.IdUser = usuarioObj.IdUser;
						usuario.UserName = usuarioObj.UserName;
						usuario.Nombre = usuarioObj.Nombre;
						usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
						usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
						usuario.Email = usuarioObj.Email;
						usuario.Password = usuarioObj.Password;
						usuario.FechaNacimiento = usuarioObj.FechaNacimiento;//.ToString("dd-MM-yyyy");
						usuario.Telefono = usuarioObj.Telefono.Value;
						usuario.Imagen = usuarioObj.Imagen;

						usuario.Sexo = new ML.Sexo();
						usuario.Sexo.IdSexo = usuarioObj.IdSexo.Value; //Solo cuando estamos seguros que viene un valor
						usuario.Sexo.Sexos = usuarioObj.Sexos;

						usuario.EstadoCivil = new ML.EstadoCivilS();
						usuario.EstadoCivil.IdEstadoCivil = usuarioObj.IdEstadoCivil.Value; //Solo cuando estamos seguros que viene un valor
						usuario.EstadoCivil.EstadoCivil = usuarioObj.EstadoCivil;

						usuario.Puesto = new ML.Puesto();
						usuario.Puesto.IdPuesto = usuarioObj.IdPuesto.Value; //Solo cuando estamos seguros que viene un valor
						usuario.Puesto.Puestos = usuarioObj.Puestos;


						usuario.Departamento = new ML.Departamento();
						usuario.Departamento.IdDepartamento = usuarioObj.IdDepartamento.Value;
						usuario.Departamento.Departamentos = usuarioObj.Departamentos;

						usuario.Departamento.Areas = new ML.Area();
						usuario.Departamento.Areas.IdArea = usuarioObj.IdArea.Value;
						usuario.Departamento.Areas.Areas = usuarioObj.Areas;



						result.Object = usuario;


						result.Correct = true;

					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "Ocurrio un error";
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

		public static ML.Result Add(ML.Usuario usuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					// var query = context.ProductoAdd(producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
					var query = context.Database.ExecuteSqlRaw($"AddUsuario '{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.Password}''{usuario.FechaNacimiento}', {usuario.Telefono}, {usuario.Imagen}, {usuario.Sexo.IdSexo},{usuario.EstadoCivil.IdEstadoCivil},{usuario.Puesto.IdPuesto}, {usuario.Departamento.IdDepartamento}");

					//var query = context.Database.ExecuteSqlRaw($"ProductoAdd", producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
					//var query = 0;
					if (query > 0)
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
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = ex.Message;
				result.Ex = ex;
			}

			return result;

		}

		public static ML.Result Update(ML.Usuario usuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					int RowAffeted = context.Database.ExecuteSqlRaw($"UpdateUsuario {usuario.IdUser},'{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.Password}''{usuario.FechaNacimiento}', {usuario.Telefono}, {usuario.Imagen}, {usuario.Sexo.IdSexo},{usuario.EstadoCivil.IdEstadoCivil},{usuario.Puesto.IdPuesto}, {usuario.Departamento.IdDepartamento}");


					// var RowAffeted = 0;
					if (RowAffeted > 0)
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
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = ex.Message;
				result.Ex = ex;
			}

			return result;

		}


		public static ML.Result Delete(int IdUsuario)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					//var query = context.Database.ExecuteSqlRaw("ProductoDelete", IdProducto);
					var query = context.Database.ExecuteSqlRaw($"DeleteUsuario {IdUsuario}");


					if (query > 0)
					{
						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "Ocurrio un error";
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
