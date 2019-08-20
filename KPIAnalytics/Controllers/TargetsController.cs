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
    public class TargetsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Targets
        public ActionResult Index()
        {
            return View(db.Targets.ToList());
        }
        // GET: ProductionTarget
        public ActionResult Dashboard()
        {
            int[] year = KPIData.getCurrentTarget();
            double[] production = new double[year.Count()];
            int[] farmer = new int[year.Count()];
            int[] trees = new int[year.Count()];
            int counter = 0;
            foreach (int item in year)
            {
                double tempProduction = 0;
                int tempFarmer = 0;
                int tempTrees = 0;

                List<KPI> kpi = db.KPIs.Where(x => x.Year == item).ToList();
                foreach (var kpiItem in kpi)
                {
                    tempProduction = tempProduction + kpiItem.Production;
                    tempFarmer = tempFarmer + (kpiItem.Male + kpiItem.Female);
                    tempTrees = tempTrees + kpiItem.NoOfTrees;
                }

                production[counter] = (tempProduction * .001);
                farmer[counter] = tempFarmer;
                trees[counter] = tempTrees;
                counter++;

            }
            ViewBag.Production_array = production;
            ViewBag.Farmers_array = farmer;
            ViewBag.Trees_array = trees;
            ViewBag.Year_array = year;
            return View(db.KPIs.ToList());
        }

        // GET: Targets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Target target = db.Targets.Find(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        // GET: Targets/Create
        public ActionResult Create()
        {
            ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 5, 15).ToList();

            ViewBag.RegionId = new SelectList(db.Regions.ToList(), "RegionId", "Name");
            Target _target = new Target();
            
            return View(_target);
        }

        // POST: Targets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TargetId,UniqueId,Description,YearStart,YearEnd,MetricTonne,Trees,Farmers,RegionI,RegionII,RegionIII,RegionIVa,RegionIVb,RegionV,RegionVI,RegionVII,RegionVIII,RegionIX,RegionX,RegionXI,RegionXII,RegionXIII,RegionNCR,RegionCAR,RegionARMMM")] Target target)
        {
            if (ModelState.IsValid)
            {
                target.UniqueId = Guid.NewGuid();
                db.Targets.Add(target);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 5, 15).ToList();
            ViewBag.RegionId = new SelectList(db.Regions.ToList(), "RegionId", "Name");
            return View(target);
        }

        // GET: Targets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Target target = db.Targets.Find(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 5, 15).ToList();
            return View(target);
        }

        // POST: Targets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TargetId,UniqueId,Description,YearStart,YearEnd,MetricTonne,Trees,Farmers,RegionI,RegionII,RegionIII,RegionIVa,RegionIVb,RegionV,RegionVI,RegionVII,RegionVIII,RegionIX,RegionX,RegionXI,RegionXII,RegionXIII,RegionNCR,RegionCAR,RegionARMMM")] Target target)
        {
            if (ModelState.IsValid)
            {
                db.Entry(target).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 5, 15).ToList();
            return View(target);
        }

        // GET: Targets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Target target = db.Targets.Find(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        // POST: Targets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Target target = db.Targets.Find(id);
            db.Targets.Remove(target);
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
        [HttpGet]
        public JsonResult ValidateYear(int year, int quarter, int region)
        {

            bool has = false;

            List<KPI> kpi = db.KPIs.Where(x => x.Year == year && x.Quarter == quarter && x.RegionId == region).ToList();

            if (kpi.Count != 0)
            {
                has = true;
            }


            return Json(new { result = has }, JsonRequestBehavior.AllowGet);



        }
        [HttpGet]
        public JsonResult checkYear(int year)
        {

            bool has = false;

            List<Target> _target = db.Targets.ToList();

            foreach (var item in _target)
            {

                if (year < item.YearStart || year < item.YearEnd)
                {
                    has = true;
                    return Json(new { result = has }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    int tempArrayCount = 0;
                    for (int count = item.YearStart - 1; count < item.YearEnd; count++)
                    {
                        tempArrayCount++;
                    }

                    int[] tempYearArray = new int[tempArrayCount];

                    for (int value = item.YearStart; value < item.YearEnd + 1; value++)
                    {

                        tempYearArray[value - item.YearStart ] = value;
                    }

                    has = tempYearArray.Contains(year);

                }


            }


            return Json(new { result = has }, JsonRequestBehavior.AllowGet);



        }

    }
}
