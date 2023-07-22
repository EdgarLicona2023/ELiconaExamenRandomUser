using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
            public static ML.Result GetByIdPais(int IdPais)
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                    {
                        //var estadosByPais = context.Estados.FromSqlRaw($"EstadoGetByIdPais",IdPais).ToList();
                        var estadosByPais = context.Estados.FromSqlRaw($"EstadoGetByIdPais {IdPais}").ToList();

                    //var usuarios = 0;
                    if (estadosByPais != null)
                        {
                            result.Objects = new List<object>();
                            foreach (var estadoObj in estadosByPais)
                            {
                                ML.Estado estado = new ML.Estado();
                                estado.IdEstado = estadoObj.IdEstado;
                                estado.NombreEstado = estadoObj.NombreEstado;
                                estado.Pais = new ML.Pais();
                                estado.Pais.IdPais = estadoObj.IdPais.Value;


                                result.Objects.Add(estado);
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
