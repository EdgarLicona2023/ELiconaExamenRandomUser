using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    var prov = context.Proveedors.FromSqlRaw($"ProveedorGetAll").ToList();
                    //var usuarios = 0;
                    if (prov != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var proObj in prov)
                        {
                            ML.Proveedor pro = new ML.Proveedor();
                            pro.IdProveedor = proObj.IdProveedor;
                            pro.NombreProveedor = proObj.NombreProveedor;


                            result.Objects.Add(pro);
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
