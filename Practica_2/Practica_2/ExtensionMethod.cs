using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    public static class ExtensionMethod
    {
        private static int resultado;

        public static int DividirCero(this int num1)
        {
            try
            {
                resultado = num1 / 0; 
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }
            finally
            {
                Console.WriteLine("La operación ha finalizado");
            }
            return resultado;
        }

        public static int Dividir(this int num1, int num2)
        {
            try
            {
                resultado = num1 / num2;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("¡Solo Chuck Norris divide por cero!");
            }
            return resultado;
        }

    }
}
