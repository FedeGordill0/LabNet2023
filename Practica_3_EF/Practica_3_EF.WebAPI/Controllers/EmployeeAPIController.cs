using Antlr.Runtime.Tree;
using Practica_3_EF.Data;
using Practica_3_EF.Entities;
using Practica_3_EF.Logic;
using Practica_3_EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Practica_3_EF.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeAPIController : ApiController
    {
        EmployeeLogic eLogic = new EmployeeLogic();
        public IHttpActionResult GetEmpleados()
        {
            try
            {
                List<Employees> empleados = eLogic.GetAll();

                List<EmployeeView> listadoEmpleados = empleados.Select(e =>
                new EmployeeView
                {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Title = e.Title,
                    Country = e.Country
                }).ToList();

                return Ok(listadoEmpleados);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        public IHttpActionResult GetEmpleado(int id)
        {
            try
            {
                Employees empleado = eLogic.GetID(id);


                if (empleado == null)
                {
                    return NotFound();
                }

                EmployeeView empleadoDto = new EmployeeView
                {
                    EmployeeID = empleado.EmployeeID,
                    FirstName = empleado.FirstName,
                    LastName = empleado.LastName,
                    Title = empleado.Title,
                    Country = empleado.Country
                };
                return Ok(empleadoDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Ocurrió un error al obtener la categoría.", ex));
            }
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult PostEmpleado([FromBody] EmployeeView employeeView)
        {
            try
            {
                Employees empleado = new Employees
                {
                    FirstName = employeeView.FirstName,
                    LastName = employeeView.LastName,
                    Title = employeeView.Title,
                    Country = employeeView.Country
                };

                eLogic.Post(empleado);
                return Content(HttpStatusCode.Created, empleado);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult PutEmpleado([FromBody] EmployeeView employeeView, int id)
        {
            try
            {
                using (var db = new NorthwindContext())
                {
                    var oEmpleado = db.Employees.Find(id);
                    oEmpleado.FirstName = employeeView.FirstName;
                    oEmpleado.LastName = employeeView.LastName;
                    oEmpleado.Title = employeeView.Title;
                    oEmpleado.Country = employeeView.Country;

                    eLogic.Put(oEmpleado);
                }
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        public IHttpActionResult DeleteEmpleado(int id)
        {
            try
            {
                eLogic.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }
    }
}