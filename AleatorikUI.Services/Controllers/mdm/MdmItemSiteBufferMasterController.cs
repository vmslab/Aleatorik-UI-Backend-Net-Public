using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmItemSiteBufferMasterController : ControllerBase
{

    private readonly ILogger<MdmItemSiteBufferMasterController> _logger;
    private readonly IMdmItemSiteBufferMasterDao _mdmItemSiteBufferMasterDao;

    public MdmItemSiteBufferMasterController(ILogger<MdmItemSiteBufferMasterController> logger, IMdmItemSiteBufferMasterDao mdmItemSiteBufferMasterDao)
    {
        _logger = logger;
        _mdmItemSiteBufferMasterDao = mdmItemSiteBufferMasterDao;
    }
    /// <summary>
    /// ISB 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferMaster"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmItemSiteBufferMaster")]
    public IEnumerable<MdmItemSiteBufferMaster> GetAll(String projectID, [FromQuery] MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        try
        {
            mdmItemSiteBufferMaster.projectID = projectID;
            var result = _mdmItemSiteBufferMasterDao.GetAll(mdmItemSiteBufferMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmItemSiteBufferMaster>();
        }
    }
    /// <summary>
    /// ISB 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmItemSiteBufferMaster")]
    public int Insert(String projectID, MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        try
        {
            mdmItemSiteBufferMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmItemSiteBufferMaster);
            _mdmItemSiteBufferMasterDao.Insert(mdmItemSiteBufferMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// ISB 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmItemSiteBufferMaster/{itemID}/{siteID}/{bufferID}")]
    public int Update(String projectID, MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        _logger.LogInformation("Update : {}", mdmItemSiteBufferMaster);
        try
        {
            mdmItemSiteBufferMaster.projectID = projectID;
            var result = _mdmItemSiteBufferMasterDao.Update(mdmItemSiteBufferMaster);
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
    /// ISB 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmItemSiteBufferMaster/{itemID}/{siteID}/{bufferID}")]
    public int Delete(String projectID, MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        _logger.LogInformation("Delete : {}", mdmItemSiteBufferMaster);
        try
        {
            mdmItemSiteBufferMaster.projectID = projectID;
            var result = _mdmItemSiteBufferMasterDao.Delete(mdmItemSiteBufferMaster);
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
    /// ISB 추가속성을 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmItemSiteBufferMaster/{itemID}/{siteID}/{bufferID}/PROP")]
    public IEnumerable<MdmItemSiteBufferProp> GetAllProp(String projectID, [FromQuery] MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        try
        {
            mdmItemSiteBufferProp.projectID = projectID;
            var result = _mdmItemSiteBufferMasterDao.GetAllProp(mdmItemSiteBufferProp);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmItemSiteBufferProp>();
        }
    }

    /// <summary>
    /// ISB 추가속성 를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmItemSiteBufferMaster/{itemID}/{siteID}/{bufferID}/PROP")]
    public int InsertProp(String projectID, MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        try
        {
            mdmItemSiteBufferProp.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmItemSiteBufferProp);
            _mdmItemSiteBufferMasterDao.InsertProp(mdmItemSiteBufferProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// ISB 추가속성을 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmItemSiteBufferMaster/{itemID}/{siteID}/{bufferID}/PROP/{propID}")]
    public int UpdateProp(String projectID, MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        _logger.LogInformation("Update : {}", mdmItemSiteBufferProp);
        try
        {
            mdmItemSiteBufferProp.projectID = projectID;
            var result = _mdmItemSiteBufferMasterDao.UpdateProp(mdmItemSiteBufferProp);
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
    /// ISB 추가속성을 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmItemSiteBufferProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmItemSiteBufferMaster/{itemID}/{siteID}/{bufferID}/PROP/{propID}")]
    public int DeleteProp(String projectID, MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        _logger.LogInformation("Delete : {}", mdmItemSiteBufferProp);
        try
        {
            mdmItemSiteBufferProp.projectID = projectID;
            var result = _mdmItemSiteBufferMasterDao.DeleteProp(mdmItemSiteBufferProp);
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