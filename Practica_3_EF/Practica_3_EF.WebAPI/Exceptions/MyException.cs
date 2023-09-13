using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica_3_EF.WebAPI.Exceptions
{
    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }
}