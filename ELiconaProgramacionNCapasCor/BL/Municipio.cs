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
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    //var municipioByEstado = context.Municipios.FromSqlRaw($"MunicipioGetByIdEstado", IdEstado).ToList();
                    var municipioByEstado = context.Municipios.FromSqlRaw($"MunicipioGetByIdEstado {IdEstado}").ToList();

                    //var usuarios = 0;
                    if (municipioByEstado != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var municipioObj in municipioByEstado)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = municipioObj.IdMunicipio;
                            municipio.NombreMunicipio = municipioObj.NombreMunicipio;

                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = municipioObj.IdEstado.Value;


                            result.Objects.Add(municipio);
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
