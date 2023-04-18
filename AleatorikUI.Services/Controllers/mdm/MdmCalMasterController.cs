using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmCalMasterController : ControllerBase
{

    private readonly ILogger<MdmCalMasterController> _logger;
    private readonly IMdmCalMasterDao _mdmCalMasterDao;

    public MdmCalMasterController(ILogger<MdmCalMasterController> logger, IMdmCalMasterDao mdmCalMasterDao)
    {
        _logger = logger;
        _mdmCalMasterDao = mdmCalMasterDao;
    }

    [HttpGet("/api/MdmCalMaster")]
    public IEnumerable<MdmCalMaster> GetAll()
    {
        try
        {
            var result = _mdmCalMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCalMaster>();
        }
    }

    [HttpPost("/api/MdmCalMaster")]
    public int Insert(MdmCalMaster mdmCalMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmCalMaster);
            _mdmCalMasterDao.Insert(mdmCalMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCalMaster/{calendarID}")]
    public int Update(MdmCalMaster mdmCalMaster)
    {
        _logger.LogInformation("Update : {}", mdmCalMaster);
        try
        {
            var result = _mdmCalMasterDao.Update(mdmCalMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCalMaster/{calendarID}")]
    public int Delete(MdmCalMaster mdmCalMaster)
    {
        _logger.LogInformation("Delete : {}", mdmCalMaster);
        try
        {
            var result = _mdmCalMasterDao.Delete(mdmCalMaster);
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
    [HttpGet("/api/MdmCalMaster/{calendarID}/Sub1")]
    public IEnumerable<MdmCalSub1> GetAllSub1(String calendarID)
    {
        try
        {
            var result = _mdmCalMasterDao.GetAllSub1(calendarID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCalSub1>();
        }
    }

    [HttpPost("/api/MdmCalMaster/{calendarID}/Sub1")]
    public int InsertSub1(MdmCalSub1 mdmCalSub1, String calendarID)
    {
        try
        {
            mdmCalSub1.calendarID = calendarID;
            _logger.LogInformation("Insert : {}", mdmCalSub1);
            _mdmCalMasterDao.InsertSub1(mdmCalSub1);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCalMaster/{calendarID}/Sub1/{patternSeq}")]
    public int UpdateSub1(MdmCalSub1 mdmCalSub1)
    {
        _logger.LogInformation("Update : {}", mdmCalSub1);
        try
        {
            var result = _mdmCalMasterDao.UpdateSub1(mdmCalSub1);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCalMaster/{calendarID}/Sub1/{patternSeq}")]
    public int DeleteSub1(MdmCalSub1 mdmCalSub1)
    {
        _logger.LogInformation("Delete : {}", mdmCalSub1);
        try
        {
            var result = _mdmCalMasterDao.DeleteSub1(mdmCalSub1);
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
    [HttpGet("/api/MdmCalMaster/{calendarID}/Sub2")]
    public IEnumerable<MdmCalSub2> GetAllSub2(String calendarID)
    {
        try
        {
            var result = _mdmCalMasterDao.GetAllSub2(calendarID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCalSub2>();
        }
    }

    [HttpPost("/api/MdmCalMaster/{calendarID}/Sub2")]
    public int InsertSub2(MdmCalSub2 mdmCalSub2, String calendarID)
    {
        try
        {
            mdmCalSub2.calendarID = calendarID;
            _logger.LogInformation("Insert : {}", mdmCalSub2);
            _mdmCalMasterDao.InsertSub2(mdmCalSub2);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCalMaster/{calendarID}/Sub2/{patternSeq}/{attribute}")]
    public int UpdateSub2(MdmCalSub2 mdmCalSub2)
    {
        _logger.LogInformation("Update : {}", mdmCalSub2);
        try
        {
            var result = _mdmCalMasterDao.UpdateSub2(mdmCalSub2);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCalMaster/{calendarID}/Sub2/{patternSeq}/{attribute}")]
    public int DeleteSub2(MdmCalSub2 mdmCalSub2)
    {
        _logger.LogInformation("Delete : {}", mdmCalSub2);
        try
        {
            var result = _mdmCalMasterDao.DeleteSub2(mdmCalSub2);
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