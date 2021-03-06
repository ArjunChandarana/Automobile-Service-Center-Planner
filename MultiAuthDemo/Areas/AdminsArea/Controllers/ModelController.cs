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
    public class ModelController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Model> models;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Model/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Model>>();
                    readTask.Wait();
                    models = readTask.Result;
                }
                else
                {
                    models = Enumerable.Empty<Model>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(models);
        }

        // GET: AdminsArea/Brand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminsArea/Brand/Create
        public ActionResult Create()
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
                }
            }
            ModelFormViewModel entity = new ModelFormViewModel
            {
                brands = brands,
                modelData = new Model()
            };
            
            return PartialView(entity);
        }

        // POST: AdminsArea/Brand/Create
        [HttpPost]
        public ActionResult Create(Model modelData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Model/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Model>("Create", modelData);
                    postTask.Wait();
                    /*var post = client.PostAsJsonAsync<Vehicle>("Vehicle/Create", vehicle).Result;*/

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Model Added successfully";
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
            IEnumerable<Brand> brands;
            Model model = new Model();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Brand/Get");
                var responseTask2 = client.GetAsync("Model/Get/" + id);
                responseTask.Wait();
                responseTask2.Wait();
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Brand>>();
                    readTask.Wait();
                    brands = readTask.Result;

                    var readTask2 = result2.Content.ReadAsAsync<Model>();
                    readTask2.Wait();
                    model = readTask2.Result;
                }
                else
                {
                    brands = Enumerable.Empty<Brand>();
                    model = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            ModelFormViewModel entity = new ModelFormViewModel
            {
                brands = brands,
                modelData = model
            };

            return PartialView(entity);
            
        }

        // POST: AdminsArea/Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(Model modelData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Model/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Model>("Edit", modelData);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Model Edited successfully";
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
                client.BaseAddress = new Uri("https://localhost:44318/Model/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Model Status Changed successfully";
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