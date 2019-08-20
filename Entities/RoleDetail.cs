using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoleDetail
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        // public virtual Role Role { get; set; }
        public int ModuleId { get; set; }
        // public virtual Module Module { get; set; }
        public bool IsAllowed { get; set; }
        //public virtual RoleDetail RoleDetails { get; set; }
    }
}
