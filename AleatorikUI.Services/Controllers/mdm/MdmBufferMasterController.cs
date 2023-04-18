using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmBufferMasterController : ControllerBase
{

    private readonly ILogger<MdmBufferMasterController> _logger;
    private readonly IMdmBufferMasterDao _mdmBufferMasterDao;

    public MdmBufferMasterController(ILogger<MdmBufferMasterController> logger, IMdmBufferMasterDao mdmBufferMasterDao)
    {
        _logger = logger;
        _mdmBufferMasterDao = mdmBufferMasterDao;
    }

    [HttpGet("/api/MdmBufferMaster")]
    public IEnumerable<MdmBufferMaster> GetAll()
    {
        try
        {
            var result = _mdmBufferMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBufferMaster>();
        }
    }

    [HttpPost("/api/MdmBufferMaster")]
    public int Insert(MdmBufferMaster mdmBufferMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBufferMaster);
            _mdmBufferMasterDao.Insert(mdmBufferMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBufferMaster/{stageID}/{bufferID}")]
    public int Update(MdmBufferMaster mdmBufferMaster)
    {
        _logger.LogInformation("Update : {}", mdmBufferMaster);
        try
        {
            var result = _mdmBufferMasterDao.Update(mdmBufferMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBufferMaster/{stageID}/{bufferID}")]
    public int Delete(MdmBufferMaster mdmBufferMaster)
    {
        _logger.LogInformation("Delete : {}", mdmBufferMaster);
        try
        {
            var result = _mdmBufferMasterDao.Delete(mdmBufferMaster);
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