using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities
{
    public class Target
    {
        [Key]
        
        public int TargetId { get; set; }
        public Guid UniqueId { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public double MetricTonne { get; set; }
        public double Trees { get; set; }
        public double Farmers { get; set; }
        
        public double RegionI { get; set; }
        public double RegionII { get; set; }
        public double RegionIII { get; set; }
        public double RegionIVa { get; set; }
        public double RegionIVb { get; set; }
        public double RegionV { get; set; }
        public double RegionVI { get; set; }
        public double RegionVII { get; set; }
        public double RegionVIII { get; set; }
        public double RegionIX { get; set; }
        public double RegionX { get; set; }
        public double RegionXI { get; set; }
        public double RegionXII { get; set; }
        public double RegionXIII { get; set; }
        public double RegionNCR { get; set; }
        public double RegionCAR { get; set; }
        public double RegionARMMM { get; set; }

        [DisplayName("File")]
        public Guid FileStorageId { get; set; }
        [DisplayName("File")]
        [ForeignKey("FileStorageId")]
        public FileStorage FileStorages { get; set; }

    }
}
