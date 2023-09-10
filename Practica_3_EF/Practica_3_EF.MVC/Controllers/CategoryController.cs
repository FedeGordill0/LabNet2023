using Antlr.Runtime.Tree;
using Practica_3_EF.Data;
using Practica_3_EF.Entities;
using Practica_3_EF.Logic;
using Practica_3_EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace Practica_3_EF.MVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryLogic categoryLogic = new CategoryLogic();

        private readonly NorthwindContext _context;

        // GET: Category
        public ActionResult Index()
        {
            List<Categories> categorias = categoryLogic.GetAll();

            var categoryView = new CategoryView();

            List<CategoryView> listadoCategorias = categorias.Select(s => new CategoryView
            {
                CategoryID = s.CategoryID,
                CategoryName = s.CategoryName,
                Description = s.Description,
            }).ToList();

            return View(listadoCategorias);
        }

        public ActionResult Insert()
        {
            return View();
        }

        //POST: Category
        [HttpPost]
        public ActionResult Insert(CategoryView categoryView)
        {
            try
            {
                if(!ModelState.IsValid){
                    return View(categoryView);
                }

                Categories categoriaEntity = new Categories
                {
                    CategoryName = categoryView.CategoryName,
                    Description = categoryView.Description
                };

                categoryLogic.Post(categoriaEntity);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index", "Error");
            }
        }


        public ActionResult Update(int id)
        {
            CategoryView model = new CategoryView();
            try
            {

                using (var db = new NorthwindContext())
                {
                    var oCategoria = db.Categories.Find(id);
                    model.CategoryID = oCategoria.CategoryID;
                    model.CategoryName = oCategoria.CategoryName;
                    model.Description = oCategoria.Description;

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoryView categoryView)
        {

            if (!ModelState.IsValid)
            {
                return View(categoryView);
            }

            using (var db = new NorthwindContext())
            {
                var oCategoria = db.Categories.Find(categoryView.CategoryID);
                oCategoria.CategoryName = categoryView.CategoryName;
                oCategoria.Description = categoryView.Description;

                categoryLogic.Put(oCategoria);
            }



            return Redirect(Url.Content("~/Category/"));
        }



        public ActionResult Delete(int id)
        {
            try
            {
                categoryLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
