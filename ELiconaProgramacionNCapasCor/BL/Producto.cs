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
    public class Producto
    {
        public static ML.Result GetAll( ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    var productos = context.Productos.FromSqlRaw($"ProductoGetAll").ToList();
					result.Objects = new List<object>();


					//if (productos != null)
                    //{
                       // result.Objects = new List<object>();
                        foreach (var productoObj in productos)
                        {
                            producto = new ML.Producto();

                            producto.IdProducto = productoObj.IdProducto;
                            producto.NombreProducto = productoObj.NombreProducto;
                            producto.PrecioUnitario = productoObj.PrecioUnitario;
                            producto.Stock = productoObj.Stock;
                            producto.Descripcion = productoObj.Descripcion;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = productoObj.IdProveedor.Value;
                            producto.Proveedor.NombreProveedor = productoObj.NombreProveedor;
                            producto.Proveedor.TelefonoProveedor = productoObj.TelefonoProveedor;


                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = productoObj.IdDepartamento.Value;
                            producto.Departamento.NombreDepartamento = productoObj.NombreDepartamento;
                        
                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = productoObj.IdArea.Value;
                            producto.Departamento.Area.NombreArea = productoObj.NombreArea;




                            result.Objects.Add(producto);
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

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                   // var productoObj = context.Productos.FromSqlRaw($"ProductoGetById{IdProducto}").Single();
                   // var obj = context.Materia.FromSqlRaw($"MateriaGetById {IdMateria}").AsEnumerable().FirstOrDefault();
                    var productoObj = context.Productos.FromSqlRaw($"ProductoGetById {IdProducto}").AsEnumerable().FirstOrDefault();

                    if (productoObj != null)
                    {

                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = productoObj.IdProducto;
                        producto.NombreProducto = productoObj.NombreProducto;
                        producto.PrecioUnitario = productoObj.PrecioUnitario;
                        producto.Stock = productoObj.Stock;
                        producto.Descripcion = productoObj.Descripcion;

                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = productoObj.IdProveedor.Value;
                        producto.Proveedor.NombreProveedor = productoObj.NombreProveedor;
                        producto.Proveedor.TelefonoProveedor = productoObj.TelefonoProveedor;


                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = productoObj.IdDepartamento.Value ;
                        producto.Departamento.NombreDepartamento = productoObj.NombreDepartamento;

                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.IdArea = productoObj.IdArea.Value;
                        producto.Departamento.Area.NombreArea = productoObj.NombreArea;



                        result.Object = producto;


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

        public static ML.Result Add(ML.Producto producto)
         {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    // var query = context.ProductoAdd(producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
                    var query = context.Database.ExecuteSqlRaw($"ProductoAdd '{producto.NombreProducto}', {producto.PrecioUnitario}, {producto.Stock}, '{producto.Descripcion}', {producto.Proveedor.IdProveedor}, {producto.Departamento.IdDepartamento}");

                    //var query = context.Database.ExecuteSqlRaw($"ProductoAdd", producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
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

        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    // var query = context.Database.ExecuteSqlRaw($"ProductoUpdate", producto.IdProducto, producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
                    int RowAffeted = context.Database.ExecuteSqlRaw($"ProductoUpdate {producto.IdProducto},'{producto.NombreProducto}', {producto.PrecioUnitario}, {producto.Stock}, '{producto.Descripcion}', {producto.Proveedor.IdProveedor}, {producto.Departamento.IdDepartamento}");


                   // var RowAffeted = 0;
                    if (RowAffeted > 0)
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


        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    //var query = context.Database.ExecuteSqlRaw("ProductoDelete", IdProducto);
                    var query = context.Database.ExecuteSqlRaw($"ProductoDelete {IdProducto}");


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