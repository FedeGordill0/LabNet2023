using Practica_3_EF.Data;
using Practica_3_EF.Logic;
using Practica_3_EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
namespace Practica_3_EF.WebAPI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryAPI
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            string api_url = "https://localhost:44312/api/CategoryAPI";

            HttpResponseMessage response = await httpClient.GetAsync(api_url);
            if (response.IsSuccessStatusCode)
            {
                List<CategoryView> categorias = await response.Content.ReadAsAsync<List<CategoryView>>();

                return View(categorias);
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult Insert()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> InsertarCategoria(CategoryView categoryView)
        {
            try
            {
                var httpClient = new HttpClient();
                string api_url = "https://localhost:44312/api/CategoryAPI";


                HttpResponseMessage response = await httpClient.PostAsJsonAsync(api_url, categoryView);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (MyException f)
            {
                Console.WriteLine(f.Message);
                return RedirectToAction("Error");
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
            catch (MyException n)
            {
                Console.WriteLine(n.Message);
                throw;
            }
            return View(model);
        }

        [System.Web.Http.HttpPut]
        public async Task<ActionResult> UpdateCategoria(CategoryView categoryView)
        {
            try
            {
                var httpClient = new HttpClient();
                string api_url = $"https://localhost:44312/api/CategoryAPI/{categoryView.CategoryID}";

                HttpResponseMessage response = await httpClient.PutAsJsonAsync(api_url, categoryView);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error: " + e.Message); 
                return View("Error");
            }
        }

  
        public async Task<ActionResult> DeleteCategoria(int id) {
            try
            {
                var httpClient = new HttpClient();
                string api_url = $"https://localhost:44312/api/CategoryAPI/{id}";

                HttpResponseMessage response = await httpClient.DeleteAsync(api_url);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error: " + e.Message); 
                return View();
            }
        }
    }
}