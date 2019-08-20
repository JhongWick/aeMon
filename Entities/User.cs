using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public Guid UniqueId { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameExt { get; set; }
        public string Password { get; set; }
        public int Region { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public byte[] UserPhoto { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayName("File")]
        public Guid FileStorageId { get; set; }
        [DisplayName("File")]
        [ForeignKey("FileStorageId")]
        public FileStorage FileStorages { get; set; }


    }
}
