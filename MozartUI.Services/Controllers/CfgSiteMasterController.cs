using Microsoft.AspNetCore.Mvc;
using MozartUI.Services.DAO;
using MozartUI.Services.DTO;

namespace MozartUI.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class CfgSiteMasterController : ControllerBase
{

    private readonly ILogger<CfgSiteMasterController> _logger;
    private readonly ICfgSiteMasterDao _cfgSiteMasterDao;

    public CfgSiteMasterController(ILogger<CfgSiteMasterController> logger, ICfgSiteMasterDao cfgSiteMasterDao)
    {
        _logger = logger;
        _cfgSiteMasterDao = cfgSiteMasterDao;
    }

    [HttpGet("/api/cfgSiteMaster/list")]
    public IEnumerable<CfgSiteMaster> GetAll()
    {
        try {
            var result = _cfgSiteMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        } 
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<CfgSiteMaster>();
		}
    }

    [HttpGet("/api/cfgSiteMaster/{siteId}")]
    public CfgSiteMaster GetById(String siteId)
    {
        _logger.LogInformation("GetById  : {}", siteId);

        try
        {
            var result = _cfgSiteMasterDao.GetById(siteId);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new CfgSiteMaster();
        }
    }

    [HttpPost("/api/cfgSiteMaster/add")]
    public int Insert(CfgSiteMaster cfgSiteMaster)
    {
        try
        {
            cfgSiteMaster.CreateTime= DateTime.Now;
            cfgSiteMaster.UpdateTime= DateTime.Now;
            // TODO: User 정보 JWT에서 읽어오도록 기능 추가 바람 Hawon Kim 2023-04-10 19:00

            _logger.LogInformation("Insert : {}", cfgSiteMaster);
            _cfgSiteMasterDao.Insert(cfgSiteMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/cfgSiteMaster/{siteId}")]
    public int Update(CfgSiteMaster cfgSiteMaster, String siteId)
    {
        _logger.LogInformation("Update : {}", cfgSiteMaster);
        try
        {
            cfgSiteMaster.SiteId = siteId;
            cfgSiteMaster.UpdateTime = DateTime.Now;
            // TODO: User 정보 JWT에서 읽어오도록 기능 추가 바람 Hawon Kim 2023-04-10 19:00

            var result = _cfgSiteMasterDao.Update(cfgSiteMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/cfgSiteMaster/{siteId}")]
    public int Delete(CfgSiteMaster cfgSiteMaster, String siteId)
    {
        _logger.LogInformation("Delete : {}", cfgSiteMaster);
        try
        {
            cfgSiteMaster.SiteId = siteId;

            var result = _cfgSiteMasterDao.Delete(cfgSiteMaster);
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