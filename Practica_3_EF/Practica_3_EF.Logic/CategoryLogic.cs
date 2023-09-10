using Practica_3_EF.Data;
using Practica_3_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Practica_3_EF.Logic
{
    public class CategoryLogic : BLogic, ILogic<Categories>
    {
        public CategoryLogic()
        {
           
        }public CategoryLogic(NorthwindContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var idCategoria = _context.Categories.Find(id);

            if (idCategoria != null)
            {
                _context.Categories.Remove(idCategoria);
                _context.SaveChanges();
            }
            else
            {
                throw new MyException("No existe la categoría con ID: " + id);
                throw new OverflowException("El valor del ID es demasiado grande");
            }
        }

        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Categories Post(Categories entidad)
        {
            if (entidad.CategoryName.Length < 15)
            {
                _context.Categories.Add(entidad);
                _context.SaveChanges();
                return entidad;
            }
            else
            {
                throw new MyException("El nombre de la categoría no puede ser mayor a 15 caracteres");
            }
        }

        public void Put(Categories entidad)
        {
            var categoriaUpdate = _context.Categories.Find(entidad.CategoryID);

            if (categoriaUpdate != null)
            {
                if (entidad.CategoryName.Length < 15)
                {
                    categoriaUpdate.Description = entidad.Description;
                    categoriaUpdate.CategoryName = entidad.CategoryName;

                    _context.SaveChanges();
                }
                else
                {
                    throw new MyException("El nombre de la categoría no puede ser mayor a 15 caracteres");
                }
            }
            else
            {
                throw new MyException("No existe la categoría con ID: " + entidad.CategoryID);
                    throw new OverflowException("El valor del ID es demasiado grande");
            }
        }
    }
}
