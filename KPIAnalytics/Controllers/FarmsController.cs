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
    public class FarmsController : Controller
    {
       
        private DBContext db = new DBContext();
        

        // GET: Farms
        public ActionResult Index()
        {
            return View(db.Farms.ToList());
        }
        public ActionResult Location()
        {
            List<Farms> _farmList = db.Farms.ToList();
            string[] labels = new string[_farmList.Count()];
            string[] markers = new string[_farmList.Count()];
            int counter = 0;
            foreach(var item in _farmList)
            {
                string labelTemp = item.Barangay.ToString();
                labels[counter] = labelTemp.Substring(0, 1);
                string markerTemp = "lat: " + item.Latitude + ",  lng: " + item.Longititude + "";
                    markers[counter] = markerTemp;
                    counter++;
            }

            ViewBag.Label = labels;
            ViewBag.Marker = markers;
            ViewBag.Farms = _farmList;
            return View(db.Farms.ToList());
        }
        //public JsonResult GoogleGeoCode(string address)
        //{
        //    string url = "http://maps.googleapis.com/maps/api/geocode/json?sensor=true&key=AIzaSyA5KYqId9PhQ4cN3_IKL04qpd1Hoc3_W1c&address=";
            
        //    dynamic googleResults = new Uri(url + address).GetDynamicJsonObject();
        //    foreach (var result in googleResults.results)
        //    {
        //        Console.WriteLine("[" + result.geometry.location.lat + "," + result.geometry.location.lng + "] " + result.formatted_address);
        //    }
        //    var data = (string lat = result.geometry.location.lat , )
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        // GET: Farms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farms farms = db.Farms.Find(id);
            if (farms == null)
            {
                return HttpNotFound();
            }
            return View(farms);
        }

        // GET: Farms/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions.ToList(), "RegionId", "Name");
            return View();
        }

        // POST: Farms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmsId,UniqueId,KPIId,RegionId,Barangay,Municipality,Province,Latitude,Longititude,completeAddress")] Farms farms)
        {
            ViewBag.RegionId = new SelectList(db.Regions.ToList(), "RegionId", "Name");
            if (ModelState.IsValid)
            {
                farms.IsActive = true;
                farms.UniqueId = Guid.NewGuid();
                db.Farms.Add(farms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions.ToList(), "RegionId", "Name");
            return View(farms);
        }

        // GET: Farms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farms farms = db.Farms.Find(id);
            if (farms == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions.ToList(), "RegionId", "Name", farms.RegionId);
            return View(farms);
        }

        // POST: Farms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmsId,UniqueId,KPIId,RegionId,Barangay,Municipality,Province,Latitude,Longititude,completeAddress")] Farms farms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions.ToList(), "RegionId", "Name", farms.RegionId);
            return View(farms);
        }

        // GET: Farms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farms farms = db.Farms.Find(id);
            if (farms == null)
            {
                return HttpNotFound();
            }
            return View(farms);
        }

        // POST: Farms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farms farms = db.Farms.Find(id);
            db.Farms.Remove(farms);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult GetAllLocation()
        {
            var data = db.Farms.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLocationById(int id)
        {
            var data = db.Farms.Where(x => x.FarmsId == id).SingleOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
