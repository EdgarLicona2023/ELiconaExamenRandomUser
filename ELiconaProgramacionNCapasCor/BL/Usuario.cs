using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlClient; //Importar libreria
using System.Data;
using ML;
using DL;
using System.Xml;
using System.Collections.ObjectModel;

namespace BL
{
    public class Usuario
    {

		public static ML.Result GetByUserName(string Email)
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
				{
					//var usuarioObj = context.UsuarioGetById(id_usuario).Single();
					var usuarioObj = context.Usuarios.FromSqlRaw($"UsuarioGetByUserName '{Email}'").AsEnumerable().FirstOrDefault();

					if (usuarioObj != null)
					{

						ML.Usuario usuario = new ML.Usuario();
                        usuario.Id_Usuario = usuarioObj.Id_Usuario.Value;
                        usuario.Id_Usuario = usuarioObj.Id_Usuario.Value;
                        usuario.UserName = usuarioObj.UserName;
                        usuario.NombreUsuario = usuarioObj.NombreUsuario;
                        usuario.ApellidoPaternoUsuario = usuarioObj.ApellidoPaternoUsuario;
                        usuario.ApellidoMaternoUsuario = usuarioObj.ApellidoMaternoUsuario;
                        usuario.Email = usuarioObj.Email;
                        usuario.Password = usuarioObj.Password;
                        usuario.FechaNacimiento = usuarioObj.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = usuarioObj.Sexo;
                        usuario.Telefono = usuarioObj.Telefono;
                        usuario.Celular = usuarioObj.Celular;
                        usuario.Curp = usuarioObj.Curp;


                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = usuarioObj.IdRol.Value;
                        usuario.Rol.Nombre = usuarioObj.Nombre;


                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = usuarioObj.IdDireccion.Value;
                        usuario.Direccion.Calle = usuarioObj.Calle;
                        usuario.Direccion.NumeroExterior = usuarioObj.NumeroExterior;
                        usuario.Direccion.NumeroInterior = usuarioObj.NumeroInterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = usuarioObj.IdColonia.Value;
                        usuario.Direccion.Colonia.NombreColonia = usuarioObj.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = usuarioObj.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = usuarioObj.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.NombreMunicipio = usuarioObj.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuarioObj.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = usuarioObj.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuarioObj.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = usuarioObj.NombrePais;

                        result.Object = usuario;


						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "ocurrio un error";
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
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    var usuarios = context.Usuarios.FromSql($"UsuarioGetAll").ToList();

                    //var usuarios = 0;
                    if (usuarios != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var usuarioObj in usuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Id_Usuario = usuarioObj.IdUsuario;
                            usuario.UserName = usuarioObj.UserName;
                            usuario.NombreUsuario = usuarioObj.NombreUsuario;
                            usuario.ApellidoPaternoUsuario = usuarioObj.ApellidoPaternoUsuario;
                            usuario.ApellidoMaternoUsuario = usuarioObj.ApellidoMaternoUsuario;
                            usuario.Email = usuarioObj.Email;
                            usuario.Password = usuarioObj.Password;
                            usuario.FechaNacimiento = usuarioObj.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Sexo = usuarioObj.Sexo;
                            usuario.Telefono = usuarioObj.Telefono;
                            usuario.Celular = usuarioObj.Celular;
                            usuario.Curp = usuarioObj.Curp;

                            //Instancia de Semestre
                            //ML.Semestre semestre = new ML.Semestre(); NO tiene relación con alumno
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = usuarioObj.IdRol.Value; //Solo cuando estamos seguros que viene un valor
                            usuario.Rol.Nombre = usuarioObj.Nombre;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = usuarioObj.IdDireccion.Value;
                            usuario.Direccion.Calle = usuarioObj.Calle;
                            usuario.Direccion.NumeroExterior = usuarioObj.NumeroExterior;
                            usuario.Direccion.NumeroInterior = usuarioObj.NumeroInterior;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = usuarioObj.IdColonia.Value;
                            usuario.Direccion.Colonia.NombreColonia = usuarioObj.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = usuarioObj.CodigoPostal;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = usuarioObj.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.NombreMunicipio = usuarioObj.NombreMunicipio;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuarioObj.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = usuarioObj.NombreEstado;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuarioObj.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = usuarioObj.NombrePais;

                            result.Objects.Add(usuario);
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


        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.NombreUsuario}', '{usuario.ApellidoPaternoUsuario}', '{usuario.ApellidoMaternoUsuario}', '{usuario.Curp}', '{usuario.FechaNacimiento}','{usuario.Telefono}','{usuario.UserName}','{usuario.Email}','{usuario.Password}','{usuario.Sexo}','{usuario.Celular}',{usuario.Rol.IdRol},'{usuario.Direccion.Calle}','{usuario.Direccion.NumeroExterior}','{usuario.Direccion.NumeroInterior}',{usuario.Direccion.Colonia.IdColonia}");

                    //var query = context.UsuarioAdd(usuario.NombreUsuario, usuario.ApellidoPaternoUsuario, usuario.ApellidoMaternoUsuario, usuario.Curp, usuario.FechaNacimiento, usuario.Telefono, usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Celular, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Direccion.Colonia.IdColonia);
                    //var query = 0;
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "REGISTRO EXITOSO";
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

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    int RowAffeted = context.Database.ExecuteSqlRaw($"UsuarioUpdate {usuario.Id_Usuario}, '{usuario.NombreUsuario}', '{usuario.ApellidoPaternoUsuario}', '{usuario.ApellidoMaternoUsuario}', '{usuario.Curp}', '{usuario.FechaNacimiento}','{usuario.Telefono}','{usuario.UserName}','{usuario.Email}','{usuario.Password}','{usuario.Sexo}','{usuario.Celular}',{usuario.Rol.IdRol}, {usuario.Direccion.IdDireccion},'{usuario.Direccion.Calle}','{usuario.Direccion.NumeroExterior}','{usuario.Direccion.NumeroInterior}',{usuario.Direccion.Colonia.IdColonia}");

                    //int RowAffeted = context.UsuarioUpdate(usuario.Id_Usuario, usuario.NombreUsuario, usuario.ApellidoPaternoUsuario, usuario.ApellidoMaternoUsuario, usuario.Curp, usuario.FechaNacimiento, usuario.Telefono, usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Celular, usuario.Rol.IdRol, usuario.Direccion.IdDireccion, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Direccion.IdColonia);
                    //var RowAffeted = 0;
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



        public static ML.Result Delete(int Id_Usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                   // var query = context.UsuarioDelete(Id_Usuario);
                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {Id_Usuario}");


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

        public static ML.Result GetById(int Id_Usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProgramacionNcapasContext context = new DL.ProgramacionNcapasContext())
                {
                    //var usuarioObj = context.UsuarioGetById(id_usuario).Single();
                    var usuarioObj = context.Usuarios.FromSqlRaw($"UsuarioGetById {Id_Usuario}").AsEnumerable().FirstOrDefault();

                    if (usuarioObj != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Id_Usuario = usuarioObj.Id_Usuario.Value;
                        usuario.UserName = usuarioObj.UserName;
                        usuario.NombreUsuario = usuarioObj.NombreUsuario;
                        usuario.ApellidoPaternoUsuario = usuarioObj.ApellidoPaternoUsuario;
                        usuario.ApellidoMaternoUsuario = usuarioObj.ApellidoMaternoUsuario;
                        usuario.Email = usuarioObj.Email;
                        usuario.Password = usuarioObj.Password;
                        usuario.FechaNacimiento = usuarioObj.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = usuarioObj.Sexo;
                        usuario.Telefono = usuarioObj.Telefono;
                        usuario.Celular = usuarioObj.Celular;
                        usuario.Curp = usuarioObj.Curp;

                        //Instancia de Semestre 
                        //ML.Semestre semestre = new ML.Semestre(); NO tiene relación con alumno
                        usuario.Rol = new ML.Rol();
                        //usuario.Rol.IdRol = usuarioObj.IdRol.Value; //Solo cuando estamos seguros que viene un valor
                        usuario.Rol.IdRol = usuarioObj.IdRol.Value;
                        usuario.Rol.Nombre = usuarioObj.Nombre;


                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = usuarioObj.IdDireccion.Value;
                        usuario.Direccion.Calle = usuarioObj.Calle;
                        usuario.Direccion.NumeroExterior = usuarioObj.NumeroExterior;
                        usuario.Direccion.NumeroInterior = usuarioObj.NumeroInterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = usuarioObj.IdColonia.Value;
                        usuario.Direccion.Colonia.NombreColonia = usuarioObj.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = usuarioObj.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = usuarioObj.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.NombreMunicipio = usuarioObj.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuarioObj.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = usuarioObj.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuarioObj.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = usuarioObj.NombrePais;

                        result.Object = usuario;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "ocurrio un error";
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
