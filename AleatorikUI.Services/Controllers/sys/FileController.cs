using AleatorikUI.Services.DTO.exp;
using AleatorikUI.Services.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sys;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;
    private string _tempFilePath = @"C:\Temp\RestFile";

    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/api/GetFile")]
    public IEnumerable<object> GetFile()
    {
        try
        {
            var files = FileHelper.GetFileList(_tempFilePath);
            return files;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<TodoInfo>();
        }

    }

    [HttpPost("/api/UploadFile")]
    public async Task<IActionResult> UploadFile(List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
        {
            return BadRequest("No file selected");
        }

        _logger.LogInformation("file : {}", string.Join(',', files.Select(x => x.FileName)));

        long size = files.Sum(f => f.Length);

        try
        {
            if (Directory.Exists(_tempFilePath) == false)
            {
                Directory.CreateDirectory(_tempFilePath);
            }

            foreach (var file in files)
            {
                var filePath = Path.Combine(_tempFilePath, Path.GetRandomFileName());

                if (file.Length > 0)
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            return Ok(new { count = files.Count, size });
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return BadRequest("Error occurred. Please, Check log for detail");
        }
    }
}