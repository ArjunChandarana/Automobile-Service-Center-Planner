using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.AdminsArea.Controllers
{
    public class TempController : Controller
    {
        // GET: AdminsArea/Temp
        public ActionResult Index()
        {
            IEnumerable<Customer> customers;

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Customer>>();
                    readTask.Wait();

                    customers = readTask.Result;
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            
            return View(customers);
        }
    }
}