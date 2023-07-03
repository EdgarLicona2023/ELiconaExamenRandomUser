using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tiendas
    {

        string direccion;//variable
        int numeroInterior;
        public string Direccion { set; get; } //propiedad



        public void ConsultarInformacion(int numeroInterior)//metodo no estatico
        {
            Console.WriteLine("Datos");
        }
        public  static void ConsultarInformacion(string direccion, int numeroCalle)//metodo estatico
        {
            Console.WriteLine("Datos");
        }

        public static void ConsultarInformacion(bool numeroExterior)
        {
            Console.WriteLine("Datos");
        }
        public Tiendas()//constructor vacio
        {
            
        }
        public Tiendas(string direccion)//constructor con parametros
        {
            Direccion=direccion;    
        }



    }

    
}
