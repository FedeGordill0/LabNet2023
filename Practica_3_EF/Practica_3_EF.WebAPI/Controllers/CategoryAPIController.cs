using Practica_3_EF.Data;
using Practica_3_EF.Entities;
using Practica_3_EF.Logic;
using Practica_3_EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;

namespace Practica_3_EF.WebAPI.Controllers
{
    public class CategoryAPIController : ApiController
    {
        CategoryLogic cLogic = new CategoryLogic();

        // GET: api/Category
        public IHttpActionResult GetCategorias()
        {
            try
            {
                List<Categories> categorias = cLogic.GetAll();

                List<CategoryView> listadoCategorias = categorias.Select(s => new CategoryView
                {
                    CategoryID = s.CategoryID,
                    CategoryName = s.CategoryName,
                    Description = s.Description,
                }).ToList();

                return Ok(listadoCategorias);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPost]
        public IHttpActionResult PostCategoria([FromBody] CategoryView categoryView)
        {
            try
            {
                Categories categoriaEntity = new Categories
                {
                    CategoryName = categoryView.CategoryName,
                    Description = categoryView.Description
                };

                cLogic.Post(categoriaEntity);
                return Content(HttpStatusCode.Created, categoriaEntity);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }


        [HttpPut]
        public IHttpActionResult PutCategoria([FromBody] CategoryView categoryView, int id)
        {
            try
            {
                using (var db = new NorthwindContext())
                {
                    var oCategoria = db.Categories.Find(id);
                    oCategoria.CategoryName = categoryView.CategoryName;
                    oCategoria.Description = categoryView.Description;

                    cLogic.Put(oCategoria);
                }
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }

        }

        public IHttpActionResult DeleteCategoria(int id)
        {
            try
            {
                cLogic.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, e);
            }
        }
    }
}