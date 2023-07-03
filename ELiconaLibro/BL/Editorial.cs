﻿using Microsoft.EntityFrameworkCore;
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
    public class Editorial
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EliconaLibroContext context = new DL.EliconaLibroContext())
                {
                    var edit = context.Editorials.FromSqlRaw($"GetAllEditorial").ToList();
                    //var usuarios = 0;
                    if (edit != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var ediObj in edit)
                        {
                            ML.Editorial ed = new ML.Editorial();
                            ed.IdEditorial = ediObj.IdEditorial;
                            ed.NombreEditorial = ediObj.NombreEditorial;


                            result.Objects.Add(ed);
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
