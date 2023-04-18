using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DTO.sam;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sam;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class SamMenuController : ControllerBase
{

    private readonly ILogger<SamMenuController> _logger;
    private readonly ISamMenuDao _samMenuDao;

    public SamMenuController(ILogger<SamMenuController> logger, ISamMenuDao samMenuDao)
    {
        _logger = logger;
        _samMenuDao = samMenuDao;
    }

    [HttpGet("/api/GetMenu/{systemId}")]
    public IEnumerable<SamMenuInfo> GetAll(string systemId)
    {
        try
        {
            var result = _samMenuDao.GetAll(systemId);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<SamMenuInfo>();
        }
    }

    [HttpPost("/api/GetMenu")]
    public IEnumerable<SamMenuInfo> GetAll(SamUserInfo samUserInfo)
    {
        try
        {
            var result = _samMenuDao.GetAll(samUserInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<SamMenuInfo>();
        }
    }

    [HttpPost("/api/GetMenuById")]
    public SamMenuInfo GetById(SamMenuInfo samMenuInfo)
    {
        _logger.LogInformation("samMenuInfo : {}", samMenuInfo);

        try
        {
            var result = _samMenuDao.GetById(samMenuInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new SamMenuInfo();
        }

    }

    [HttpPost("/api/SaveMenu")]
    public int Save(List<SamMenuInfo> samMenuInfos)
    {
        try
        {
            _logger.LogInformation("samMenuInfo : {}", samMenuInfos.Select(x => x.MenuId));
            var result = _samMenuDao.Save(samMenuInfos);
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