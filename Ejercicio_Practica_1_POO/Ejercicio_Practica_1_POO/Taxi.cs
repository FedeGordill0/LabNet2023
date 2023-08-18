using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Practica_1_POO
{
    internal class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {
            this.Pasajeros = pasajeros;
        }

        public override string Avanzar()
        {
            return "El taxi está avanzando";
        }
        public override string Detenerse()
        {
            return "El taxi se detuvo";
        }
    }

}
