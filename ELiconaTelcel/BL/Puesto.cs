using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Puesto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ELiconaTelcelEntities context = new DL.ELiconaTelcelEntities())
                {
                    var pues = context.GetAllPuestos().ToList();
                    result.Objects = new List<object>();

                    //var usuarios = 0;
                    if (pues != null)
                    {
                        //result.Objects = new List<object>();
                        foreach (var puesObj in pues)
                        {
                            ML.Puesto pue = new ML.Puesto();
                            pue.IdPuesto = puesObj.IdPuesto;
                            pue.DescripcionPuesto = puesObj.DescripcionPuesto;


                            result.Objects.Add(pue);
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
