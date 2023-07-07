using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Globalization;
using System.Data.SqlClient; //Importar libreria
using System.Data;
using ML;
using DL;
using System.Xml;
using System.Collections.ObjectModel;


namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ELiconaTelcelEntities context = new DL.ELiconaTelcelEntities())
                {
                    var query = context.AddEmpleado(empleado.Nombre, empleado.Puesto.IdPuesto, empleado.Departamento.IdDepartamento);
                    //var query = 0;
                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR";
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



        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ELiconaTelcelEntities context = new DL.ELiconaTelcelEntities())
                {
                    var emple = context.GetAllEmpleados().ToList();
                    result.Objects = new List<object>();

                    //var usuarios = 0;
                    if (emple != null)
                    {
                       //result.Objects = new List<object>();
                        foreach (var empObj in emple)
                        {

                            ML.Empleado emp = new ML.Empleado();
                            emp.IdEmpleado = empObj.IdEmpleado;
                            emp.Nombre = empObj.Nombre;

                            emp.Puesto = new ML.Puesto();
                            emp.Puesto.IdPuesto = empObj.IdPuesto.Value;
                            emp.Puesto.DescripcionPuesto = empObj.DescripcionPuesto;


                            emp.Departamento = new ML.Departamento();
                            emp.Departamento.IdDepartamento = empObj.IdDepartamento.Value;
                            emp.Departamento.DescripcionDepartamento = empObj.DescripcionDepartamento;


                            result.Objects.Add(emp);
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



        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ELiconaTelcelEntities context = new DL.ELiconaTelcelEntities())
                {
                    var query = context.DeleteEmpleado(IdEmpleado);

                    if (query > 0)
                    {
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
