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
    public class Libro
    {
        public static ML.Result GetAll(ML.Libro libro)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL.EliconaLibroContext context = new DL.EliconaLibroContext())
                {
                    //var libros = context.Libros.FromSqlRaw($"GetAllLibro '{libro.Nombre}' ,{libro.Autor.IdAutor}, {libro.Editorial.IdEditorial}, '{libro.FechaPublicacion}', '{libro.Costo}' ").ToList();
                    var libros = context.Libros.FromSqlRaw($"GetAllLibro").ToList();
                    result.Objects = new List<object>();


                    //if (productos != null)
                    //{
                    // result.Objects = new List<object>();
                    foreach (var librpObj in libros)
                    {
                        libro = new ML.Libro();

                        libro.IdLibro = librpObj.IdLibro;
                        libro.Nombre = librpObj.Nombre;
                        libro.FechaPublicacion = librpObj.FechaPublicacion;
                        libro.Costo = librpObj.Costo;
                        //libro.Portada = productoObj.Portada;
                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = librpObj.IdAutor.Value;
                        libro.Autor.NombreAutor = librpObj.NombreAutor;


                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = librpObj.IdEditorial.Value;
                        libro.Editorial.NombreEditorial = librpObj.NombreEditorial;

                        result.Objects.Add(libro);
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


        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaLibroContext context = new DL.EliconaLibroContext())
                {
                    // var productoObj = context.Productos.FromSqlRaw($"ProductoGetById{IdProducto}").Single();
                    // var obj = context.Materia.FromSqlRaw($"MateriaGetById {IdMateria}").AsEnumerable().FirstOrDefault();
                    var librpObj = context.Libros.FromSqlRaw($"GetByIdAutor {IdLibro}").AsEnumerable().FirstOrDefault();

                    if (librpObj != null)
                    {

                        ML.Libro libro = new ML.Libro();
                        libro.IdLibro = librpObj.IdLibro;
                        libro.Nombre = librpObj.Nombre;
                        libro.FechaPublicacion = librpObj.FechaPublicacion;
                        libro.Costo = librpObj.Costo;
                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = librpObj.IdAutor.Value;
                        libro.Autor.NombreAutor = librpObj.NombreAutor;


                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = librpObj.IdEditorial.Value;
                        libro.Editorial.NombreEditorial = librpObj.NombreEditorial;



                        result.Object = libro;


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


        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaLibroContext context = new DL.EliconaLibroContext())
                {
                    // var query = context.ProductoAdd(producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
                    var query = context.Database.ExecuteSqlRaw($"AddLibro '{libro.Nombre}', '{libro.FechaPublicacion}', {libro.Costo}, {libro.Autor.IdAutor}, {libro.Editorial.IdEditorial}");


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


        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaLibroContext context = new DL.EliconaLibroContext())
                {
                    // var query = context.Database.ExecuteSqlRaw($"ProductoUpdate", producto.IdProducto, producto.NombreProducto, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
                    int RowAffeted = context.Database.ExecuteSqlRaw($"UpdateLibro {libro.IdLibro},'{libro.Nombre}', '{libro.FechaPublicacion}', '{libro.Costo}', {libro.Autor.IdAutor}, {libro.Editorial.IdEditorial}");


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


        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaLibroContext context = new DL.EliconaLibroContext())
                {
                    //var query = context.Database.ExecuteSqlRaw("ProductoDelete", IdProducto);
                    var query = context.Database.ExecuteSqlRaw($"DeleteLibro {IdLibro}");


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