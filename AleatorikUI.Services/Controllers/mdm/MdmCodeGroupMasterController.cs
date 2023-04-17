using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmCodeGroupMasterController : ControllerBase
{

    private readonly ILogger<MdmCodeGroupMasterController> _logger;
    private readonly IMdmCodeGroupMasterDao _mdmCodeGroupMasterDao;

    public MdmCodeGroupMasterController(ILogger<MdmCodeGroupMasterController> logger, IMdmCodeGroupMasterDao mdmCodeGroupMasterDao)
    {
        _logger = logger;
        _mdmCodeGroupMasterDao = mdmCodeGroupMasterDao;
    }

    [HttpGet("/api/MdmCodeGroupMaster")]
    public IEnumerable<MdmCodeGroupMaster> GetAll()
    {
        try
        {
            var result = _mdmCodeGroupMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCodeGroupMaster>();
        }
    }

    [HttpPost("/api/MdmCodeGroupMaster")]
    public int Insert(MdmCodeGroupMaster mdmCodeGroupMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmCodeGroupMaster);
            _mdmCodeGroupMasterDao.Insert(mdmCodeGroupMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCodeGroupMaster/{categoryID}")]
    public int Update(MdmCodeGroupMaster mdmCodeGroupMaster)
    {
        _logger.LogInformation("Update : {}", mdmCodeGroupMaster);
        try
        {
            var result = _mdmCodeGroupMasterDao.Update(mdmCodeGroupMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCodeGroupMaster/{categoryID}")]
    public int Delete(MdmCodeGroupMaster mdmCodeGroupMaster)
    {
        _logger.LogInformation("Delete : {}", mdmCodeGroupMaster);
        try
        {
            var result = _mdmCodeGroupMasterDao.Delete(mdmCodeGroupMaster);
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
    [HttpGet("/api/MdmCodeGroupMaster/{categoryID}/Sub1")]
    public IEnumerable<MdmCodeGroupSub1> GetAllSub1(String categoryID)
    {
        try
        {
            var result = _mdmCodeGroupMasterDao.GetAllSub1(categoryID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCodeGroupSub1>();
        }
    }

    [HttpPost("/api/MdmCodeGroupMaster/{categoryID}/Sub1")]
    public int InsertSub1(MdmCodeGroupSub1 mdmCodeGroupSub1, String categoryID)
    {
        try
        {
            mdmCodeGroupSub1.categoryID = categoryID;
            _logger.LogInformation("Insert : {}", mdmCodeGroupSub1);
            _mdmCodeGroupMasterDao.InsertSub1(mdmCodeGroupSub1);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCodeGroupMaster/{categoryID}/Sub1/{codeID}")]
    public int UpdateSub1(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        _logger.LogInformation("Update : {}", mdmCodeGroupSub1);
        try
        {
            var result = _mdmCodeGroupMasterDao.UpdateSub1(mdmCodeGroupSub1);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCodeGroupMaster/{categoryID}/Sub1/{codeID}")]
    public int DeleteSub1(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        _logger.LogInformation("Delete : {}", mdmCodeGroupSub1);
        try
        {
            var result = _mdmCodeGroupMasterDao.DeleteSub1(mdmCodeGroupSub1);
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