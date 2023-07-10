namespace PL
{
    internal class Program
    {


        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {

                try
                {
                    Console.WriteLine("SELECCIONA UNA OPCION\n");
                    Console.WriteLine("1. Ciclo For");
                    Console.WriteLine("2. Ciclo While");
                    Console.WriteLine("3. Numeros Fibonacci");
                    Console.WriteLine("0. SALIR\n");
                    //Console.WriteLine("SELECCIONA UNA OPCION");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Ejercicios.Ejer.CicloFor();
                            break;

                        case 2:
                            Ejercicios.Ejer.CicloWhile();
                            break;

                        case 3:
                            Ejercicios.Ejer.NumerosFibonacci();
                            break;

                        case 0:
                            Console.WriteLine("SELECCIONASTE SALIR");
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("ELIGE UNA OPCION");
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();

        }

    }
}