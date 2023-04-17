using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmBomMasterController : ControllerBase
{

    private readonly ILogger<MdmBomMasterController> _logger;
    private readonly IMdmBomMasterDao _mdmBomMasterDao;

    public MdmBomMasterController(ILogger<MdmBomMasterController> logger, IMdmBomMasterDao mdmBomMasterDao)
    {
        _logger = logger;
        _mdmBomMasterDao = mdmBomMasterDao;
    }

    [HttpGet("/api/MdmBomMaster")]
    public IEnumerable<MdmBomMaster> GetAll()
    {
        try
        {
            var result = _mdmBomMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomMaster>();
        }
    }

    [HttpPost("/api/MdmBomMaster")]
    public int Insert(MdmBomMaster mdmBomMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBomMaster);
            _mdmBomMasterDao.Insert(mdmBomMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBomMaster/{bomID}")]
    public int Update(MdmBomMaster mdmBomMaster)
    {
        _logger.LogInformation("Update : {}", mdmBomMaster);
        try
        {
            var result = _mdmBomMasterDao.Update(mdmBomMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBomMaster/{bomID}")]
    public int Delete(MdmBomMaster mdmBomMaster)
    {
        _logger.LogInformation("Delete : {}", mdmBomMaster);
        try
        {
            var result = _mdmBomMasterDao.Delete(mdmBomMaster);
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
    [HttpGet("/api/MdmBomMaster/{bomID}/Sub1")]
    public IEnumerable<MdmBomSub1> GetAllSub1(String bomID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllSub1(bomID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomSub1>();
        }
    }

    [HttpPost("/api/MdmBomMaster/{bomID}/Sub1")]
    public int InsertSub1(MdmBomSub1 mdmBomSub1, String bomID)
    {
        try
        {
            mdmBomSub1.bomID = bomID;
            _logger.LogInformation("Insert : {}", mdmBomSub1);
            _mdmBomMasterDao.InsertSub1(mdmBomSub1);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBomMaster/{bomID}/Sub1/{fromItemID}")]
    public int UpdateSub1(MdmBomSub1 mdmBomSub1)
    {
        _logger.LogInformation("Update : {}", mdmBomSub1);
        try
        {
            var result = _mdmBomMasterDao.UpdateSub1(mdmBomSub1);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBomMaster/{bomID}/Sub1/{fromItemID}")]
    public int DeleteSub1(MdmBomSub1 mdmBomSub1)
    {
        _logger.LogInformation("Delete : {}", mdmBomSub1);
        try
        {
            var result = _mdmBomMasterDao.DeleteSub1(mdmBomSub1);
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
    [HttpGet("/api/MdmBomMaster/{bomID}/Sub2")]
    public IEnumerable<MdmBomSub2> GetAllSub2(String bomID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllSub2(bomID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomSub2>();
        }
    }

    [HttpPost("/api/MdmBomMaster/{bomID}/Sub2")]
    public int InsertSub2(MdmBomSub2 mdmBomSub2, String bomID)
    {
        try
        {
            mdmBomSub2.bomID = bomID;
            _logger.LogInformation("Insert : {}", mdmBomSub2);
            _mdmBomMasterDao.InsertSub2(mdmBomSub2);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBomMaster/{bomID}/Sub2/{itemID}")]
    public int UpdateSub2(MdmBomSub2 mdmBomSub2)
    {
        _logger.LogInformation("Update : {}", mdmBomSub2);
        try
        {
            var result = _mdmBomMasterDao.UpdateSub2(mdmBomSub2);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBomMaster/{bomID}/Sub2/{itemID}")]
    public int DeleteSub2(MdmBomSub2 mdmBomSub2)
    {
        _logger.LogInformation("Delete : {}", mdmBomSub2);
        try
        {
            var result = _mdmBomMasterDao.DeleteSub2(mdmBomSub2);
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
      * Sub3
      */
    [HttpGet("/api/MdmBomMaster/{bomID}/Sub3")]
    public IEnumerable<MdmBomSub3> GetAllSub3(String bomID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllSub3(bomID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomSub3>();
        }
    }

    [HttpPost("/api/MdmBomMaster/{bomID}/Sub3")]
    public int InsertSub3(MdmBomSub3 mdmBomSub3, String bomID)
    {
        try
        {
            mdmBomSub3.bomID = bomID;
            _logger.LogInformation("Insert : {}", mdmBomSub3);
            _mdmBomMasterDao.InsertSub3(mdmBomSub3);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBomMaster/{bomID}/Sub3/{propertyID}")]
    public int UpdateSub3(MdmBomSub3 mdmBomSub3)
    {
        _logger.LogInformation("Update : {}", mdmBomSub3);
        try
        {
            var result = _mdmBomMasterDao.UpdateSub3(mdmBomSub3);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBomMaster/{bomID}/Sub3/{propertyID}")]
    public int DeleteSub3(MdmBomSub3 mdmBomSub3)
    {
        _logger.LogInformation("Delete : {}", mdmBomSub3);
        try
        {
            var result = _mdmBomMasterDao.DeleteSub3(mdmBomSub3);
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