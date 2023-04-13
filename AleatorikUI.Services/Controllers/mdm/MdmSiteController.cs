using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmSiteController : ControllerBase
{

    private readonly ILogger<MdmSiteController> _logger;
    private readonly IMdmSiteDao _mdmSiteDao;

    public MdmSiteController(ILogger<MdmSiteController> logger, IMdmSiteDao mdmSiteDao)
    {
        _logger = logger;
        _mdmSiteDao = mdmSiteDao;
    }

    [HttpGet("/api/MdmSite")]
    public IEnumerable<MdmSite> GetAll()
    {
        try
        {
            var result = _mdmSiteDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmSite>();
        }
    }

    [HttpPost("/api/MdmSite")]
    public int Insert(MdmSite mdmSite)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmSite);
            _mdmSiteDao.Insert(mdmSite);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmSite/{siteID}")]
    public int Update(MdmSite mdmSite)
    {
        _logger.LogInformation("Update : {}", mdmSite);
        try
        {
            var result = _mdmSiteDao.Update(mdmSite);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmSite/{siteID}")]
    public int Delete(MdmSite mdmSite)
    {
        _logger.LogInformation("Delete : {}", mdmSite);
        try
        {
            var result = _mdmSiteDao.Delete(mdmSite);
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