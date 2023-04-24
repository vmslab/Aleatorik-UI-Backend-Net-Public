using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmItemMasterController : ControllerBase
{

    private readonly ILogger<MdmItemMasterController> _logger;
    private readonly IMdmItemMasterDao _mdmItemMasterDao;

    public MdmItemMasterController(ILogger<MdmItemMasterController> logger, IMdmItemMasterDao mdmItemMasterDao)
    {
        _logger = logger;
        _mdmItemMasterDao = mdmItemMasterDao;
    }
    /// <summary>
    /// 품목 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemMaster"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmItemMaster")]
    public IEnumerable<MdmItemMaster> GetAll(String projectID, [FromQuery] MdmItemMaster mdmItemMaster)
    {
        try
        {
            mdmItemMaster.projectID = projectID;
            var result = _mdmItemMasterDao.GetAll(mdmItemMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmItemMaster>();
        }
    }
    /// <summary>
    /// 품목 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmItemMaster")]
    public int Insert(String projectID, MdmItemMaster mdmItemMaster)
    {
        try
        {
            mdmItemMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmItemMaster);
            _mdmItemMasterDao.Insert(mdmItemMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 품목 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmItemMaster/{itemID}")]
    public int Update(String projectID, MdmItemMaster mdmItemMaster)
    {
        _logger.LogInformation("Update : {}", mdmItemMaster);
        try
        {
            mdmItemMaster.projectID = projectID;
            var result = _mdmItemMasterDao.Update(mdmItemMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 품목 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmItemMaster/{itemID}")]
    public int Delete(String projectID, MdmItemMaster mdmItemMaster)
    {
        _logger.LogInformation("Delete : {}", mdmItemMaster);
        try
        {
            mdmItemMaster.projectID = projectID;
            var result = _mdmItemMasterDao.Delete(mdmItemMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 품목정보 추가속성을 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmItemMaster/{itemID}/PROP")]
    public IEnumerable<MdmItemProp> GetAllProp(String projectID, [FromQuery] MdmItemProp mdmItemProp)
    {
        try
        {
            mdmItemProp.projectID = projectID;
            var result = _mdmItemMasterDao.GetAllProp(mdmItemProp);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmItemProp>();
        }
    }

    /// <summary>
    /// 품목정보 추가속성 를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmItemMaster/{itemID}/PROP")]
    public int InsertProp(String projectID, MdmItemProp mdmItemProp)
    {
        try
        {
            mdmItemProp.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmItemProp);
            _mdmItemMasterDao.InsertProp(mdmItemProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 품목정보 추가속성을 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmItemMaster/{itemID}/PROP/{propID}")]
    public int UpdateProp(String projectID, MdmItemProp mdmItemProp)
    {
        _logger.LogInformation("Update : {}", mdmItemProp);
        try
        {
            mdmItemProp.projectID = projectID;
            var result = _mdmItemMasterDao.UpdateProp(mdmItemProp);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    /// <summary>
    /// 품목정보 추가속성을 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmItemMaster/{itemID}/PROP/{propID}")]
    public int DeleteProp(String projectID, MdmItemProp mdmItemProp)
    {
        _logger.LogInformation("Delete : {}", mdmItemProp);
        try
        {
            mdmItemProp.projectID = projectID;
            var result = _mdmItemMasterDao.DeleteProp(mdmItemProp);
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