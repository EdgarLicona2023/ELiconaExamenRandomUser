using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
		public static ML.Result Add(ML.Empleado empleado)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.ELiconaCrudAjaxEntities context = new DL.ELiconaCrudAjaxEntities())
				{
					var query = context.EmpleadoAdd(empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);
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

		public static ML.Result Update(ML.Empleado empleado)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.ELiconaCrudAjaxEntities context = new DL.ELiconaCrudAjaxEntities())
				{
					int RowAffeted = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);
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


		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.ELiconaCrudAjaxEntities context = new DL.ELiconaCrudAjaxEntities())
				{
					var empleados = context.EmpleadoGetAll().ToList();


					result.Objects = new List<object>();
					//var usuarios = 0;
					//if (empleados != null)

					//{
					//result.Objects = new List<object>();
					foreach (var mpleadoObj in empleados)
					{
						ML.Empleado empleado = new ML.Empleado();
						empleado.IdEmpleado = mpleadoObj.IdEmpleado;
						empleado.NumeroNomina = mpleadoObj.NumeroNomina;
						empleado.Nombre = mpleadoObj.Nombre;
						empleado.ApellidoPaterno = mpleadoObj.ApellidoPaterno;
						empleado.ApellidoMaterno = mpleadoObj.ApellidoMaterno;

						empleado.Estado = new ML.Estados();
						empleado.Estado.IdEstado = mpleadoObj.IdEstado.Value;
						empleado.Estado.Estado = mpleadoObj.Estado;


						result.Objects.Add(empleado);
					}
					result.Correct = true;
				}
				//else
				//{
				//	result.Correct = false;
				//	result.ErrorMessage = "Ocurrio un error";
				//}
				//}
			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = ex.Message;
				result.Ex = ex;
			}

			return result;

		}

		public static ML.Result GetById(int IdEmpleado)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.ELiconaCrudAjaxEntities context = new DL.ELiconaCrudAjaxEntities())
				{
					var mpleadoObj = context.EmpleadoGetById(IdEmpleado).Single();

					if (mpleadoObj != null)
					{

						ML.Empleado empleado = new ML.Empleado();
						empleado.IdEmpleado = mpleadoObj.IdEmpleado;
						empleado.NumeroNomina = mpleadoObj.NumeroNomina;
						empleado.Nombre = mpleadoObj.Nombre;
						empleado.ApellidoPaterno = mpleadoObj.ApellidoPaterno;
						empleado.ApellidoMaterno = mpleadoObj.ApellidoMaterno;

						empleado.Estado = new ML.Estados();
						empleado.Estado.IdEstado = mpleadoObj.IdEstado.Value;
						empleado.Estado.Estado = mpleadoObj.Estado;



						result.Object = empleado;


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

		public static ML.Result Delete(int IdEmpleado)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.ELiconaCrudAjaxEntities context = new DL.ELiconaCrudAjaxEntities())
				{
					var query = context.EmpleadoDelete(IdEmpleado);

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
