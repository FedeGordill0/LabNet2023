using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    public class MyException : Exception
    {
        public string mensajeAdicional;
        public MyException(string message) : base(message)
        {
        }

        public MyException(string message, string mensajeAdicional) : base(message)
        {
            this.mensajeAdicional = mensajeAdicional;
        }
    }
}
