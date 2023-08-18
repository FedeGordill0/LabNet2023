using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Practica_1_POO
{
    internal class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros) : base(pasajeros)
        {
            this.Pasajeros = pasajeros;
        }

        public override string Avanzar()
        {
            return "El omnibus está avanzando";
        }
        public override string Detenerse()
        {
            return "El omnibus se detuvo";
        }
    }

}
