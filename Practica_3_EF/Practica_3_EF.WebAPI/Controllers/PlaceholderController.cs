using Newtonsoft.Json;
using Practica_3_EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Practica_3_EF.WebAPI.Controllers
{
    public class PlaceholderController : Controller
    {
        // GET: Placeholder
        string api_JsonPlaceholder = "https://jsonplaceholder.typicode.com/posts";

        public async Task<ActionResult> Index()
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(api_JsonPlaceholder);

            List<JPHView> listado = JsonConvert.DeserializeObject<List<JPHView>>(json);

            return View(listado);
        }
    }
}