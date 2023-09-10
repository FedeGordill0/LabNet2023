using Practica_3_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica_3_EF.Logic
{
    public interface ILogic<T> where T : class
    {
        List<T> GetAll();
        T Post(T entidad);
        void Delete(int id);
        void Put(T entidad);
    }
}
