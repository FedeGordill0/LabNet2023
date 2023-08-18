using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    internal class Logic
    {
        public void Logica()
        {
            throw new Exception("Este método devuelve una excepción");
            //try
            //{
            //    throw new Exception("Este método devuelve una excepción");
            //}
            //catch (Exception e)
            //{

            //}
            //finally
            //{
            //    Console.WriteLine("El programa ha finalizado");
            //}

        }
        public void Logica_4()
        {
            throw new MyException("Este método devuelve una excepción personalizada");
        }
    }
}
