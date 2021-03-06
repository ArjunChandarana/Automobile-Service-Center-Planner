using ASC.Common;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.AdminsArea.Controllers
{
    public class CustomerController : Controller
    {
        // GET: AdminsArea/Customer
        public ActionResult Index()
        {
            IEnumerable<Customer> customers;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Customer/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
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

        // GET: AdminsArea/Customer/Create
        public ActionResult Create()
        {
            IEnumerable<Dealer> dealers;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Dealer/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Dealer>>();
                    readTask.Wait();
                    dealers = readTask.Result;
                }
                else
                {
                    dealers = Enumerable.Empty<Dealer>();
                }
            }
            CustomerFormModel entity = new CustomerFormModel
            {
                dealers = dealers,
                customer = new Customer()
            };

            return PartialView(entity);
        }

        // POST: AdminsArea/Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Customer/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Customer>("Create", customer);
                    postTask.Wait();
                    /*var post = client.PostAsJsonAsync<Vehicle>("Vehicle/Create", vehicle).Result;*/

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Customer Added successfully";
                        return RedirectToAction("Index");
                    }
                }
                TempData["Type"] = 2;
                TempData["Message"] = "Error Occured While Creating";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminsArea/Customer/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Dealer> dealers;
            Customer customer = new Customer();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Dealer/Get");
                var responseTask2 = client.GetAsync("Customer/Get/" + id);
                responseTask.Wait();
                responseTask2.Wait();
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Dealer>>();
                    readTask.Wait();
                    dealers = readTask.Result;

                    var readTask2 = result2.Content.ReadAsAsync<Customer>();
                    readTask2.Wait();
                    customer = readTask2.Result;
                }
                else
                {
                    dealers = Enumerable.Empty<Dealer>();
                    customer = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            CustomerFormModel entity = new CustomerFormModel
            {
                dealers = dealers,
                customer = customer
            };

            return PartialView(entity);

        }

        // POST: AdminsArea/Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Customer/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Customer>("Edit", customer);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Customer Edited successfully";
                        return RedirectToAction("Index");
                    }
                }
                TempData["Type"] = 2;
                TempData["Message"] = "Error Occured While Updating";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminsArea/Brand/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Customer/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Customer Status Changed successfully";
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}