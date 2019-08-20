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
    public class KPIsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: KPIs
        public ActionResult Index()
        {
            return View(db.KPIs.ToList());
        }

        // GET: KPIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kPI = db.KPIs.Find(id);
            if (kPI == null)
            {
                return HttpNotFound();
            }
            return View(kPI);
        }
        public ActionResult Dashboard()
        {



            int[] year = KPIData.getCurrentTarget();

            int[] Hectar = new int[year.Count()];
            int[] Variety = new int[year.Count()];
            int[] VolumeMarket = new int[year.Count()];
            int[] VolumeInternational = new int[year.Count()];
            int[] VolumeSoldMarket = new int[year.Count()];
            int[] VolumeSoldInternational = new int[year.Count()];
            int[] Male = new int[year.Count()];
            int[] Female = new int[year.Count()];
            int[] MunicipalitiesEngaged = new int[year.Count()];
            int[] NumberOfNurseries = new int[year.Count()];
            int[] NoOfPostharvest = new int[year.Count()];
            int[] IncomeGenerated = new int[year.Count()];
            int[] SMEs = new int[year.Count()];
            int[] JobsCreated = new int[year.Count()];
            int[] NoOfFundingAssistance = new int[year.Count()];
            int[] NoOfFundingInstitutions = new int[year.Count()];
            int[] NoOfPoliciReforms = new int[year.Count()];
            int[] DA = new int[year.Count()];
            int[] DENR_NGP = new int[year.Count()];
            int[] PCA_Kaanib = new int[year.Count()];
            int[] DAR = new int[year.Count()];
            int[] Trainings = new int[year.Count()];
            int[] FarmesrsTrained = new int[year.Count()];
            int[] IECMaterials = new int[year.Count()];
            int[] LinkagesLocal = new int[year.Count()];
            int[] LinkagesInternational = new int[year.Count()];
            int[] DiseasesManagement = new int[year.Count()];
            int[] GoodAgriculturalPractices = new int[year.Count()];
            int[] CacaoFarmsCertified = new int[year.Count()];
            int[] NurseriesAccredited = new int[year.Count()];
            int[] ModelFarms = new int[year.Count()];
            int[] ResearchWorkDeveloped = new int[year.Count()];


            List<KPI> _kpiList = db.KPIs.ToList();
            int counter = 0;
            List<KPI> NEW_kpiList = new List<KPI>();
            foreach (int item in year)
            {

                int TempHectar = 0;

                int TempVolumeMarket = 0;
                int TempVolumeInternational = 0;
                int TempVolumeSoldMarket = 0;
                int TempVolumeSoldInternational = 0;
                int TempMale = 0;
                int TempFemale = 0;
                int TempMunicipalitiesEngaged = 0;
                int TempNumberOfNurseries = 0;
                int TempNoOfPostharvest = 0;
                int TempIncomeGenerated = 0;
                int TempSMEs = 0;
                int TempJobsCreated = 0;
                int TempNoOfFundingAssistance = 0;
                int TempNoOfFundingInstitutions = 0;
                int TempNoOfPoliciReforms = 0;
                int TempDA = 0;
                int TempDENR_NGP = 0;
                int TempPCA_Kaanib = 0;
                int TempDAR = 0;


                int TempTrainings = 0;
                int TempFarmesrsTrained = 0;
                int TempIECMaterials = 0;
                int TempLinkagesLocal = 0;
                int TempLinkagesInternational = 0;
                int TempDiseasesManagement = 0;
                int TempGoodAgriculturalPractices = 0;
                int TempCacaoFarmsCertified = 0;
                int TempNurseriesAccredited = 0;
                int TempModelFarms = 0;
                int TempResearchWorkDeveloped = 0;


                List<KPI> kpi = _kpiList.Where(x => x.Year == item).ToList();
                foreach (var TempKpi in kpi)
                {


                    TempHectar += TempKpi.Hectar;


                    int TVM = TempKpi.VolumeMarket + TempKpi.VolumeInternational;
                    TempVolumeMarket += TVM;
                    //TempVolumeInternational += TempKpi.VolumeInternational;
                    int TVS = TempKpi.VolumeSoldMarket + TempKpi.VolumeSoldInternational;
                    TempVolumeSoldMarket += TVS;
                    //TempVolumeSoldInternational += TempKpi.VolumeSoldInternational;
                    int TM = TempKpi.Male + TempKpi.Female;
                    TempMale += TM;
                    //TempFemale += TempKpi.Female;
                    TempMunicipalitiesEngaged += TempKpi.MunicipalitiesEngaged;
                    TempNumberOfNurseries += TempKpi.NumberOfNurseries;
                    TempNoOfPostharvest += TempKpi.NoOfPostharvest;
                    TempIncomeGenerated += TempKpi.IncomeGenerated;
                    TempSMEs += TempKpi.SMEs;
                    TempJobsCreated += TempKpi.JobsCreated;
                    TempNoOfFundingAssistance += TempKpi.NoOfFundingAssistance;
                    TempNoOfFundingInstitutions += TempKpi.NoOfFundingInstitutions;
                    TempNoOfPoliciReforms += TempKpi.NoOfPoliciReforms;
                    int TDA = TempKpi.DA + TempKpi.DENR_NGP + TempKpi.PCA_Kaanib + TempKpi.DAR;
                    TempDA += TDA;
                    //TempDENR_NGP += TempKpi.DENR_NGP;
                    //TempPCA_Kaanib += TempKpi.PCA_Kaanib;
                    //TempDAR += TempKpi.DAR;

                    TempTrainings += TempKpi.Trainings;
                    TempFarmesrsTrained += TempKpi.FarmesrsTrained;
                    TempIECMaterials += TempKpi.IECMaterials;
                    int TLL = TempKpi.LinkagesLocal + TempKpi.LinkagesInternational;
                    TempLinkagesLocal += TLL;
                    //TempLinkagesInternational += TempKpi.LinkagesInternational;
                    TempDiseasesManagement += TempKpi.DiseasesManagement;
                    TempGoodAgriculturalPractices += TempKpi.GoodAgriculturalPractices;
                    TempCacaoFarmsCertified += TempKpi.CacaoFarmsCertified;
                    TempNurseriesAccredited += TempKpi.NurseriesAccredited;
                    TempModelFarms += TempKpi.ModelFarms;
                    TempResearchWorkDeveloped += TempKpi.ResearchWorkDeveloped;



                }

                Hectar[counter] = TempHectar;

                VolumeMarket[counter] = TempVolumeMarket;
                VolumeInternational[counter] = TempVolumeInternational;
                VolumeSoldMarket[counter] = TempVolumeSoldMarket;
                VolumeSoldInternational[counter] = TempVolumeSoldInternational;
                Male[counter] = TempMale;
                Female[counter] = TempFemale;
                MunicipalitiesEngaged[counter] = TempMunicipalitiesEngaged;
                NumberOfNurseries[counter] = TempNumberOfNurseries;
                NoOfPostharvest[counter] = TempNoOfPostharvest;
                IncomeGenerated[counter] = TempIncomeGenerated;
                SMEs[counter] = TempSMEs;
                JobsCreated[counter] = TempJobsCreated;
                NoOfFundingAssistance[counter] = TempNoOfFundingAssistance;
                NoOfFundingInstitutions[counter] = TempNoOfFundingInstitutions;
                NoOfPoliciReforms[counter] = TempNoOfPoliciReforms;
                DA[counter] = TempDA;
                DENR_NGP[counter] = TempDENR_NGP;
                PCA_Kaanib[counter] = TempPCA_Kaanib;
                DAR[counter] = TempDAR;
                Trainings[counter] = TempTrainings;
                FarmesrsTrained[counter] = TempFarmesrsTrained;
                IECMaterials[counter] = TempIECMaterials;
                LinkagesLocal[counter] = TempLinkagesLocal;
                LinkagesInternational[counter] = TempLinkagesInternational;
                DiseasesManagement[counter] = TempDiseasesManagement;
                GoodAgriculturalPractices[counter] = TempGoodAgriculturalPractices;
                CacaoFarmsCertified[counter] = TempCacaoFarmsCertified;
                NurseriesAccredited[counter] = TempNurseriesAccredited;
                ModelFarms[counter] = TempModelFarms;
                ResearchWorkDeveloped[counter] = TempResearchWorkDeveloped;
                counter++;


            }

            ViewBag.Year_array = year; ;

            ViewBag.Hectar_Array = Hectar;

            ViewBag.VolumeMarket_Array = VolumeMarket;
            ViewBag.VolumeInternational_Array = VolumeInternational;
            ViewBag.VolumeSoldMarket_Array = VolumeSoldMarket;
            ViewBag.VolumeSoldInternational_Array = VolumeSoldInternational;
            ViewBag.Male_Array = Male;
            ViewBag.Female_Array = Female;
            ViewBag.MunicipalitiesEngaged_Array = MunicipalitiesEngaged;
            ViewBag.NumberOfNurseries_Array = NumberOfNurseries;
            ViewBag.NoOfPostharvest_Array = NoOfPostharvest;
            ViewBag.IncomeGenerated_Array = IncomeGenerated;
            ViewBag.SMEs_Array = SMEs;
            ViewBag.JobsCreated_Array = JobsCreated;
            ViewBag.NoOfFundingAssistance_Array = NoOfFundingAssistance;
            ViewBag.NoOfFundingInstitutions_Array = NoOfFundingInstitutions;
            ViewBag.NoOfPoliciReforms_Array = NoOfPoliciReforms;
            ViewBag.DA_Array = DA;
            ViewBag.DENR_NGP_Array = DENR_NGP;
            ViewBag.PCA_Kaanib_Array = PCA_Kaanib;
            ViewBag.DAR_Array = DAR;
            ViewBag.Trainings_Array = Trainings;
            ViewBag.FarmesrsTrained_Array = FarmesrsTrained;
            ViewBag.IECMaterials_Array = IECMaterials;
            ViewBag.LinkagesLocal_Array = LinkagesLocal;
            ViewBag.LinkagesInternational_Array = LinkagesInternational;
            ViewBag.DiseasesManagement_Array = DiseasesManagement;
            ViewBag.GoodAgriculturalPractices_Array = GoodAgriculturalPractices;
            ViewBag.CacaoFarmsCertified_Array = CacaoFarmsCertified;
            ViewBag.NurseriesAccredited_Array = NurseriesAccredited;
            ViewBag.ModelFarms_Array = ModelFarms;
            ViewBag.ResearchWorkDeveloped_Array = ResearchWorkDeveloped;

            return View(db.KPIs.ToList());
        }
        [HttpGet]
        
        public ActionResult ValidateYear(int year, int quarter, int region)
        {

            bool has = false;

            List<KPI> kpi = db.KPIs.Where(x=>x.Year == year && x.Quarter == quarter && x.RegionId == region).ToList();

            if (kpi.Count != 0)
            {
                has = true;
                return Json(new { result = has }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = has }, JsonRequestBehavior.AllowGet);
        }
        // GET: KPIs/Create
        public ActionResult Create()
        {
            int region = DataAccessLayer.UserData.Fetch(@Authentication.CurrentUser.UserId).Region;
            ViewBag.Farms = db.Farms.Where(x => x.RegionId == region).ToList();
            ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 10, 30).Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            });
            return View();
        }

        // POST: KPIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KPIId,UniqueId,Name,Category,Description,RegionId,Quarter,Year,DateAndTime,UserId,Hectar,NoOfFarms,NoOfTrees,Production,Variety,VolumeMarket,VolumeInternational,VolumeSoldMarket,VolumeSoldInternational,Male,Female,MunicipalitiesEngaged,NoOfPostharvest,IncomeGenerated,SMEs,JobsCreated,NoOfFundingAssistance,NoOfFundingInstitutions,NoOfPoliciReforms,DA,DENR_NGP,PCA_Kaanib,DAR,Trainings,FarmesrsTrained,IECMaterials,LinkagesLocal,LinkagesInternational,DiseasesManagement,GoodAgriculturalPractices,CacaoFarmsCertified,NurseriesAccredited,NumberOfNurseries,ModelFarms,ResearchWorkDeveloped")] KPI kPI)
        {

            ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 10, 30).ToList();

            kPI.UserId = Convert.ToInt32(Authentication.CurrentUser.UserId);
            kPI.UniqueId = Guid.NewGuid();
            kPI.Name = UserData.GetUserCompleteName(kPI.UserId);
            kPI.Category = 0;
            kPI.RegionId = UserData.GetUserRegion(kPI.UserId);
            kPI.DateAndTime = DateTime.Now;
            db.KPIs.Add(kPI);
            db.SaveChanges();

            return RedirectToAction("Index");



        }

        // GET: KPIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kPI = db.KPIs.Find(id);
            if (kPI == null)
            {
                return HttpNotFound();
            }



            ViewBag.Farms = db.Farms.Where(x => x.RegionId == kPI.RegionId).ToList();
            //ViewBag.Year = new SelectList(Enumerable.Range(DateTime.Now.Year - 10, 30).Select(x => new SelectListItem
            //{
            //    Value = x.ToString(),
            //    Text = x.ToString()
            //}),kPI.Year);
            //ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 10, 30).ToList();
            //ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 10, 30).Select(x => new SelectListItem
            //{
            //    Value = x.ToString(),
            //    Text= x.ToString()
            //});
            return View(kPI);
        }

        // POST: KPIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KPIId,UniqueId,Name,Category,Description,RegionId,Quarter,Year,DateAndTime,UserId,Hectar,NoOfFarms,NoOfTrees,Production,Variety,VolumeMarket,VolumeInternational,VolumeSoldMarket,VolumeSoldInternational,Male,Female,MunicipalitiesEngaged,NoOfPostharvest,IncomeGenerated,SMEs,JobsCreated,NoOfFundingAssistance,NoOfFundingInstitutions,NoOfPoliciReforms,DA,DENR_NGP,PCA_Kaanib,DAR,Trainings,FarmesrsTrained,IECMaterials,LinkagesLocal,LinkagesInternational,DiseasesManagement,GoodAgriculturalPractices,CacaoFarmsCertified,NurseriesAccredited,ModelFarms,ResearchWorkDeveloped")] KPI kPI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kPI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Farms = db.Farms.Where(x => x.RegionId == kPI.RegionId).ToList();
            ViewBag.Year = Enumerable.Range(DateTime.Now.Year - 10, 30).ToList();
            return View(kPI);
        }

        // GET: KPIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KPI kPI = db.KPIs.Find(id);
            if (kPI == null)
            {
                return HttpNotFound();
            }
            return View(kPI);
        }

        // POST: KPIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KPI kPI = db.KPIs.Find(id);
            db.KPIs.Remove(kPI);
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
    }
}
