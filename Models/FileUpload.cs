using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Models
{
    public class FileUpload
    {
         [Required]
    [Display(Name = "File")]
    public IFormFile UploadedFile { get; set; }
    }
}