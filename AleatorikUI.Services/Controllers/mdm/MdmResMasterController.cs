using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmResMasterController : ControllerBase
{

    private readonly ILogger<MdmResMasterController> _logger;
    private readonly IMdmResMasterDao _mdmResMasterDao;

    public MdmResMasterController(ILogger<MdmResMasterController> logger, IMdmResMasterDao mdmResMasterDao)
    {
        _logger = logger;
        _mdmResMasterDao = mdmResMasterDao;
    }

    [HttpGet("/api/MdmResMaster")]
    public IEnumerable<MdmResMaster> GetAll()
    {
        try
        {
            var result = _mdmResMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmResMaster>();
        }
    }

    [HttpPost("/api/MdmResMaster")]
    public int Insert(MdmResMaster mdmResMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmResMaster);
            _mdmResMasterDao.Insert(mdmResMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmResMaster/{resourceID}")]
    public int Update(MdmResMaster mdmResMaster)
    {
        _logger.LogInformation("Update : {}", mdmResMaster);
        try
        {
            var result = _mdmResMasterDao.Update(mdmResMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmResMaster/{resourceID}")]
    public int Delete(MdmResMaster mdmResMaster)
    {
        _logger.LogInformation("Delete : {}", mdmResMaster);
        try
        {
            var result = _mdmResMasterDao.Delete(mdmResMaster);
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