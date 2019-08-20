using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string ModuleController { get; set; }
        public string ModuleAction { get; set; }
        public bool IsDeleted { get; set; }
    }
}
