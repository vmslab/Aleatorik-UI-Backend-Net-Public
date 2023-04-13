using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmCodeGroupController : ControllerBase
{

    private readonly ILogger<MdmCodeGroupController> _logger;
    private readonly IMdmCodeGroupDao _mdmCodeGroupDao;

    public MdmCodeGroupController(ILogger<MdmCodeGroupController> logger, IMdmCodeGroupDao mdmCodeGroupDao)
    {
        _logger = logger;
        _mdmCodeGroupDao = mdmCodeGroupDao;
    }

    [HttpGet("/api/MdmCodeGroup")]
    public IEnumerable<MdmCodeGroup> GetAll()
    {
        try
        {
            var result = _mdmCodeGroupDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCodeGroup>();
        }
    }

    [HttpPost("/api/MdmCodeGroup")]
    public int Insert(MdmCodeGroup mdmCodeGroup)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmCodeGroup);
            _mdmCodeGroupDao.Insert(mdmCodeGroup);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCodeGroup/{categoryID}")]
    public int Update(MdmCodeGroup mdmCodeGroup)
    {
        _logger.LogInformation("Update : {}", mdmCodeGroup);
        try
        {
            var result = _mdmCodeGroupDao.Update(mdmCodeGroup);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCodeGroup/{categoryID}")]
    public int Delete(MdmCodeGroup mdmCodeGroup)
    {
        _logger.LogInformation("Delete : {}", mdmCodeGroup);
        try
        {
            var result = _mdmCodeGroupDao.Delete(mdmCodeGroup);
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
     * DETAIL
     */
    [HttpGet("/api/MdmCodeGroup/{categoryID}/Sub1")]
    public IEnumerable<MdmCodeGroupSub1> GetAllDetail(String categoryID)
    {
        try
        {
            var result = _mdmCodeGroupDao.GetAllDetail(categoryID);
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

    [HttpPost("/api/MdmCodeGroup/{categoryID}/Sub1")]
    public int InsertDetail(MdmCodeGroupSub1 mdmCodeGroupSub1, String categoryID)
    {
        try
        {
            mdmCodeGroupSub1.categoryID = categoryID;
            _logger.LogInformation("Insert : {}", mdmCodeGroupSub1);
            _mdmCodeGroupDao.InsertDetail(mdmCodeGroupSub1);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCodeGroup/{categoryID}/Sub1/{codeID}")]
    public int UpdateDetail(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        _logger.LogInformation("Update : {}", mdmCodeGroupSub1);
        try
        {
            var result = _mdmCodeGroupDao.UpdateDetail(mdmCodeGroupSub1);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCodeGroup/{categoryID}/Sub1/{codeID}")]
    public int DeleteDetail(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        _logger.LogInformation("Delete : {}", mdmCodeGroupSub1);
        try
        {
            var result = _mdmCodeGroupDao.DeleteDetail(mdmCodeGroupSub1);
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