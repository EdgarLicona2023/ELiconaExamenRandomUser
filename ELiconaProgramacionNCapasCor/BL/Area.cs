using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    var areas = context.Areas.FromSqlRaw($"AreaGetAll").ToList();
                    //var usuarios = 0;
                    if (areas != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var paisObj in areas)
                        {
                            ML.Area area = new ML.Area();
                            area.IdArea = paisObj.IdArea;
                            area.NombreArea = paisObj.NombreArea;


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
