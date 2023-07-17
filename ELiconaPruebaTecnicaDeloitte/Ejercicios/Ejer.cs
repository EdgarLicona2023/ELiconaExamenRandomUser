using System;

namespace Ejercicios
{
	public class Ejer
	{
		public static void FizzBuzz()
		{
			int i;
			int numero;

			Console.WriteLine("**Ejercicio FizzBuzz**\n");
			Console.WriteLine("Numero Hasta Donde Se Ejecutara FizzBuzz\n");
			numero = int.Parse(Console.ReadLine());
			Console.WriteLine("");
			Console.WriteLine("Inicio:\n");

			for (i = 1; i <= numero; i++)
			{
				if (i % 3 == 0 && i % 5 == 0)
				{
					Console.WriteLine("FizzBuzz\n");
				}
				else if (i % 3 == 0)
				{
					Console.WriteLine("Fizz\n");
				}
				else if (i % 5 == 0)
				{
					Console.WriteLine("Buzz\n");
				}
				else
				{
					Console.WriteLine(i + "\n");
				}
			}

			Console.Write("Fin\n");
			Console.Write("TODO QUEDA \n ¡GOOD!");
		}

		public static void Anagrama()
		{
			string palabra1;
			string palabra2;
			Console.WriteLine("**Anagrama**\n");
			Console.WriteLine("Primerapalabra a comparar");
			palabra1 = Console.ReadLine();
			Console.WriteLine("Segunda palabra a comparar");
			palabra2 = Console.ReadLine();

			if (palabra1.Equals(palabra2))
			{
				Console.WriteLine("Son anagramas");
			}
			else
			{
				Console.WriteLine("No son anagramas");
			}

			Console.ReadKey();
		}


		public static void Main() 
		{

		}
		public static void VariableTemp()
		{

			int primera;
			int segunda;

			Console.WriteLine("Primer Numero");
			primera = int.Parse(Console.ReadLine());
			Console.WriteLine("Segundo Numero");
			segunda = int.Parse(Console.ReadLine());

			Console.WriteLine("Antes:" + primera + "" + "" + segunda);
			primera = primera + segunda;
			segunda = primera - segunda;
			primera = primera - segunda;
			Console.WriteLine("Después: " + primera + "" + "" + segunda);
			
		}
	}
}