using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Farms
    {
        [Key]
        public int FarmsId { get; set; }
        public Guid UniqueId { get; set; }
        public int KPIId { get; set; }
        public int RegionId { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public double Latitude { get; set; }
        public double Longititude { get; set; }
        public string completeAddress { get; set; }
        public bool IsActive { get; set; }

    }
}