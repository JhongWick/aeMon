using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPIAnalytics.Controllers
{
    [KPIAuthorize]

    [UserAuth]
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            List<Role> model = new List<Role>();
            model = RoleData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            return PartialView("Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Role model)
        {
            bool result = RoleData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int RoleId)
        {
            Role role = RoleData.Fetch(RoleId);
            return PartialView("Delete", role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Role model)
        {
            bool result = RoleData.Delete(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int RoleId)
        {
            Role role = RoleData.Fetch(RoleId);
            return PartialView("Edit", role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role model)
        {
            bool result = RoleData.Edit(model);
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