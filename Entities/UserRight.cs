using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserRight
    {
        [Key]
        public int UserRightId { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public bool IsAllowed { get; set; }
    }
}
