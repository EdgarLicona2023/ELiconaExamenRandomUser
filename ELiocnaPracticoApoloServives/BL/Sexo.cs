using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Sexo
	{
		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DLL.EliocnaPracticoApoloServivesContext context = new DLL.EliocnaPracticoApoloServivesContext())
				{
					var areas = context.Sexos.FromSqlRaw($"GetAllSexo").ToList();
					//var usuarios = 0;
					if (areas != null)
					{
						result.Objects = new List<object>();
						foreach (var paisObj in areas)
						{
							ML.Sexo sexo = new ML.Sexo();
							sexo.IdSexo = paisObj.IdSexo;
							sexo.Sexos = paisObj.Sexos;


							result.Objects.Add(sexo);
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
