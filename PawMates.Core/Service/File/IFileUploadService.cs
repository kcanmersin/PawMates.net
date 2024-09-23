using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);
        Task<bool> DeleteFileAsync(string filePath);
    }

