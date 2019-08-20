using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class ModuleModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int BelongsTo { get; set; }
        public int Branch { get; set; }
        public bool IsAllowed { get; set; }
    }

}
