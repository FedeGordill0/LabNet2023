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
            Console.WriteLine("Elegir operación a realizar: (1 - Dividir número en 0) (2 - Dividir dos valores) (3 - Logic) (4 - LogicMyException)");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("ingresar número para dividir en 0: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    num1.Dividir_Cero();
                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("Ingresar dividendo: ");
                        dividendo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingresar divisor: ");
                        divisor = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Resultado: " + dividendo.Dividir_2(divisor));


                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                    }
                    finally
                    {
                        Console.WriteLine("El programa ha finalizado");
                    }
                    break;

                case 3:
                    //Console.WriteLine(e.Message);

                    try
                    {
                        Logic l = new Logic();
                        l.Logica();
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
                    //try
                    //{
                    //    Console.WriteLine(l.Logica());
                    //}
                    //catch (DivideByZeroException div)
                    //{
                    //    Console.WriteLine(div.Message);
                    //}
                    break;

                default:
                    try
                    {
                        Logic l = new Logic();
                        l.Logica_4();
                    }
                    catch (MyException m)
                    {
                        Console.WriteLine(m.Message);
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
