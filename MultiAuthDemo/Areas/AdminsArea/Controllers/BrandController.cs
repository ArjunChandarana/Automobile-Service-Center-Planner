using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.AdminsArea.Controllers
{
    public class BrandController : Controller
    {
        /*[Authorize(Roles ="Admin")]*/
        // GET: AdminsArea/Brand
        public ActionResult Index()
        {
            IEnumerable<Brand> brands;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Brand/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Brand>>();
                    readTask.Wait();
                    brands = readTask.Result;
                }
                else
                {
                    brands = Enumerable.Empty<Brand>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(brands);
        }

        // GET: AdminsArea/Brand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminsArea/Brand/Create
        public ActionResult Create()
        {
            Brand brand = new Brand();
            return PartialView(brand);
        }

        // POST: AdminsArea/Brand/Create
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Brand/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Brand>("Create", brand);
                    postTask.Wait();
                    /*var post = client.PostAsJsonAsync<Vehicle>("Vehicle/Create", vehicle).Result;*/

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Brand Added successfully";
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

        // GET: AdminsArea/Brand/Edit/5
        public ActionResult Edit(int id)
        {
            Brand brand = new Brand();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Brand/");
                //HTTP GET
                var responseTask = client.GetAsync("Get/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Brand>();
                    readTask.Wait();
                    brand = readTask.Result;
                }
                else
                {
                    brand = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            return PartialView(brand);
        }

        // POST: AdminsArea/Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Brand/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Brand>("Edit", brand);
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

        // GET: AdminsArea/Brand/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Brand/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Brand Status Changed successfully";
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        // POST: AdminsArea/Brand/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
