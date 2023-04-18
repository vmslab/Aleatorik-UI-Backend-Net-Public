using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DTO.sam;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sam;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class SamMenuMapController : ControllerBase
{

    private readonly ILogger<SamMenuMapController> _logger;
    private readonly ISamMenuMapDao _samMenuMapDao;

    public SamMenuMapController(ILogger<SamMenuMapController> logger, ISamMenuMapDao samMenuMapDao)
    {
        _logger = logger;
        _samMenuMapDao = samMenuMapDao;
    }

    [HttpPost("/api/GetMenuMap")]
    public IEnumerable<SamMenuMapInfo> GetAll(SamMenuMapInfo samMenuMapInfo)
    {
        try
        {
            var result = _samMenuMapDao.GetAll(samMenuMapInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<SamMenuMapInfo>();
        }
    }

    [HttpGet("/api/GetMenuMap/{samMenuMapId}")]
    public SamMenuMapInfo GetById(string samMenuMapId)
    {
        _logger.LogInformation("samMenuMapId : {}", samMenuMapId);

        try
        {
            var result = _samMenuMapDao.GetById(samMenuMapId);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new SamMenuMapInfo();
        }

    }

    [HttpPost("/api/SaveMenuMap")]
    public int Save(List<SamMenuMapInfo> samMenuMapInfos)
    {
        try
        {
            _logger.LogInformation("samMenuMapInfo : {}", samMenuMapInfos.Select(x => x.MenuMapId));
            var result = _samMenuMapDao.Save(samMenuMapInfos);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
}