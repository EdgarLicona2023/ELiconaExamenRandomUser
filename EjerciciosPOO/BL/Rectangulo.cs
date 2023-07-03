using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rectangulo
    {
        private double longitud;//variable
        private double ancho;

        public double Longitud { set; get; } //propiedad
        public double Ancho { set; get; } //propiedad


        double suma;
        double resultado;


        public Rectangulo()//constructor vacio
        {

        }

        public Rectangulo(double longitud, double ancho)//constructor vacio
        {
            Longitud = longitud;
            Ancho = ancho;
        }

        public double CalcularArea(double longitud, double ancho)
        {
           double suma = longitud * ancho;


            return suma;
            //Console.WriteLine("Resultado es: " + suma);
        }


    }

   
}
