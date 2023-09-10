using Practica_3_EF.Data;
using Practica_3_EF.Entities;
using Practica_3_EF.Logic;
using Practica_3_EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_3_EF.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeLogic employeeLogic = new EmployeeLogic();
        private readonly NorthwindContext _context;

        // GET: Employee
        public ActionResult Index()
        {
            List<Employees> empleados = employeeLogic.GetAll();
            var employeeView = new EmployeeView();

            List<EmployeeView> listadoEmpleados = empleados.Select(e => new EmployeeView
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                Country = e.Country
            }).ToList();

            return View(listadoEmpleados);
        }

        public ActionResult Insert()
        {
            return View();
        }

        //POST: Category
        [HttpPost]
        public ActionResult Insert(EmployeeView employeeView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employeeView);
                }
                Employees empleadoEntity = new Employees
                {
                    FirstName = employeeView.FirstName,
                    LastName = employeeView.LastName,
                    Title = employeeView.Title,
                    Country = employeeView.Country

                };

                employeeLogic.Post(empleadoEntity);

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
            EmployeeView model = new EmployeeView();
            try
            {

                using (var db = new NorthwindContext())
                {

                    var oEmpleado = db.Employees.Find(id);
                    model.EmployeeID = oEmpleado.EmployeeID;
                    model.FirstName = oEmpleado.FirstName;
                    model.LastName = oEmpleado.LastName;
                    model.Title = oEmpleado.Title;
                    model.Country = oEmpleado.Country;


                }
            }
            catch (Exception e)
            {

                throw;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(EmployeeView employeeView)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeView);
            }

            using (var db = new NorthwindContext())
            {
                var oEmpleado = db.Employees.Find(employeeView.EmployeeID);
                oEmpleado.FirstName = employeeView.FirstName;
                oEmpleado.LastName = employeeView.LastName;
                oEmpleado.Title = employeeView.Title;
                oEmpleado.Country = employeeView.Country;

                employeeLogic.Put(oEmpleado);
            }
            return Redirect(Url.Content("~/Employee/"));
        }
        public ActionResult Delete(int id)
        {
            try
            {
                employeeLogic.Delete(id);
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