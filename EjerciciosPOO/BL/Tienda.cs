using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tienda
    {
        public string Nombre { get; set; }
        protected int Cantidad { get; set; }
        public string Productos { get; set; }
        public string Direccion { get; set; }
        private int Precio { get; set; }

        public void Comprar(int total)
        {
            Precio = Precio + total;
        }

    }

    public class Sucursal : Tienda
    {
        public int Capacidad { get; set; }

        public Sucursal(int capacidad, string productos, string direccion) 
        {
            Capacidad = capacidad; 
            Productos = productos;
            Direccion = direccion;
        }   

    }

    public class Ejemplo_06_02a
    {

        public static void Main()
        {
            Tienda t = new Tienda();

            Console.WriteLine("Valores...");
            t.Comprar(1);   
           
        }

    }










    public class Vehiculo
    {
        public decimal VelocidadMaxima { get; set; }
        public int NumeroRuedas { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Vehiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }
        public void Acelerar()
        {
            Console.WriteLine("Acelerar vehículo");
            //Pisar el acelerador
        }

    }

    public class Moto : Vehiculo
    {
        public int Cilindrada { get; set; }

        public Moto(string marca, string modelo, int cilindrada) : base(marca, modelo)
        {
            Cilindrada = cilindrada;
        }

        public new void Acelerar()
        {
            //Girar el puño
            Console.WriteLine("Acelerar Moto");
        }
    }


}
