using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Practica_1_POO
{
    public abstract class TransportePublico : ITransportePublico
    {
        private int pasajeros;

        public TransportePublico(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public int Pasajeros { get => pasajeros; set => pasajeros = value; }

        public virtual string Avanzar()
        {
            return "";
        }

        public virtual string Detenerse()
        {
            return "";
        }
    }
}
