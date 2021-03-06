using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.DealersArea.Controllers
{
    public class VehicleController : Controller
    {
        // GET: DealersArea/Vehicle
        public ActionResult Index()
        {
            return View();
        }

        // GET: DealersArea/Vehicle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DealersArea/Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DealersArea/Vehicle/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DealersArea/Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DealersArea/Vehicle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DealersArea/Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DealersArea/Vehicle/Delete/5
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
