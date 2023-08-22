using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    public class Logic
    {
        public void MostrarExcepcion()
        {
            throw new Exception("Este método devuelve una excepción");
        }
        public void ExcepcionPersonalizada()
        {
            throw new MyException("Excepción Personalizada: MyException", "Este método devuelve una excepción personalizada");
        }
    }
}
