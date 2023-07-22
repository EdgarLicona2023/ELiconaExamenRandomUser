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
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    var ColoniaByMunicipio = context.Colonia.FromSqlRaw($"ColoniaGetByIdMunicipio {IdMunicipio}").ToList();

                    //var usuarios = 0;
                    if (ColoniaByMunicipio != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var coloniaObj in ColoniaByMunicipio)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.IdColonia = coloniaObj.IdColonia;
                            colonia.NombreColonia = coloniaObj.NombreColonia;
                            colonia.CodigoPostal = coloniaObj.CodigoPostal;

                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio = coloniaObj.IdMunicipio.Value;


                            result.Objects.Add(colonia);
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
