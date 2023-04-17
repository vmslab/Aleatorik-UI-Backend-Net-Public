using AleatorikUI.Services.DAO.iod;
using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmSiteMasterController : ControllerBase
{

    private readonly ILogger<MdmSiteMasterController> _logger;
    private readonly IMdmSiteMasterDao _mdmSiteMasterDao;

    public MdmSiteMasterController(ILogger<MdmSiteMasterController> logger, IMdmSiteMasterDao mdmSiteMasterDao)
    {
        _logger = logger;
        _mdmSiteMasterDao = mdmSiteMasterDao;
    }

    [HttpGet("/api/MdmSiteMaster")]
    public IEnumerable<MdmSiteMaster> GetAll()
    {
        try
        {
            var result = _mdmSiteMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmSiteMaster>();
        }
    }

    [HttpPost("/api/MdmSiteMaster")]
    public int Insert(MdmSiteMaster mdmSiteMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmSiteMaster);
            _mdmSiteMasterDao.Insert(mdmSiteMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmSiteMaster/{siteID}")]
    public int Update(MdmSiteMaster mdmSiteMaster)
    {
        _logger.LogInformation("Update : {}", mdmSiteMaster);
        try
        {
            var result = _mdmSiteMasterDao.Update(mdmSiteMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmSiteMaster/{siteID}")]
    public int Delete(MdmSiteMaster mdmSiteMaster)
    {
        _logger.LogInformation("Delete : {}", mdmSiteMaster);
        try
        {
            var result = _mdmSiteMasterDao.Delete(mdmSiteMaster);
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