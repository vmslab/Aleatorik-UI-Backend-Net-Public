using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmResGroupMasterController : ControllerBase
{

    private readonly ILogger<MdmResGroupMasterController> _logger;
    private readonly IMdmResGroupMasterDao _mdmResGroupMasterDao;

    public MdmResGroupMasterController(ILogger<MdmResGroupMasterController> logger, IMdmResGroupMasterDao mdmResGroupMasterDao)
    {
        _logger = logger;
        _mdmResGroupMasterDao = mdmResGroupMasterDao;
    }

    [HttpGet("/api/MdmResGroupMaster")]
    public IEnumerable<MdmResGroupMaster> GetAll()
    {
        try
        {
            var result = _mdmResGroupMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmResGroupMaster>();
        }
    }

    [HttpPost("/api/MdmResGroupMaster")]
    public int Insert(MdmResGroupMaster mdmResGroupMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmResGroupMaster);
            _mdmResGroupMasterDao.Insert(mdmResGroupMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmResGroupMaster/{resourceGroupID}")]
    public int Update(MdmResGroupMaster mdmResGroupMaster)
    {
        _logger.LogInformation("Update : {}", mdmResGroupMaster);
        try
        {
            var result = _mdmResGroupMasterDao.Update(mdmResGroupMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmResGroupMaster/{resourceGroupID}")]
    public int Delete(MdmResGroupMaster mdmResGroupMaster)
    {
        _logger.LogInformation("Delete : {}", mdmResGroupMaster);
        try
        {
            var result = _mdmResGroupMasterDao.Delete(mdmResGroupMaster);
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