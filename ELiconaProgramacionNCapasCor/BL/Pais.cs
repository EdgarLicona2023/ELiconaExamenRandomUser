using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {

    public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    var paises = context.Pais.FromSql($"PaisGetAll").ToList();
                    //var usuarios = 0;
                    if (paises != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var paisObj in paises)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = paisObj.IdPais;
                            pais.NombrePais = paisObj.NombrePais;


                            result.Objects.Add(pais);
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
