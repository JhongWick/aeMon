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
    public class RoleDetailsController : Controller
    {
        // GET: RoleDetail

        // GET: RoleDetails 
        //[eProcAuthorize]

        public ActionResult Update(string Id)
        {
            if (Id == null) { Id = 0.ToString(); }
            List<Role> model = RoleData.ListAll();
            // List<ModuleModel> model = ModuleData.GetModel(Convert.ToInt32(Id));
            Role _role = RoleData.ListAll().Where(o => o.RoleId == Convert.ToInt32(Id)).SingleOrDefault();
            int RoleId = Convert.ToInt32(Id);
            ViewBag.RoleDetails = RoleDetailData.GetById(Convert.ToInt32(Id));
            ViewBag.Roles = RoleData.ListAll();
            // ViewBag.Modules = ModuleData.GetModel(Convert.ToInt32(Id));
            return View(model);
        }
        public ActionResult SaveDetails(string[] id, string[] names, string[] status, string roleid)
        {
            int RoleId = Convert.ToInt32(roleid);
            bool data = RoleDetailData.Save(roleid, id, names, status);

            return this.Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get()
        {
            List<Module> details = ModuleData.GetList();
            return this.Json(details, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Fetch(string Id)
        {
            if (Id == null) { Id = 0.ToString(); }

            List<ModuleModel> model = ModuleData.GetModel(Convert.ToInt32(Id));

            Role _role = RoleData.ListAll().Where(o => o.RoleId == Convert.ToInt32(Id)).SingleOrDefault();
            int RoleId = Convert.ToInt32(Id);
            ViewBag.RoleDetails = RoleDetailData.GetById(Convert.ToInt32(Id));
            ViewBag.Roles = RoleData.ListAll();
            ViewBag.Modules = ModuleData.GetList();
            string[] mId = new string[model.Count];
            string[] mName = new string[model.Count];
            string[] misAllowed = new string[model.Count];
            for (int i = 0; i < model.Count; i++)
            {
                mId[i] = model[i].ModuleId.ToString();
                mName[i] = model[i].Name.ToString();
                misAllowed[i] = model[i].IsAllowed.ToString();
            }


            return this.Json(new { id = mId, name = mName, isallowed = misAllowed }, JsonRequestBehavior.AllowGet);
        }
    }
}