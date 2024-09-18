using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Data.Entity
{
    public class CommentMedia
    {
        public Guid Id { get; set; }
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }

        public string FilePath { get; set; }
        public MediaType MediaType { get; set; } 

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }



}
