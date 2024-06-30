using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using PawMates.net.Models;
using PawMates.net.Interfaces;

public class FileUploadController : Controller
{

private readonly IImageStorageService _imageStorageService;

public FileUploadController(IImageStorageService imageStorageService)
{
    _imageStorageService = imageStorageService;
}



    [HttpPost("upload")]
public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
{
    if (image == null || image.Length == 0)
        return BadRequest("No file uploaded.");

    var filePath = await _imageStorageService.SaveImageAsync(image);
    return Ok(new { Path = filePath });
}

}
