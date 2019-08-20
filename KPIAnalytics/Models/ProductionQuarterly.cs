using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KPIAnalytics.Models
{
    public class ProductionQuarterly
    {
        public int id { get; set; }
        public string Region { get; set; }

        public string Code { get; set; }
        public int AreaPlanted { get; set; }
        public double Production { get; set; }
        public int income { get; set; }
        

    }
}