using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Zona
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())
                {
                    var query = context.Zonas.FromSql($"ZonaGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var resultado in query)
                        {
                            ML.Zona zona = new ML.Zona();

                            zona.IdZona = resultado.IdZona;
                            zona.NombreZona = resultado.NombreZona;


                            result.Objects.Add(zona);

                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
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
    }
}
