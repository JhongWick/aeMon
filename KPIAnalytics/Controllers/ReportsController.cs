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
using KPIAnalytics.Models;

namespace KPIAnalytics.Controllers
{
    [KPIAuthorize]

    [UserAuth]
    public class ReportsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: KPIs
        public ActionResult Index()
        {
            return View(db.Targets.ToList());
        }
        public ActionResult Admin()
        {
            return View(db.Targets.ToList());
        }

        [HttpGet]
        // GET: KPIs/Details/5

        public ActionResult UserDocs(int target, int report, int? quarter, int year)
        {
            Target _target = db.Targets.Find(target);
            List<KPI> _kpiList = new List<KPI>();

            int role = UserRoleData.GetByUserId(Authentication.CurrentUser.UserId).RoleId;
            if (role == 1 || role == 2) // Admin
            {
                if (report == 1)
                {

                    if (quarter != 0)
                    {
                        ViewBag.Year = year;
                        ViewBag.Quarter = quarter;
                        _kpiList = db.KPIs.Where(x => x.Year == year && x.Quarter == quarter).ToList();
                        return View("~/Views/Reports/User/ProductionQuarterly.cshtml", _kpiList);
                    }
                    else
                    {
                        double[] production = new double[4];
                        int[] hectar = new int[4];
                        int[] income = new int[4];

                        int counter = 0;
                        _kpiList = db.KPIs.Where(x => x.Year == year).ToList();

                        int[] q = { 1, 2, 3, 4 };
                        double tempProduction = 0;
                        string tempRegion;
                        string tempCode;
                        int temphectar = 0;
                        int tempincome = 0;
                        ViewBag.Year = year;
                        List<ProductionQuarterly> PQ = new List<ProductionQuarterly>();

                        var AvailableRegionId = _kpiList.GroupBy(i => i.RegionId).OrderByDescending(g => g.Count()).Take(20).Select(g => g.Key);


                        foreach (var item in AvailableRegionId)
                        {

                            tempProduction = 0;
                            tempRegion = "";
                            tempCode = "";
                            temphectar = 0;
                            tempincome = 0;


                            List<KPI> kpiQuarter = _kpiList.Where(x => x.RegionId == item).ToList();
                            foreach (var kpiItem in kpiQuarter)
                            {
                                tempRegion = RegionData.returnName(kpiItem.RegionId);
                                tempCode = RegionData.Fetch(kpiItem.RegionId).Code;
                                temphectar = temphectar + kpiItem.Hectar;
                                tempProduction = tempProduction + (kpiItem.Male + kpiItem.Production);
                                tempincome = tempincome + kpiItem.IncomeGenerated;
                            }
                            counter++;
                            ProductionQuarterly newPQ = new ProductionQuarterly();
                            newPQ.id = counter;
                            newPQ.Region = tempRegion.ToString();
                            newPQ.Code = tempCode.ToString();
                            newPQ.Production = tempProduction * .001;
                            newPQ.AreaPlanted = temphectar;
                            newPQ.income = tempincome;
                            PQ.Add(newPQ);

                        }


                        return View("~/Views/Reports/User/Production.cshtml", PQ);
                    }



                }
                else if (report == 2)
                {
                    if (quarter != 0)
                    {
                        ViewBag.Year = year;
                        ViewBag.Quarter = quarter;
                        ViewBag.Region = db.Regions.ToList();
                        _kpiList = db.KPIs.Where(x => x.Year == year && x.Quarter == quarter).ToList();
                        return View("~/Views/Reports/User/PerformanceQuarterly.cshtml", _kpiList);
                    }
                    else
                    {
                        ViewBag.Year = year;
                        List<Region> region = db.Regions.ToList();
                        ViewBag.Region = region;
                        _kpiList = db.KPIs.Where(x => x.Year == year).ToList();
                        int counter = 0;
                        List<KPI> NEW_kpiList = new List<KPI>();
                        foreach (var regionItem in region)
                        {

                            KPI newKPI = new KPI();
                            List<KPI> NEW_Quarter_kpiList = _kpiList.Where(x => x.RegionId == regionItem.RegionId).ToList();
                            foreach (var newQuarterItem in NEW_Quarter_kpiList)
                            {
                                KPI TempKpi = db.KPIs.Find(newQuarterItem.KPIId);

                                newKPI.KPIId = counter;
                                newKPI.UniqueId = Guid.NewGuid();
                                newKPI.Name = null;
                                newKPI.Category = 0;
                                newKPI.Description = null;
                                newKPI.RegionId = regionItem.RegionId;
                                newKPI.Quarter = 0;
                                newKPI.Year = year;
                                newKPI.DateAndTime = DateTime.Now;
                                newKPI.UserId = 0;
                                newKPI.Hectar += TempKpi.Hectar;
                                newKPI.NoOfFarms += TempKpi.NoOfFarms;
                                newKPI.NoOfTrees += TempKpi.NoOfTrees;
                                newKPI.Production += TempKpi.Production;
                                newKPI.Variety = TempKpi.Variety;
                                newKPI.VolumeMarket += TempKpi.VolumeMarket;
                                newKPI.VolumeInternational += TempKpi.VolumeInternational;
                                newKPI.VolumeSoldMarket += TempKpi.VolumeSoldMarket;
                                newKPI.VolumeSoldInternational += TempKpi.VolumeSoldInternational;
                                newKPI.Male += TempKpi.Male;
                                newKPI.Female += TempKpi.Female;
                                newKPI.MunicipalitiesEngaged += TempKpi.MunicipalitiesEngaged;
                                newKPI.NumberOfNurseries += TempKpi.NumberOfNurseries;
                                newKPI.NoOfPostharvest += TempKpi.NoOfPostharvest;
                                newKPI.IncomeGenerated += TempKpi.IncomeGenerated;
                                newKPI.SMEs += TempKpi.SMEs;
                                newKPI.JobsCreated += TempKpi.JobsCreated;
                                newKPI.NoOfFundingAssistance += TempKpi.NoOfFundingAssistance;
                                newKPI.NoOfFundingInstitutions += TempKpi.NoOfFundingInstitutions;
                                newKPI.NoOfPoliciReforms += TempKpi.NoOfPoliciReforms;
                                newKPI.DA += TempKpi.DA;
                                newKPI.DENR_NGP += TempKpi.DENR_NGP;
                                newKPI.PCA_Kaanib += TempKpi.PCA_Kaanib;
                                newKPI.DAR += TempKpi.DAR;
                                newKPI.Trainings += TempKpi.Trainings;
                                newKPI.FarmesrsTrained += TempKpi.FarmesrsTrained;
                                newKPI.IECMaterials += TempKpi.IECMaterials;
                                newKPI.LinkagesLocal += TempKpi.LinkagesLocal;
                                newKPI.LinkagesInternational += TempKpi.LinkagesInternational;
                                newKPI.DiseasesManagement += TempKpi.DiseasesManagement;
                                newKPI.GoodAgriculturalPractices += TempKpi.GoodAgriculturalPractices;
                                newKPI.CacaoFarmsCertified += TempKpi.CacaoFarmsCertified;
                                newKPI.NurseriesAccredited += TempKpi.NurseriesAccredited;
                                newKPI.ModelFarms += TempKpi.ModelFarms;
                                newKPI.ResearchWorkDeveloped += TempKpi.ResearchWorkDeveloped;



                            }

                            counter++;

                            NEW_kpiList.Add(newKPI);
                        }


                        return View("~/Views/Reports/User/Performance.cshtml", NEW_kpiList);
                    }

                }
                else if (report == 3)
                {
                    int[] years = getTargetYearInt(target);

                    ViewBag.Year = year;
                    List<Region> region = db.Regions.ToList();
                    ViewBag.Region = region;
                    _kpiList = db.KPIs.ToList();
                    int counter = 0;
                    List<KPI> NEW_kpiList = new List<KPI>();
                    foreach (int item in years)
                    {

                        KPI newKPI = new KPI();
                        List<KPI> NEW_Quarter_kpiList = _kpiList.Where(x => x.Year == item).ToList();
                        foreach (var newQuarterItem in NEW_Quarter_kpiList)
                        {
                            KPI TempKpi = db.KPIs.Find(newQuarterItem.KPIId);

                            newKPI.KPIId = counter;
                            newKPI.UniqueId = Guid.NewGuid();
                            newKPI.Name = null;
                            newKPI.Category = 0;
                            newKPI.Description = null;
                            newKPI.RegionId = 0;
                            newKPI.Quarter = 0;
                            newKPI.Year = item;
                            newKPI.DateAndTime = DateTime.Now;
                            newKPI.UserId = 0;
                            newKPI.Hectar += TempKpi.Hectar;
                            newKPI.NoOfFarms += TempKpi.NoOfFarms;
                            newKPI.NoOfTrees += TempKpi.NoOfTrees;
                            newKPI.Production += TempKpi.Production;
                            newKPI.Variety = TempKpi.Variety;
                            newKPI.VolumeMarket += TempKpi.VolumeMarket;
                            newKPI.VolumeInternational += TempKpi.VolumeInternational;
                            newKPI.VolumeSoldMarket += TempKpi.VolumeSoldMarket;
                            newKPI.VolumeSoldInternational += TempKpi.VolumeSoldInternational;
                            newKPI.Male += TempKpi.Male;
                            newKPI.Female += TempKpi.Female;
                            newKPI.MunicipalitiesEngaged += TempKpi.MunicipalitiesEngaged;
                            newKPI.NumberOfNurseries += TempKpi.NumberOfNurseries;
                            newKPI.NoOfPostharvest += TempKpi.NoOfPostharvest;
                            newKPI.IncomeGenerated += TempKpi.IncomeGenerated;
                            newKPI.SMEs += TempKpi.SMEs;
                            newKPI.JobsCreated += TempKpi.JobsCreated;
                            newKPI.NoOfFundingAssistance += TempKpi.NoOfFundingAssistance;
                            newKPI.NoOfFundingInstitutions += TempKpi.NoOfFundingInstitutions;
                            newKPI.NoOfPoliciReforms += TempKpi.NoOfPoliciReforms;
                            newKPI.DA += TempKpi.DA;
                            newKPI.DENR_NGP += TempKpi.DENR_NGP;
                            newKPI.PCA_Kaanib += TempKpi.PCA_Kaanib;
                            newKPI.DAR += TempKpi.DAR;
                            newKPI.Trainings += TempKpi.Trainings;
                            newKPI.FarmesrsTrained += TempKpi.FarmesrsTrained;
                            newKPI.IECMaterials += TempKpi.IECMaterials;
                            newKPI.LinkagesLocal += TempKpi.LinkagesLocal;
                            newKPI.LinkagesInternational += TempKpi.LinkagesInternational;
                            newKPI.DiseasesManagement += TempKpi.DiseasesManagement;
                            newKPI.GoodAgriculturalPractices += TempKpi.GoodAgriculturalPractices;
                            newKPI.CacaoFarmsCertified += TempKpi.CacaoFarmsCertified;
                            newKPI.NurseriesAccredited += TempKpi.NurseriesAccredited;
                            newKPI.ModelFarms += TempKpi.ModelFarms;
                            newKPI.ResearchWorkDeveloped += TempKpi.ResearchWorkDeveloped;



                        }

                        counter++;

                        NEW_kpiList.Add(newKPI);
                    }
                    ViewBag.Year = _target.YearStart + " - " + _target.YearEnd;
                    ViewBag.Year_array = years;
                    return View("~/Views/Reports/User/National.cshtml", NEW_kpiList);
                }
            }
            else if (role == 3) // user
            {
                int regionId = UserData.Fetch(Authentication.CurrentUser.UserId).Region;
                ViewBag.RegionCode = regionId;
                if (report == 4) // Accomplish
                {

                    if (quarter != 0)
                    {
                        ViewBag.Year = year;
                        ViewBag.Quarter = quarter;
                        _kpiList = db.KPIs.Where(x => x.Year == year && x.Quarter == quarter && x.RegionId == regionId).ToList();
                        return View("~/Views/Reports/Admin/AccomplishmentQuarterly.cshtml", _kpiList);
                    }
                    else
                    {
                        ViewBag.Year = year;

                        _kpiList = db.KPIs.Where(x => x.Year == year).ToList();
                        int counter = 0;
                        List<KPI> NEW_kpiList = new List<KPI>();

                        KPI newKPI = new KPI();
                        List<KPI> NEW_Quarter_kpiList = _kpiList.Where(x => x.RegionId == regionId).ToList();
                        foreach (var newQuarterItem in NEW_Quarter_kpiList)
                        {
                            KPI TempKpi = db.KPIs.Find(newQuarterItem.KPIId);

                            newKPI.KPIId = counter;
                            newKPI.UniqueId = Guid.NewGuid();
                            newKPI.Name = null;
                            newKPI.Category = 0;
                            newKPI.Description = null;
                            newKPI.RegionId = regionId;
                            newKPI.Quarter = 0;
                            newKPI.Year = year;
                            newKPI.DateAndTime = DateTime.Now;
                            newKPI.UserId = 0;
                            newKPI.Hectar += TempKpi.Hectar;
                            newKPI.NoOfFarms += TempKpi.NoOfFarms;
                            newKPI.NoOfTrees += TempKpi.NoOfTrees;
                            newKPI.Production += TempKpi.Production;
                            newKPI.Variety = TempKpi.Variety;
                            newKPI.VolumeMarket += TempKpi.VolumeMarket;
                            newKPI.VolumeInternational += TempKpi.VolumeInternational;
                            newKPI.VolumeSoldMarket += TempKpi.VolumeSoldMarket;
                            newKPI.VolumeSoldInternational += TempKpi.VolumeSoldInternational;
                            newKPI.Male += TempKpi.Male;
                            newKPI.Female += TempKpi.Female;
                            newKPI.MunicipalitiesEngaged += TempKpi.MunicipalitiesEngaged;
                            newKPI.NumberOfNurseries += TempKpi.NumberOfNurseries;
                            newKPI.NoOfPostharvest += TempKpi.NoOfPostharvest;
                            newKPI.IncomeGenerated += TempKpi.IncomeGenerated;
                            newKPI.SMEs += TempKpi.SMEs;
                            newKPI.JobsCreated += TempKpi.JobsCreated;
                            newKPI.NoOfFundingAssistance += TempKpi.NoOfFundingAssistance;
                            newKPI.NoOfFundingInstitutions += TempKpi.NoOfFundingInstitutions;
                            newKPI.NoOfPoliciReforms += TempKpi.NoOfPoliciReforms;
                            newKPI.DA += TempKpi.DA;
                            newKPI.DENR_NGP += TempKpi.DENR_NGP;
                            newKPI.PCA_Kaanib += TempKpi.PCA_Kaanib;
                            newKPI.DAR += TempKpi.DAR;
                            newKPI.Trainings += TempKpi.Trainings;
                            newKPI.FarmesrsTrained += TempKpi.FarmesrsTrained;
                            newKPI.IECMaterials += TempKpi.IECMaterials;
                            newKPI.LinkagesLocal += TempKpi.LinkagesLocal;
                            newKPI.LinkagesInternational += TempKpi.LinkagesInternational;
                            newKPI.DiseasesManagement += TempKpi.DiseasesManagement;
                            newKPI.GoodAgriculturalPractices += TempKpi.GoodAgriculturalPractices;
                            newKPI.CacaoFarmsCertified += TempKpi.CacaoFarmsCertified;
                            newKPI.NurseriesAccredited += TempKpi.NurseriesAccredited;
                            newKPI.ModelFarms += TempKpi.ModelFarms;
                            newKPI.ResearchWorkDeveloped += TempKpi.ResearchWorkDeveloped;



                        }

                        counter++;

                        NEW_kpiList.Add(newKPI);


                        return View("~/Views/Reports/Admin/Accomplishment.cshtml", NEW_kpiList);

                    }



                }
                if (report == 5) // Accomplishment   summary
                {
                    ViewBag.Year = year;
                    int[] q = { 1, 2, 3, 4, 5 };
                    _kpiList = db.KPIs.Where(x => x.Year == year).ToList();
                    int counter = 0;
                    List<KPI> NEW_kpiList = new List<KPI>();

                    KPI newKPI = new KPI();
                    List<KPI> NEW_Quarter_kpiList = _kpiList.Where(x => x.RegionId == regionId).ToList();
                    foreach (var newQuarterItem in NEW_Quarter_kpiList)
                    {
                        counter++;
                        KPI TempKpi = db.KPIs.Find(newQuarterItem.KPIId);

                        NEW_kpiList.Add(TempKpi);

                    }



                    

                    foreach (var newQuarterItem in NEW_Quarter_kpiList)
                    {
                        counter++;
                        KPI TempKpi = db.KPIs.Find(newQuarterItem.KPIId);

                        newKPI.KPIId = counter;
                        newKPI.UniqueId = Guid.NewGuid();
                        newKPI.Name = null;
                        newKPI.Category = 0;
                        newKPI.Description = null;
                        newKPI.RegionId = regionId;
                        newKPI.Quarter = counter;
                        newKPI.Year = year;
                        newKPI.DateAndTime = DateTime.Now;
                        newKPI.UserId = 0;
                        if(newQuarterItem.Quarter == 4)
                        {
                            newKPI.Hectar = TempKpi.Hectar;
                        }
                        else
                        {
                            newKPI.Hectar = 0;
                        }
                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.NoOfFarms = TempKpi.NoOfFarms;
                        }
                        else
                        {
                            newKPI.NoOfFarms = 0;
                        }
                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.NoOfTrees = TempKpi.NoOfTrees;
                        }
                        else
                        {
                            newKPI.NoOfTrees = 0;
                        }
                       
                        newKPI.Production += TempKpi.Production;
                        newKPI.Variety = TempKpi.Variety;
                        newKPI.VolumeMarket += TempKpi.VolumeMarket;
                        newKPI.VolumeInternational += TempKpi.VolumeInternational;
                        newKPI.VolumeSoldMarket += TempKpi.VolumeSoldMarket;
                        newKPI.VolumeSoldInternational += TempKpi.VolumeSoldInternational;

                        newKPI.Male += TempKpi.Male;
                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.Male = newKPI.Male / 4;
                        }
                        
                        newKPI.Female += TempKpi.Female;

                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.Female = newKPI.Female / 4;
                        }
                        newKPI.MunicipalitiesEngaged += TempKpi.MunicipalitiesEngaged;

                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.MunicipalitiesEngaged = newKPI.MunicipalitiesEngaged / 4;
                        }

                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.NumberOfNurseries = TempKpi.NumberOfNurseries;
                        }
                        else
                        {
                            newKPI.NumberOfNurseries = 0;
                        }

                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.NoOfPostharvest = TempKpi.NoOfPostharvest;
                        }
                        else
                        {
                            newKPI.NoOfPostharvest = 0;
                        }

                        newKPI.NoOfPostharvest += TempKpi.NoOfPostharvest;
                        newKPI.IncomeGenerated += TempKpi.IncomeGenerated;
                        newKPI.SMEs += TempKpi.SMEs;
                        newKPI.JobsCreated += TempKpi.JobsCreated;
                        newKPI.NoOfFundingAssistance += TempKpi.NoOfFundingAssistance;
                        newKPI.NoOfFundingInstitutions += TempKpi.NoOfFundingInstitutions;
                        newKPI.NoOfPoliciReforms += TempKpi.NoOfPoliciReforms;
                        newKPI.DA += TempKpi.DA;
                        newKPI.DENR_NGP += TempKpi.DENR_NGP;
                        newKPI.PCA_Kaanib += TempKpi.PCA_Kaanib;
                        newKPI.DAR += TempKpi.DAR;
                        newKPI.Trainings += TempKpi.Trainings;
                        newKPI.FarmesrsTrained += TempKpi.FarmesrsTrained;
                        newKPI.IECMaterials += TempKpi.IECMaterials;
                        newKPI.LinkagesLocal += TempKpi.LinkagesLocal;
                        newKPI.LinkagesInternational += TempKpi.LinkagesInternational;
                        newKPI.DiseasesManagement += TempKpi.DiseasesManagement;

                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.DiseasesManagement = newKPI.DiseasesManagement / 4;
                        }

                        newKPI.GoodAgriculturalPractices += TempKpi.GoodAgriculturalPractices;

                        if (newQuarterItem.Quarter == 4)
                        {
                            newKPI.GoodAgriculturalPractices = newKPI.GoodAgriculturalPractices / 4;
                        }

                        newKPI.CacaoFarmsCertified += TempKpi.CacaoFarmsCertified;
                        newKPI.NurseriesAccredited += TempKpi.NurseriesAccredited;
                        newKPI.ModelFarms += TempKpi.ModelFarms;
                        newKPI.ResearchWorkDeveloped += TempKpi.ResearchWorkDeveloped;



                    }

                    NEW_kpiList.Add(newKPI);

                    ViewBag.Quarter_array = q;
                    return View("~/Views/Reports/Admin/AccomplishmentReportSummary.cshtml", NEW_kpiList);
                }
                if (report == 6) // Regional Accomplishment   Report
                {
                    int[] years = getTargetYearInt(target);

                    ViewBag.Year = year;
                    
                    _kpiList = db.KPIs.ToList();
                    int counter = 0;
                    List<KPI> NEW_kpiList = new List<KPI>();
                    foreach (int item in years)
                    {

                        KPI newKPI = new KPI();
                        List<KPI> NEW_Quarter_kpiList = _kpiList.Where(x => x.Year == item && x.RegionId == regionId ).ToList();
                        foreach (var newQuarterItem in NEW_Quarter_kpiList)
                        {
                            KPI TempKpi = db.KPIs.Find(newQuarterItem.KPIId);

                            newKPI.KPIId = counter;
                            newKPI.UniqueId = Guid.NewGuid();
                            newKPI.Name = null;
                            newKPI.Category = 0;
                            newKPI.Description = null;
                            newKPI.RegionId = 0;
                            newKPI.Quarter = 0;
                            newKPI.Year = item;
                            newKPI.DateAndTime = DateTime.Now;
                            newKPI.UserId = 0;
                            newKPI.Hectar += TempKpi.Hectar;
                            newKPI.NoOfFarms += TempKpi.NoOfFarms;
                            newKPI.NoOfTrees += TempKpi.NoOfTrees;
                            newKPI.Production += TempKpi.Production;
                            newKPI.Variety = TempKpi.Variety;
                            newKPI.VolumeMarket += TempKpi.VolumeMarket;
                            newKPI.VolumeInternational += TempKpi.VolumeInternational;
                            newKPI.VolumeSoldMarket += TempKpi.VolumeSoldMarket;
                            newKPI.VolumeSoldInternational += TempKpi.VolumeSoldInternational;
                            newKPI.Male += TempKpi.Male;
                            newKPI.Female += TempKpi.Female;
                            newKPI.MunicipalitiesEngaged += TempKpi.MunicipalitiesEngaged;
                            newKPI.NumberOfNurseries += TempKpi.NumberOfNurseries;
                            newKPI.NoOfPostharvest += TempKpi.NoOfPostharvest;
                            newKPI.IncomeGenerated += TempKpi.IncomeGenerated;
                            newKPI.SMEs += TempKpi.SMEs;
                            newKPI.JobsCreated += TempKpi.JobsCreated;
                            newKPI.NoOfFundingAssistance += TempKpi.NoOfFundingAssistance;
                            newKPI.NoOfFundingInstitutions += TempKpi.NoOfFundingInstitutions;
                            newKPI.NoOfPoliciReforms += TempKpi.NoOfPoliciReforms;
                            newKPI.DA += TempKpi.DA;
                            newKPI.DENR_NGP += TempKpi.DENR_NGP;
                            newKPI.PCA_Kaanib += TempKpi.PCA_Kaanib;
                            newKPI.DAR += TempKpi.DAR;
                            newKPI.Trainings += TempKpi.Trainings;
                            newKPI.FarmesrsTrained += TempKpi.FarmesrsTrained;
                            newKPI.IECMaterials += TempKpi.IECMaterials;
                            newKPI.LinkagesLocal += TempKpi.LinkagesLocal;
                            newKPI.LinkagesInternational += TempKpi.LinkagesInternational;
                            newKPI.DiseasesManagement += TempKpi.DiseasesManagement;
                            newKPI.GoodAgriculturalPractices += TempKpi.GoodAgriculturalPractices;
                            newKPI.CacaoFarmsCertified += TempKpi.CacaoFarmsCertified;
                            newKPI.NurseriesAccredited += TempKpi.NurseriesAccredited;
                            newKPI.ModelFarms += TempKpi.ModelFarms;
                            newKPI.ResearchWorkDeveloped += TempKpi.ResearchWorkDeveloped;



                        }

                        counter++;

                        NEW_kpiList.Add(newKPI);
                    }
                    ViewBag.Year = _target.YearStart + " - " + _target.YearEnd;
                    ViewBag.Year_array = years;
                    
                    return View("~/Views/Reports/Admin/NationalAccomplishmentReport.cshtml", NEW_kpiList);
                }
            }




            return View("Index", db.Targets.ToList());
        }

        [HttpPost]
        public virtual ActionResult getTargetYear(int target)
        {
            int tempArrayCount = 0;
            int[] tempYearArray;
            using (DBContext Context = new DBContext())
            {

                List<Target> _ListTarget = Context.Targets.Where(x => x.TargetId == target).ToList();

                foreach (var item in _ListTarget)
                {
                    for (int count = item.YearStart - 1; count < item.YearEnd; count++)
                    {
                        tempArrayCount++;
                    }

                    tempYearArray = new int[tempArrayCount];

                    for (int value = item.YearStart; value < item.YearEnd + 1; value++)
                    {

                        tempYearArray[value - item.YearStart] = value;
                    }


                    return Json(new { data = tempYearArray.ToList(), JsonRequestBehavior.AllowGet });
                    //return tempYearArray;

                }
                tempYearArray = new int[0];
                return Json(new { data = tempYearArray.ToList(), JsonRequestBehavior.AllowGet });
                //return tempYearArray;
            }
        }
        [HttpGet]
        public int[] getTargetYearInt(int target)
        {
            int tempArrayCount = 0;
            int[] tempYearArray;
            using (DBContext Context = new DBContext())
            {

                List<Target> _ListTarget = Context.Targets.Where(x => x.TargetId == target).ToList();

                foreach (var item in _ListTarget)
                {
                    for (int count = item.YearStart - 1; count < item.YearEnd; count++)
                    {
                        tempArrayCount++;
                    }

                    tempYearArray = new int[tempArrayCount];

                    for (int value = item.YearStart; value < item.YearEnd + 1; value++)
                    {

                        tempYearArray[value - item.YearStart] = value;
                    }


                    return tempYearArray;

                }
                tempYearArray = new int[0];

                return tempYearArray;
            }
        }
    }

}
