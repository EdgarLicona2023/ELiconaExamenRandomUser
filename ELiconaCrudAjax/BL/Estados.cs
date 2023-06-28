using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Estados
	{
		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.ELiconaCrudAjaxEntities context = new DL.ELiconaCrudAjaxEntities())
				{
					var estados = context.EstadoGetAll().ToList();

					//var estados = (from a in context.EstadoGetAll select a).ToList();


					//var areas = 0;
					if (estados != null)
					{
						result.Objects = new List<object>();
						foreach (var paisObj in estados)
						{
							ML.Estados area = new ML.Estados();
							area.IdEstado = paisObj.IdEstado;
							area.Estado = paisObj.Estado;


							result.Objects.Add(area);
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
