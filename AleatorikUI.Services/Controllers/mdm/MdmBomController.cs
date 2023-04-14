using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmBomController : ControllerBase
{

    private readonly ILogger<MdmBomController> _logger;
    private readonly IMdmBomDao _mdmBomDao;

    public MdmBomController(ILogger<MdmBomController> logger, IMdmBomDao mdmBomDao)
    {
        _logger = logger;
        _mdmBomDao = mdmBomDao;
    }

    [HttpGet("/api/MdmBom")]
    public IEnumerable<MdmBom> GetAll()
    {
        try
        {
            var result = _mdmBomDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBom>();
        }
    }

    [HttpPost("/api/MdmBom")]
    public int Insert(MdmBom mdmBom)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBom);
            _mdmBomDao.Insert(mdmBom);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBom/{bomID}")]
    public int Update(MdmBom mdmBom)
    {
        _logger.LogInformation("Update : {}", mdmBom);
        try
        {
            var result = _mdmBomDao.Update(mdmBom);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBom/{bomID}")]
    public int Delete(MdmBom mdmBom)
    {
        _logger.LogInformation("Delete : {}", mdmBom);
        try
        {
            var result = _mdmBomDao.Delete(mdmBom);
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
    [HttpGet("/api/MdmBom/{bomID}/Sub1")]
    public IEnumerable<MdmBomSub1> GetAllSub1(String bomID)
    {
        try
        {
            var result = _mdmBomDao.GetAllSub1(bomID);
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

    [HttpPost("/api/MdmBom/{bomID}/Sub1")]
    public int InsertSub1(MdmBomSub1 mdmBomSub1, String bomID)
    {
        try
        {
            mdmBomSub1.bomID = bomID;
            _logger.LogInformation("Insert : {}", mdmBomSub1);
            _mdmBomDao.InsertSub1(mdmBomSub1);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBom/{bomID}/Sub1/{fromItemID}")]
    public int UpdateSub1(MdmBomSub1 mdmBomSub1)
    {
        _logger.LogInformation("Update : {}", mdmBomSub1);
        try
        {
            var result = _mdmBomDao.UpdateSub1(mdmBomSub1);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBom/{bomID}/Sub1/{fromItemID}")]
    public int DeleteSub1(MdmBomSub1 mdmBomSub1)
    {
        _logger.LogInformation("Delete : {}", mdmBomSub1);
        try
        {
            var result = _mdmBomDao.DeleteSub1(mdmBomSub1);
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
    [HttpGet("/api/MdmBom/{bomID}/Sub2")]
    public IEnumerable<MdmBomSub2> GetAllSub2(String bomID)
    {
        try
        {
            var result = _mdmBomDao.GetAllSub2(bomID);
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

    [HttpPost("/api/MdmBom/{bomID}/Sub2")]
    public int InsertSub2(MdmBomSub2 mdmBomSub2, String bomID)
    {
        try
        {
            mdmBomSub2.bomID = bomID;
            _logger.LogInformation("Insert : {}", mdmBomSub2);
            _mdmBomDao.InsertSub2(mdmBomSub2);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBom/{bomID}/Sub2/{itemID}")]
    public int UpdateSub2(MdmBomSub2 mdmBomSub2)
    {
        _logger.LogInformation("Update : {}", mdmBomSub2);
        try
        {
            var result = _mdmBomDao.UpdateSub2(mdmBomSub2);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBom/{bomID}/Sub2/{itemID}")]
    public int DeleteSub2(MdmBomSub2 mdmBomSub2)
    {
        _logger.LogInformation("Delete : {}", mdmBomSub2);
        try
        {
            var result = _mdmBomDao.DeleteSub2(mdmBomSub2);
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
    [HttpGet("/api/MdmBom/{bomID}/Sub3")]
    public IEnumerable<MdmBomSub3> GetAllSub3(String bomID)
    {
        try
        {
            var result = _mdmBomDao.GetAllSub3(bomID);
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

    [HttpPost("/api/MdmBom/{bomID}/Sub3")]
    public int InsertSub3(MdmBomSub3 mdmBomSub3, String bomID)
    {
        try
        {
            mdmBomSub3.bomID = bomID;
            _logger.LogInformation("Insert : {}", mdmBomSub3);
            _mdmBomDao.InsertSub3(mdmBomSub3);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBom/{bomID}/Sub3/{propertyID}")]
    public int UpdateSub3(MdmBomSub3 mdmBomSub3)
    {
        _logger.LogInformation("Update : {}", mdmBomSub3);
        try
        {
            var result = _mdmBomDao.UpdateSub3(mdmBomSub3);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBom/{bomID}/Sub3/{propertyID}")]
    public int DeleteSub3(MdmBomSub3 mdmBomSub3)
    {
        _logger.LogInformation("Delete : {}", mdmBomSub3);
        try
        {
            var result = _mdmBomDao.DeleteSub3(mdmBomSub3);
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