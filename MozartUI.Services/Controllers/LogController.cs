using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MozartUI.Services.Template.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger, IConfiguration configuration)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet("/api/GetLog/{fileName}")]
    public IEnumerable<string> GetLog(string fileName)
    {
        var result = new List<string>();
        try
        {
            if (fileName.EndsWith(".log") == false)
            {
                fileName += ".log";
            }

            var path = _configuration["AccessLog:LogDir"];

            using (var stream = System.IO. File.Open(Path.Combine(path, fileName), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    result.Add(line);
                }
            }
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return result;
        }
    }

    [HttpGet("/api/GetLog/{fileName}/{from}/{to}")]
    public IEnumerable<string> GetLog(string fileName, int from, int to)
    {
        var result = new List<string>();
        try
        {
            var path = _configuration["AccessLog:LogDir"];
            var index = 0;

            using (var stream = System.IO.File.Open(Path.Combine(path, fileName), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (index >= from && index <= to)
                    {
                        result.Add(line);
					}
                    index++;
                }
            }
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return result;
        }
    }
}