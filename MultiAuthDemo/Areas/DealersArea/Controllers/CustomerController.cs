using ASC.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.DealersArea.Controllers
{
    public class CustomerController : Controller
    {
        Customer viewcustomer = new Customer();
        public ActionResult GetCustomer()
        {
            IEnumerable<Customer> customers;
            string userId = User.Identity.GetUserId();
           
           
            

                using (var client = new HttpClient())

                {

                    client.BaseAddress = new Uri("https://localhost:44318/Dealer/");
                    //HTTP GET
                    var responseTask = client.GetAsync("GetCustomer/"+ "40c03d57-c966-40c1-a981-32ca7faf9a89");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                        readTask.Wait();
                        customers = readTask.Result;
                    }
                    else
                    {
                        customers = Enumerable.Empty<Customer>();
                        ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                    }
                }

                return View(customers);
            }
          
           
            
        }

        
        
}

