using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        //public static void Main()
        //{
        //    string direccion = "azul";

        //                                //constructor con parametros
        //    BL.Tiendas consul = new BL.Tiendas(direccion);

        //                                 //constructor vacio
        //    BL.Tiendas consulta = new BL.Tiendas();
        //    consulta.Direccion = "Calle Doce";


        //    int numeroInterior = 10;

        //    consul.ConsultarInformacion(numeroInterior);//instanciar metodo no estatico


        //    string direcciones = "Calle UNo";//asignar valor a una variable
        //    int numeroCalle = 22;
        //    BL.Tiendas.ConsultarInformacion(direcciones, numeroCalle);//instanciar metodo estatico

        //}

        public static void Main(string[] args)
        {
            double longitud = 20;
            double ancho = 5;

            BL.Rectangulo rectangulo = new BL.Rectangulo(longitud, ancho);
       
     
            Console.WriteLine("El Area es: " + rectangulo.CalcularArea(longitud,ancho));
            Console.ReadKey();  

        }


    }
}
