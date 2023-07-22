using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DL;
using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
	public class Departamento
	{
		public static ML.Result GetByIdArea(int IdArea)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					//var depa = context.Departamentos.FromSqlRaw($"DepartamentoGetAll",IdDepartamento).ToList();
					var depObj = context.Departamentos.FromSqlRaw($"DepartamentoGetBYIdArea {IdArea}").ToList();
					//var depa = context.Departamentos.FromSqlRaw($"DepartamentoGetByIdArea", IdDepartamento).ToList();


					//var usuarios = 0;
					if (depObj != null)
					{
						result.Objects = new List<object>();
						foreach (var obj in depObj)
						{
							ML.Departamento dep = new ML.Departamento();
							dep.IdDepartamento = obj.IdDepartamento;
							dep.Departamentos = obj.Departamentos;
							dep.Areas = new ML.Area();
							dep.Areas.IdArea = obj.IdArea.Value;


							result.Objects.Add(dep);

							//result.Object = dep;

						}
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


		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					var areas = context.Departamentos.FromSqlRaw($"GetAllDepartamento").ToList();
					//var usuarios = 0;
					if (areas != null)
					{
						result.Objects = new List<object>();
						foreach (var paisObj in areas)
						{
							ML.Departamento dep = new ML.Departamento();
							dep.IdDepartamento = paisObj.IdDepartamento;
							dep.Departamentos = paisObj.Departamentos;


							result.Objects.Add(dep);
						}
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
