using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Entities;

namespace KPIAnalytics.Controllers
{

    [KPIAuthorize]

    [UserAuth]
    public class RegionsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Module
        public ActionResult Index()
        {
            List<Region> model = new List<Region>();
            model = RegionData.ListAll();
            return View(model);
        }
        public ActionResult Add()
        {   
            List<Region> model = new List<Region>();
            model = RegionData.ListAll();
            int count = model.Count();
            ViewBag.Number = count + 1;
            return PartialView("Add", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Region model)
        {
            bool result = RegionData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int RegionId)
        {
            Region region = RegionData.Fetch(RegionId);
            return PartialView("Delete", region);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Region model)
        {
            bool result = RegionData.Delete(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int RegionId)
        {
            Region region = RegionData.Fetch(RegionId);
            return PartialView("Edit", region);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Region model)
        {
            bool result = RegionData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}