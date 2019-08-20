using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserModel
    {
        public int UserId { get; set; }
        public Guid UniqueId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnabled { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public string Position { get; set; }
        public int DICTDivisionId { get; set; }
        public int DICTSectionId { get; set; }
        public int DICTServiceId { get; set; }
    }
}
