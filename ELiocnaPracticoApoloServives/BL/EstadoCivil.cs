using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class EstadoCivil
	{
		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					var areas = context.EstadoCivils.FromSqlRaw($"GetAllEstadoCivil").ToList();
					//var usuarios = 0;
					if (areas != null)
					{
						result.Objects = new List<object>();
						foreach (var paisObj in areas)
						{
							ML.EstadoCivilS ev = new ML.EstadoCivilS();
							ev.IdEstadoCivil = paisObj.IdEstadoCivil;
							ev.EstadoCivil = paisObj.EstadoCivill;


							result.Objects.Add(ev);
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
