using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PawMates.Core.Service.File;

public class FileUploadService : IFileUploadService
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<FileUploadService> _logger;

    public FileUploadService(IWebHostEnvironment env, ILogger<FileUploadService> logger)
    {
        _env = env;
        _logger = logger;
    }

    public async Task<string> UploadFileAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is null or empty");

        var fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension == null || !new[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(fileExtension.ToLower()))
            throw new ArgumentException("Invalid file extension");

        var fileName = $"{Guid.NewGuid()}{fileExtension}";

        var uploadsFolderPath = Path.Combine(_env.WebRootPath, folderName);
        if (!Directory.Exists(uploadsFolderPath))
        {
            Directory.CreateDirectory(uploadsFolderPath);
        }

        var filePath = Path.Combine(uploadsFolderPath, fileName);

        try
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _logger.LogInformation($"File uploaded successfully: {filePath}");

            return $"/{folderName}/{fileName}";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while uploading file.");
            throw new Exception("Error occurred while uploading the file.");
        }
    }

    public async Task<bool> DeleteFileAsync(string filePath)
    {
        try
        {
            var fullPath = Path.Combine(_env.WebRootPath, filePath.TrimStart('/'));

            if (File.Exists(fullPath)) 
            {
                File.Delete(fullPath); 
                _logger.LogInformation($"File deleted successfully: {fullPath}");
                return true;
            }
            else
            {
                _logger.LogWarning($"File not found: {fullPath}");
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while deleting file.");
            throw new Exception("Error occurred while deleting the file.");
        }
    }
}
