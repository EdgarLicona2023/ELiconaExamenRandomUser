namespace APP
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
					Console.WriteLine("1. Fizz Buzz");
					Console.WriteLine("2. Anagrama");
					Console.WriteLine("3. Comprension Basica");
					Console.WriteLine("4. Variable Temporal");
					Console.WriteLine("5. Matriz");
					Console.WriteLine("0. SALIR\n");
					//Console.WriteLine("SELECCIONA UNA OPCION");
					int opcion = Convert.ToInt32(Console.ReadLine());

					switch (opcion)
					{
						case 1:
							Ejercicios.Ejer.FizzBuzz();
							break;

						case 2:
							Ejercicios.Ejer.Anagrama();
							break;

						case 3:
							Ejercicios.Ejer.LetrasRepetidas();
							break;
						case 4:
							Ejercicios.Ejer.VariableTemp();
							break;
						case 5:
							Ejercicios.Ejer.Matriz();
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