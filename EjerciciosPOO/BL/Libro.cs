using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {

        private string titulo;//variable
        private string autor;
        private int anio;

        private string Titulo { set; get; } //propiedad
        private string Autor { set; get; } //propiedad
        private int Anio { set; get; } //propiedad


        public Libro()//constructor vacio
        {

        }

        public Libro(string titulo, string autor, int anio)//constructor con parametros
        {
            //Titulo = titulo;
            //Autor = autor;
            //Anio = anio;
        }

        public override string ToString()
        {
            
            return "Titulo: " + titulo + "Autor" + autor + "Año" + anio;
            
        }
    }
}
