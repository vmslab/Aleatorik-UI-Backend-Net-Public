using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmOperResMasterController : ControllerBase
{

    private readonly ILogger<MdmOperResMasterController> _logger;
    private readonly IMdmOperResMasterDao _mdmOperResMasterDao;

    public MdmOperResMasterController(ILogger<MdmOperResMasterController> logger, IMdmOperResMasterDao mdmOperResMasterDao)
    {
        _logger = logger;
        _mdmOperResMasterDao = mdmOperResMasterDao;
    }

    [HttpGet("/api/MdmOperResMaster")]
    public IEnumerable<MdmOperResMaster> GetAll()
    {
        try
        {
            var result = _mdmOperResMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmOperResMaster>();
        }
    }

    [HttpPost("/api/MdmOperResMaster")]
    public int Insert(MdmOperResMaster mdmOperResMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmOperResMaster);
            _mdmOperResMasterDao.Insert(mdmOperResMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmOperResMaster/{routingID}")]
    public int Update(MdmOperResMaster mdmOperResMaster)
    {
        _logger.LogInformation("Update : {}", mdmOperResMaster);
        try
        {
            var result = _mdmOperResMasterDao.Update(mdmOperResMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmOperResMaster/{routingID}")]
    public int Delete(MdmOperResMaster mdmOperResMaster)
    {
        _logger.LogInformation("Delete : {}", mdmOperResMaster);
        try
        {
            var result = _mdmOperResMasterDao.Delete(mdmOperResMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /**
     * Sub1
     */
    [HttpGet("/api/MdmOperResMaster/{routingID}/Sub1")]
    public IEnumerable<MdmOperResSub1> GetAllSub1(String routingID)
    {
        try
        {
            var result = _mdmOperResMasterDao.GetAllSub1(routingID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmOperResSub1>();
        }
    }

    [HttpPost("/api/MdmOperResMaster/{routingID}/Sub1")]
    public int InsertSub1(MdmOperResSub1 mdmOperResSub1, String routingID)
    {
        try
        {
            mdmOperResSub1.routingID = routingID;
            _logger.LogInformation("Insert : {}", mdmOperResSub1);
            _mdmOperResMasterDao.InsertSub1(mdmOperResSub1);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmOperResMaster/{routingID}/Sub1/{operationID}")]
    public int UpdateSub1(MdmOperResSub1 mdmOperResSub1)
    {
        _logger.LogInformation("Update : {}", mdmOperResSub1);
        try
        {
            var result = _mdmOperResMasterDao.UpdateSub1(mdmOperResSub1);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmOperResMaster/{routingID}/Sub1/{operationID}")]
    public int DeleteSub1(MdmOperResSub1 mdmOperResSub1)
    {
        _logger.LogInformation("Delete : {}", mdmOperResSub1);
        try
        {
            var result = _mdmOperResMasterDao.DeleteSub1(mdmOperResSub1);
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