using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicios
{
    public class Ejer
    {
        public static void CicloFor() 
        {
            int suma, f, valor;
            string linea;
            suma = 0;
            for (f = 1; f <= 10; f++)
            {
                Console.Write("Ingrese valor:");
                linea = Console.ReadLine();
                valor = int.Parse(linea);
                suma = suma + valor;
            }
            Console.Write("La suma es:" + suma);
            Console.ReadKey();
        }

        public static void CicloWhile()
        {
            int x, suma, valor;
            string linea;
            x = 1;
            suma = 0;
            while (x <= 10)
            {
                Console.Write("Ingrese un valor:");
                linea = Console.ReadLine();
                valor = int.Parse(linea);
                suma = suma + valor;
                x = x + 1;
            }

            Console.Write("La suma de los valores es:");
            Console.WriteLine(suma);
            Console.ReadKey();
        }

        public static void NumerosFibonacci()
        {

            int NumeroElementos;



            Console.Write("Ingrese el tamaño del arreglo:");
            NumeroElementos = Convert.ToInt32(Console.ReadLine());


            int[] arreglo = new int[NumeroElementos];
            arreglo[0] = 0;
            arreglo[1] = 1;

            for (int i = 2; i < NumeroElementos; i++)
            {
                arreglo[i] = arreglo[i - 1] + arreglo[i - 2];
            }

            Console.WriteLine(string.Join(",", arreglo));
        }
    }
}