using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FileStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid FileStorageId { get; set; }

        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public byte[] FileData { get; set; }

        public ICollection<Target> Target { get; set; } = new List<Target>();
        public ICollection<User> User { get; set; } = new List<User>();

        public ICollection<Storage> Storage { get; set; } = new List<Storage>();

    }
}
