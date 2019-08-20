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
    public class Storage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid StorageId { get; set; }

        [Required]
        [DisplayName("Share Expiry Date")]
        public DateTime PostDate { get; set; }

        public bool StorageStatus { get; set; }

        [DisplayName("Owner")]
        public int UserId { get; set; }
        [DisplayName("Owner")]
        [ForeignKey("UserId")]
        public User User { get; set; }

        
        [DisplayName("File")]
        public Guid FileStorageId { get; set; }
        [DisplayName("File")]
        [ForeignKey("FileStorageId")]
        public FileStorage FileStorage { get; set; }

        
    }
}
