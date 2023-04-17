using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmIsbMasterController : ControllerBase
{

    private readonly ILogger<MdmIsbMasterController> _logger;
    private readonly IMdmIsbMasterDao _mdmIsbMasterDao;

    public MdmIsbMasterController(ILogger<MdmIsbMasterController> logger, IMdmIsbMasterDao mdmIsbMasterDao)
    {
        _logger = logger;
        _mdmIsbMasterDao = mdmIsbMasterDao;
    }

    [HttpGet("/api/MdmIsbMaster")]
    public IEnumerable<MdmIsbMaster> GetAll()
    {
        try
        {
            var result = _mdmIsbMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmIsbMaster>();
        }
    }

    [HttpPost("/api/MdmIsbMaster")]
    public int Insert(MdmIsbMaster mdmIsbMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmIsbMaster);
            _mdmIsbMasterDao.Insert(mdmIsbMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmIsbMaster/{itemID}/{siteID}/{bufferID}")]
    public int Update(MdmIsbMaster mdmIsbMaster)
    {
        _logger.LogInformation("Update : {}", mdmIsbMaster);
        try
        {
            var result = _mdmIsbMasterDao.Update(mdmIsbMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmIsbMaster/{itemID}/{siteID}/{bufferID}")]
    public int Delete(MdmIsbMaster mdmIsbMaster)
    {
        _logger.LogInformation("Delete : {}", mdmIsbMaster);
        try
        {
            var result = _mdmIsbMasterDao.Delete(mdmIsbMaster);
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