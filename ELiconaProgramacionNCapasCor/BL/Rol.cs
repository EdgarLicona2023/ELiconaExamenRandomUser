using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    
                    //var rols = context.RolGetAll().ToList();

                    var rols = context.Rols.FromSqlRaw($"RolGetAll").ToList();
                    //var usuarios = 0;
                    if (rols != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var rolObj in rols)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = rolObj.IdRol;
                            rol.Nombre = rolObj.Nombre;


                            result.Objects.Add(rol);
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
