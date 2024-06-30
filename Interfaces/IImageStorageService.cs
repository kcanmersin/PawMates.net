using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMates.net.Interfaces
{
    public interface IImageStorageService
    {
          Task<string> SaveImageAsync(IFormFile file);
    }
}