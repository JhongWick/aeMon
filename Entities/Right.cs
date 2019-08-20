using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Right
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ModuleId { get; set; }
        public bool IsAllowed { get; set; }
    }
}
