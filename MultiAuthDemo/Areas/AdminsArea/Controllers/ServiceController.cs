using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.AdminsArea.Controllers
{
    public class ServiceController : Controller
    {
        // GET: AdminsArea/Service
        public ActionResult Index()
        {
            IEnumerable<Service> services;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Service/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Service>>();
                    readTask.Wait();
                    services = readTask.Result;
                }
                else
                {
                    services = Enumerable.Empty<Service>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(services);
        }

        // GET: AdminsArea/Brand/Create
        public ActionResult Create()
        {
            Service service = new Service();
            return PartialView(service);
        }

        // POST: AdminsArea/Service/Create
        [HttpPost]
        public ActionResult Create(Service service)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Service/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Service>("Create", service);
                    postTask.Wait();
                    /*var post = client.PostAsJsonAsync<Vehicle>("Vehicle/Create", vehicle).Result;*/

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Service Added successfully";
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

        // GET: AdminsArea/Service/Edit/5
        public ActionResult Edit(int id)
        {
            Service service = new Service();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Service/");
                //HTTP GET
                var responseTask = client.GetAsync("Get/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Service>();
                    readTask.Wait();
                    service = readTask.Result;
                }
                else
                {
                    service = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            return PartialView(service);
        }

        // POST: AdminsArea/Service/Edit/5
        [HttpPost]
        public ActionResult Edit(Service service)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Service/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Service>("Edit", service);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Brand Edited successfully";
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

        // GET: AdminsArea/Service/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Service/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Service Status Changed successfully";
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}