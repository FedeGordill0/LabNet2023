using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    internal class Program
    {

        private static int num1;
        private static int dividendo;
        private static int divisor;
        static void Main(string[] args)
        {
            Console.WriteLine("Elegir operación a realizar: (1 - Dividir número en 0) (2 - Dividir dos valores) (3 - Mostrar Excepción) (4 - Mostrar Excepción Personalizada)");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Ingresar número para dividir en 0: ");
                        num1 = Convert.ToInt32(Console.ReadLine());
                        num1.DividirCero();
                    }
                    catch (DivideByZeroException div)
                    {
                        Console.WriteLine(div.Message);
                    }

                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("Ingresar dividendo: ");
                        dividendo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingresar divisor: ");
                        divisor = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Resultado: " + dividendo.Dividir(divisor));
                    }
                    catch (DivideByZeroException div)
                    {
                        Console.WriteLine(div.Message);
                        Console.WriteLine(div.StackTrace);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("¡Seguro ingresó una letra, o no ingresó nada!");
                    }
                    finally
                    {
                        Console.WriteLine("El programa ha finalizado");
                    }
                    break;

                case 3:
                    try
                    {
                        Logic l = new Logic();
                        l.MostrarExcepcion();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        Console.WriteLine("El programa ha finalizado");
                    }
                    break;

                default:
                    try
                    {
                        Logic l = new Logic();
                        l.ExcepcionPersonalizada();
                    }
                    catch (MyException my)
                    {
                        Console.WriteLine($"{my.Message}. {my.mensajeAdicional}");
                    }
                    finally
                    {
                        Console.WriteLine("El programa ha finalizado");
                    }
                    break;
            }

            Console.ReadKey();
        }
    }
}
