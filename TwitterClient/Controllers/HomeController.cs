using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TwitterClient.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            var client = new HttpClient();
            string model = string.Empty;
            var task = await client.GetAsync("http://search.twitter.com/search.json?q=pluralsight");
            var result = await task.Content.ReadAsStringAsync();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}