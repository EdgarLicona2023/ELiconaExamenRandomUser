using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Data.SqlClient; //Importar libreria
using System.Data;
using ML;
using DL;
using System.Xml;
using System.Collections.ObjectModel;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaTelcelContext context = new DL.EliconaTelcelContext())
                {
                    var depa = context.Departamentos.FromSqlRaw($"GetAllDepartamentos").ToList();
                    //var usuarios = 0;
                    if (depa != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var depObj in depa)
                        {
                            ML.Departamento dep = new ML.Departamento ();
                            dep.IdDepartamento = depObj.IdDepartamento;
                            dep.DescripcionDepartamento = depObj.DescripcionDepartamento;


                            result.Objects.Add(dep);
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
