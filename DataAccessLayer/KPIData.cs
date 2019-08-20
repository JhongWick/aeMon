using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccessLayer
{

    public class KPIData
    {

        public static int GetSeedRegionPerYear(int RegionId, int Year)
        {
            using (DBContext Context = new DBContext())
            {

                List<KPI> KPIs = Context.KPIs.Where(x => x.RegionId == RegionId && x.Year == Year).ToList();
                int Total = 0;
                int DA = 0;
                int DENR_NGP = 0;
                int PCA_Kaanib = 0;
                int DAR = 0;
                foreach (var item in KPIs)
                {
                    DA = DA + item.DA;
                    DENR_NGP = DENR_NGP + item.DENR_NGP;
                    PCA_Kaanib = PCA_Kaanib + item.PCA_Kaanib;
                    DAR = DAR + item.DAR;
                }
                Total = DA + DENR_NGP + PCA_Kaanib + DAR;
                return Total;
            }
        }
        public static int ALlSeeds()
        {
            using (DBContext Context = new DBContext())
            {


                int Total = 0;
                int DA = 0;
                int DENR_NGP = 0;
                int PCA_Kaanib = 0;
                int DAR = 0;
                int[] yearArray = getCurrentTarget();
                foreach (int year in yearArray)
                {
                    List<KPI> KPIs = Context.KPIs.Where(x => x.Year == year).ToList();
                    foreach (var item in KPIs)
                    {
                        DA = DA + item.DA;
                        DENR_NGP = DENR_NGP + item.DENR_NGP;
                        PCA_Kaanib = PCA_Kaanib + item.PCA_Kaanib;
                        DAR = DAR + item.DAR;
                    }
                }



                Total = DA + DENR_NGP + PCA_Kaanib + DAR;
                return Total;
            }
        }
        public static int AllFarmers()
        {
            using (DBContext Context = new DBContext())
            {

                int Total = 0;
                int[] yearArray = getCurrentTarget();
                foreach (int year in yearArray)
                {
                    List<KPI> KPIs = Context.KPIs.Where(x => x.Year == year).ToList();
                    foreach (var item in KPIs)
                    {
                        int temp = item.Male + item.Female;
                        Total = Total + temp;

                    }
                }
                return Total;
            }
        }
        public static int AllFarms()
        {
            using (DBContext Context = new DBContext())
            {

                int Total = 0;
                int[] yearArray = getCurrentTarget();
                foreach (int year in yearArray)
                {
                    List<KPI> KPIs = Context.KPIs.Where(x => x.Year == year).ToList();
                    foreach (var item in KPIs)
                    {

                        Total = Total + item.NoOfFarms;

                    }
                }
                return Total;
            }
        }
        public static int AllJobs()
        {
            using (DBContext Context = new DBContext())
            {

                int Total = 0;
                int[] yearArray = getCurrentTarget();
                foreach (int year in yearArray)
                {
                    List<KPI> KPIs = Context.KPIs.Where(x => x.Year == year).ToList();
                    foreach (var item in KPIs)
                    {

                        Total = Total + item.JobsCreated;

                    }
                }
                return Total;
            }
        }
        public static int AllProductions()
        {
            using (DBContext Context = new DBContext())
            {

                int Total = 0;
                int[] yearArray = getCurrentTarget();
                foreach (int year in yearArray)
                {
                    List<KPI> KPIs = Context.KPIs.Where(x => x.Year == year).ToList();
                    foreach (var item in KPIs)
                    {

                        Total = Total + item.Production;

                    }
                }
                return Total;
            }
        }
        public static int AllTrees()
        {
            using (DBContext Context = new DBContext())
            {

                int Total = 0;
                int[] yearArray = getCurrentTarget();
                foreach (int year in yearArray)
                {
                    List<KPI> KPIs = Context.KPIs.Where(x => x.Year == year).ToList();
                    foreach (var item in KPIs)
                    {

                        Total = Total + item.NoOfTrees;

                    }
                }
                return Total;
            }
        }
        public static int AllCommunities()
        {
            using (DBContext Context = new DBContext())
            {
                List<Farms> Farms = Context.Farms.ToList();



                return Farms.Count();
            }
        }
        public static int[] getCurrentTarget()
        {
            bool has = false;
            int year = DateTime.Now.Year;
            Target _currentTarget = new Target();
            int tempArrayCount = 0;
            int[] tempYearArray;
            using (DBContext Context = new DBContext())
            {

                List<Target> _ListTarget = Context.Targets.ToList();

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

                    has = tempYearArray.Contains(year);
                    if (has)
                    {

                        _currentTarget = Context.Targets.Find(item.TargetId);
                        return tempYearArray;
                    }

                }
                tempYearArray = new int[0];
                return tempYearArray;
            }
        }

       
    }


}
