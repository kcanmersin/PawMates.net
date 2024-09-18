using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity
{
    public class PostMedia
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; } 
        public string FilePath { get; set; } 
        public MediaType MediaType { get; set; } 
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }



}
