using Practica_3_EF.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_3_EF.Logic
{
    public abstract class BLogic
    {
        protected  NorthwindContext _context;

        public BLogic()
        {
            _context = new NorthwindContext();
        }
    }
}
