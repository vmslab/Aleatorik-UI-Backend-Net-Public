using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmRoutingMasterController : ControllerBase
{

    private readonly ILogger<MdmRoutingMasterController> _logger;
    private readonly IMdmRoutingMasterDao _mdmRoutingMasterDao;

    public MdmRoutingMasterController(ILogger<MdmRoutingMasterController> logger, IMdmRoutingMasterDao mdmRoutingMasterDao)
    {
        _logger = logger;
        _mdmRoutingMasterDao = mdmRoutingMasterDao;
    }

    [HttpGet("/api/MdmRoutingMaster")]
    public IEnumerable<MdmRoutingMaster> GetAll()
    {
        try
        {
            var result = _mdmRoutingMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmRoutingMaster>();
        }
    }

    [HttpPost("/api/MdmRoutingMaster")]
    public int Insert(MdmRoutingMaster mdmRoutingMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmRoutingMaster);
            _mdmRoutingMasterDao.Insert(mdmRoutingMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmRoutingMaster/{routingID}")]
    public int Update(MdmRoutingMaster mdmRoutingMaster)
    {
        _logger.LogInformation("Update : {}", mdmRoutingMaster);
        try
        {
            var result = _mdmRoutingMasterDao.Update(mdmRoutingMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmRoutingMaster/{routingID}")]
    public int Delete(MdmRoutingMaster mdmRoutingMaster)
    {
        _logger.LogInformation("Delete : {}", mdmRoutingMaster);
        try
        {
            var result = _mdmRoutingMasterDao.Delete(mdmRoutingMaster);
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
    [HttpGet("/api/MdmRoutingMaster/{routingID}/Sub1")]
    public IEnumerable<MdmRoutingOper> GetAllSub1(String routingID)
    {
        try
        {
            var result = _mdmRoutingMasterDao.GetAllSub1(routingID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmRoutingOper>();
        }
    }

    [HttpPost("/api/MdmRoutingMaster/{routingID}/Sub1")]
    public int InsertSub1(MdmRoutingOper mdmRoutingSub1, String routingID)
    {
        try
        {
            mdmRoutingSub1.routingID = routingID;
            _logger.LogInformation("Insert : {}", mdmRoutingSub1);
            _mdmRoutingMasterDao.InsertSub1(mdmRoutingSub1);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmRoutingMaster/{routingID}/Sub1/{operationID}")]
    public int UpdateSub1(MdmRoutingOper mdmRoutingSub1)
    {
        _logger.LogInformation("Update : {}", mdmRoutingSub1);
        try
        {
            var result = _mdmRoutingMasterDao.UpdateSub1(mdmRoutingSub1);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmRoutingMaster/{routingID}/Sub1/{operationID}")]
    public int DeleteSub1(MdmRoutingOper mdmRoutingSub1)
    {
        _logger.LogInformation("Delete : {}", mdmRoutingSub1);
        try
        {
            var result = _mdmRoutingMasterDao.DeleteSub1(mdmRoutingSub1);
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
     * Sub2
     */
    [HttpGet("/api/MdmRoutingMaster/{routingID}/Sub2")]
    public IEnumerable<MdmRoutingOperProp> GetAllSub2(String routingID)
    {
        try
        {
            var result = _mdmRoutingMasterDao.GetAllSub2(routingID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmRoutingOperProp>();
        }
    }

    [HttpPost("/api/MdmRoutingMaster/{routingID}/Sub2")]
    public int InsertSub2(MdmRoutingOperProp mdmRoutingSub2, String routingID)
    {
        try
        {
            mdmRoutingSub2.routingID = routingID;
            _logger.LogInformation("Insert : {}", mdmRoutingSub2);
            _mdmRoutingMasterDao.InsertSub2(mdmRoutingSub2);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmRoutingMaster/{routingID}/Sub2/{operationID}/{propertyID}")]
    public int UpdateSub2(MdmRoutingOperProp mdmRoutingSub2)
    {
        _logger.LogInformation("Update : {}", mdmRoutingSub2);
        try
        {
            var result = _mdmRoutingMasterDao.UpdateSub2(mdmRoutingSub2);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmRoutingMaster/{routingID}/Sub2/{operationID}/{propertyID}")]
    public int DeleteSub2(MdmRoutingOperProp mdmRoutingSub2)
    {
        _logger.LogInformation("Delete : {}", mdmRoutingSub2);
        try
        {
            var result = _mdmRoutingMasterDao.DeleteSub2(mdmRoutingSub2);
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