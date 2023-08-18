using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    internal static class ExtensionMethod
    {
        private static int num1;
        private static int num2;
        private static int resultado;

        public static int Dividir_Cero(this int num1)
        {
            try
            {
                resultado = num1 / 0;
            }
            catch (DivideByZeroException div)
            {
                Console.WriteLine(div.ToString());
            }
            finally
            {
                Console.WriteLine("El programa ha finalizado");
            }

            return resultado;
        }

        public static int Dividir_2(this int num1, int num2)
        {
            try
            {
                if (num2 == 0)
                {
                    throw new DivideByZeroException();
                }

                resultado = num1 / num2;
                return resultado;
            }

            catch (DivideByZeroException div)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
                Console.WriteLine(div.Message);
            }
            return resultado;
        }

    }
}
