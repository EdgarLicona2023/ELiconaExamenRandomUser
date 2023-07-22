using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Puesto
	{

		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					var areas = context.Puestos.FromSqlRaw($"GetAllPuesto").ToList();
					//var usuarios = 0;
					if (areas != null)
					{
						result.Objects = new List<object>();
						foreach (var paisObj in areas)
						{
							ML.Puesto puesto = new ML.Puesto();
							puesto.IdPuesto = paisObj.IdPuesto;
							puesto.Puestos = paisObj.Puestos;


							result.Objects.Add(puesto);
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
