using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Data.SqlClient; //Importar libreria
using System.Data;
using ML;
using DL;
using System.Xml;
using System.Collections.ObjectModel;
using static System.Formats.Asn1.AsnWriter;

namespace BL
{
    public class Empleado
    {

        public static ML.Result GetAll(ML.Empleado emp)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL.EliconaTelcelContext context = new DL.EliconaTelcelContext())
                {
                    //var libros = context.Libros.FromSqlRaw($"GetAllLibro '{libro.Nombre}' ,{libro.Autor.IdAutor}, {libro.Editorial.IdEditorial}, '{libro.FechaPublicacion}', '{libro.Costo}' ").ToList();
                    var empleados = context.Empleados.FromSqlRaw($"GetAllEmpleados").ToList();
                    result.Objects = new List<object>();


                    //if (productos != null)
                    //{
                    // result.Objects = new List<object>();
                    foreach (var empObj in empleados)
                    {
                        emp = new ML.Empleado();

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
                    //}
                    //else
                    //{
                    //    result.Correct = false;
                    //    result.ErrorMessage = "Ocurrio un error";
                    //}
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


        public static ML.Result EmpleadoGetAllNombre(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EliconaTelcelContext context = new DL.EliconaTelcelContext())
                {


                    //var obj = context.Empleados.FromSqlRaw($"CoincidenciaNombre '{empleado.Nombre}'").AsEnumerable().FirstOrDefault();
                    var obj = context.Empleados.FromSqlRaw($"CoincidenciaNombre '{empleado.Nombre}'").ToList();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        foreach (var empObj in obj)
                        {
                            empleado = new ML.Empleado();
                            empleado.IdEmpleado = empObj.IdEmpleado;
                            empleado.Nombre = empObj.Nombre;

                            empleado.Puesto = new ML.Puesto();
                            empleado.Puesto.IdPuesto = empObj.IdPuesto.Value;
                            empleado.Puesto.DescripcionPuesto = empObj.DescripcionPuesto;


                            empleado.Departamento = new ML.Departamento();
                            empleado.Departamento.IdDepartamento = empObj.IdDepartamento.Value;
                            empleado.Departamento.DescripcionDepartamento = empObj.DescripcionDepartamento;



                            result.Objects.Add(empleado); //boxing

                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener LibroGetTitulo";
                    }

                    }

                //
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaTelcelContext context = new DL.EliconaTelcelContext())
                {
                    // var query = context.ProductoAdd(producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
                    var query = context.Database.ExecuteSqlRaw($"AddEmpleado '{empleado.Nombre}', {empleado.Puesto.IdPuesto}, {empleado.Departamento.IdDepartamento}");


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




        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaTelcelContext context = new DL.EliconaTelcelContext())
                {
                    //var query = context.Database.ExecuteSqlRaw("ProductoDelete", IdProducto);
                    var query = context.Database.ExecuteSqlRaw($"DeleteEmpleado {IdEmpleado}");


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
