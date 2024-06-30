using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawMates.net.Interfaces;

namespace PawMates.net.Service
{
   public class LocalImageStorageService : IImageStorageService
{
    private readonly string _storagePath;

    public LocalImageStorageService(IConfiguration configuration)
    {
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["StorageSettings:ImagePath"]);
        if (!Directory.Exists(_storagePath))
            Directory.CreateDirectory(_storagePath);
    }

    public async Task<string> SaveImageAsync(IFormFile file)
    {
        var filePath = Path.Combine(_storagePath, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath;
    }
}

}