using Microsoft.EntityFrameworkCore;
using System.Globalization;
//using System.Data.SqlClient; //Importar libreria
using Microsoft.Data.SqlClient; //Importar libreria
using System.Data;
using ML;
using DL_EF;
using System.Xml;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BL
{
    public class Cine
    {

        public static ML.Result GetAll(ML.Cine2 puntoVenta)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())
                {
                    var cines = context.Cines.FromSqlRaw($"CineGetAll").ToList();
                    result.Objects = new List<object>();


                    //if (productos != null)
                    //{
                    // result.Objects = new List<object>();
                    foreach (var cineObj in cines)
                    {
                        puntoVenta = new ML.Cine2();

                        puntoVenta.IdCine = cineObj.IdCine;
                        puntoVenta.NombreCine = cineObj.NombreCine;
                        puntoVenta.Direccion = cineObj.Direccion;
                        puntoVenta.Ventas = cineObj.Ventas;

                        puntoVenta.Zona = new ML.Zona();
                        puntoVenta.Zona.IdZona = cineObj.IdZona.Value;
                        puntoVenta.Zona.NombreZona = cineObj.NombreZona;


                        result.Objects.Add(puntoVenta);
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

        public static ML.Result GetById(int IdCine)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())
                {

                    var cineObj = context.Cines.FromSqlRaw($"CineGetById {IdCine}").AsEnumerable().FirstOrDefault();

                    if (cineObj != null)
                    {

                        ML.Cine2 cine = new ML.Cine2();
                        cine.IdCine = cineObj.IdCine;
                        cine.NombreCine = cineObj.NombreCine;
                        cine.Direccion = cineObj.Direccion;
                        cine.Ventas = cineObj.Ventas;

                        cine.Zona = new ML.Zona();
                        cine.Zona.IdZona = cineObj.IdZona.Value;
                        cine.Zona.NombreZona = cineObj.NombreCine;



                        result.Object = cine;


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




        public static ML.Result Add(ML.Cine2 cine)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())

                {
                    var query = context.Database.ExecuteSqlRaw($"CineAdd '{cine.NombreCine}', '{cine.Direccion}', {cine.Ventas},{cine.Zona.IdZona}");


                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception e)
            {
                result.Correct = false;
                result.Ex = e;
                result.ErrorMessage = e.Message;

            }
            return result;
        }


        public static ML.Result Update(ML.Cine2 IdCine)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())

                {
                    var query = context.Database.ExecuteSqlRaw($"CineUpdate {IdCine.IdCine}, '{IdCine.NombreCine}', '{IdCine.Direccion}', {IdCine.Ventas},{IdCine.Zona.IdZona}");


                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception e)
            {
                result.Correct = false;
                result.Ex = e;
                result.ErrorMessage = e.Message;

            }
            return result;
        }


        public static ML.Result Delete(int IdCine)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())
                {
                    //var query = context.Database.ExecuteSqlRaw("ProductoDelete", IdProducto);
                    var query = context.Database.ExecuteSqlRaw($"CineDelete {IdCine}");


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



        public static ML.Result GetAllTotal()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaCineContext context = new DL.EliconaCineContext())
                {
                    var cines = context.PuntoVentas.FromSqlRaw($"GetAllTotalVentas").ToList();

                    result.Objects = new List<object>();
                    if (cines != null)
                    {
                        foreach (var resultado in cines)
                        {
                            ML.Cine2 puntozona = new ML.Cine2();
                            ML.Zona zona = new ML.Zona();


                            puntozona.Zona = new ML.Zona();
                            puntozona.Zona.IdZona = (int)resultado.IdZona;
                            puntozona.Zona.NombreZona = resultado.NombreZona;
                            puntozona.IdCine = (int)resultado.IdCine;
                            puntozona.NombreCine = resultado.NombreCine;
                            puntozona.Direccion = resultado.Direccion;
                            puntozona.Ventas = (decimal)resultado.Ventas;

                            result.Objects.Add(puntozona);

                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.Ex = e;
                result.ErrorMessage = e.Message;

            }
            return result;
        }
        public static ML.Estadistica CalcularPorcentaje(ML.Cine2 puntoVenta)
        {
            ML.Result result = new ML.Result();
            ML.Estadistica estadistica = new ML.Estadistica();
            puntoVenta.TotalVentas = 0;
            foreach (ML.Cine2 venta in puntoVenta.Estadistica.TotalVentas)
            {
                puntoVenta.TotalVentas = puntoVenta.TotalVentas + venta.Ventas;
            }
            result.Objects = new List<object>();
            foreach (ML.Cine2 procentaje in puntoVenta.Estadistica.TotalVentas)
            {
                procentaje.Ventas = (procentaje.Ventas / puntoVenta.TotalVentas) * 100;
                result.Objects.Add(procentaje);
            }
            return estadistica;
        }


    }
}