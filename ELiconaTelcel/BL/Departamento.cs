using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                using (DL.ELiconaTelcelEntities context = new DL.ELiconaTelcelEntities())
                {
                    var deps = context.GetAllDepartamentos().ToList();
                    result.Objects = new List<object>();

                    //var usuarios = 0;
                    if (deps != null)
                    {
                        //result.Objects = new List<object>();
                        foreach (var depObj in deps)
                        {
                            ML.Departamento dep = new ML.Departamento();
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
