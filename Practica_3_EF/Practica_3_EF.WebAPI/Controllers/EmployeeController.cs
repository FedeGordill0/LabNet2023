using Newtonsoft.Json;
using Practica_3_EF.Data;
using Practica_3_EF.Logic;
using Practica_3_EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Practica_3_EF.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            string api_url = "https://localhost:44312/api/EmployeeAPI";

            HttpResponseMessage response = await httpClient.GetAsync(api_url);

            if (response.IsSuccessStatusCode)
            {
                List<EmployeeView> empleados = await response.Content.ReadAsAsync<List<EmployeeView>>();
                return View(empleados);
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

        [HttpPost]
        public async Task<ActionResult> Insert(EmployeeView employeeView)
        {
            var httpClient = new HttpClient();
            string api_url = "https://localhost:44312/api/EmployeeAPI";

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(api_url, employeeView);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Update(int id)
        {
            EmployeeView modelo = new EmployeeView();
            try
            {
                using (var db = new NorthwindContext())
                {
                    var oEmpleado = db.Employees.Find(id);
                    modelo.EmployeeID = oEmpleado.EmployeeID;
                    modelo.FirstName = oEmpleado.FirstName;
                    modelo.LastName = oEmpleado.LastName;
                    modelo.Title = oEmpleado.Title;
                    modelo.Country = oEmpleado.Country;

                }
            }
            catch (MyException n)
            {
                Console.WriteLine(n.Message);
                throw;
            }
            return View(modelo);
        }

        [System.Web.Http.HttpPut]
        public async Task<ActionResult> UpdateEmpleado(EmployeeView employeeView)
        {
            try
            {
                var httpClient = new HttpClient();
                string api_url = $"https://localhost:44312/api/EmployeeAPI/{employeeView.EmployeeID}";

                HttpResponseMessage response = await httpClient.PutAsJsonAsync(api_url, employeeView);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else { return View("Error"); }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error: " + e.Message);
                return View("Error");
            }
        }

        public async Task<ActionResult> DeleteEmpleado(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                string api_url = $"https://localhost:44312/api/EmployeeAPI/{id}";

                HttpResponseMessage response = await httpClient.DeleteAsync(api_url);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else { return View("Error"); }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error: " + e.Message);
                return View("Error");
            }
        }
    }
}