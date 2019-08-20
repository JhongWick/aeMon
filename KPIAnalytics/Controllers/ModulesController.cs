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
    public class ModulesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Module
        public ActionResult Index()
        {
            List<Module> model = new List<Module>();
            model = ModuleData.ListAll();
            return View(model);
        }
        public ActionResult Add()
        {
            List<Module> model = new List<Module>();
            model = ModuleData.ListAll();
            return PartialView("Add", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Module model)
        {
            bool result = ModuleData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int ModuleId)
        {
            Module module = ModuleData.Fetch(ModuleId);
            return PartialView("Delete", module);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Module model)
        {
            bool result = ModuleData.Delete(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ModuleId)
        {
            Module module = ModuleData.Fetch(ModuleId);
            return PartialView("Edit", module);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Module model)
        {
            bool result = ModuleData.Edit(model);
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