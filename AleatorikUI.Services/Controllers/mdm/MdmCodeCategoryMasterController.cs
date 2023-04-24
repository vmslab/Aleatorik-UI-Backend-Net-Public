using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmCodeCategoryMasterController : ControllerBase
{

    private readonly ILogger<MdmCodeCategoryMasterController> _logger;
    private readonly IMdmCodeCategoryMasterDao _mdmCodeCategoryMasterDao;

    public MdmCodeCategoryMasterController(ILogger<MdmCodeCategoryMasterController> logger, IMdmCodeCategoryMasterDao mdmCodeCategoryMasterDao)
    {
        _logger = logger;
        _mdmCodeCategoryMasterDao = mdmCodeCategoryMasterDao;
    }
    /// <summary>
    /// 공통코드 Category 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeCategoryMaster"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmCodeCategoryMaster")]
    public IEnumerable<MdmCodeCategoryMaster> GetAll(String projectID, [FromQuery] MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        try
        {
            mdmCodeCategoryMaster.projectID = projectID;
            var result = _mdmCodeCategoryMasterDao.GetAll(mdmCodeCategoryMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCodeCategoryMaster>();
        }
    }
    /// <summary>
    /// 공통코드 Category 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeCategoryMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmCodeCategoryMaster")]
    public int Insert(String projectID, MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        try
        {
            mdmCodeCategoryMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmCodeCategoryMaster);
            _mdmCodeCategoryMasterDao.Insert(mdmCodeCategoryMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 공통코드 Category 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeCategoryMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmCodeCategoryMaster/{codeCategoryID}")]
    public int Update(String projectID, MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        _logger.LogInformation("Update : {}", mdmCodeCategoryMaster);
        try
        {
            mdmCodeCategoryMaster.projectID = projectID;
            var result = _mdmCodeCategoryMasterDao.Update(mdmCodeCategoryMaster);
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
    /// 공통코드 Category 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeCategoryMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmCodeCategoryMaster/{codeCategoryID}")]
    public int Delete(String projectID, MdmCodeCategoryMaster mdmCodeCategoryMaster)
    {
        _logger.LogInformation("Delete : {}", mdmCodeCategoryMaster);
        try
        {
            mdmCodeCategoryMaster.projectID = projectID;
            var result = _mdmCodeCategoryMasterDao.Delete(mdmCodeCategoryMaster);
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
    /// 공통코드 Master 정보를 조회 합니다.  
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeMaster"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmCodeCategoryMaster/{codeCategoryID}/Master")]
    public IEnumerable<MdmCodeMaster> GetAllMaster(String projectID, [FromQuery] MdmCodeMaster mdmCodeMaster)
    {
        try
        {
            mdmCodeMaster.projectID = projectID;
            var result = _mdmCodeCategoryMasterDao.GetAllMaster(mdmCodeMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCodeMaster>();
        }
    }
    /// <summary>
    /// 공통코드 Master 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmCodeCategoryMaster/{codeCategoryID}/Master")]
    public int InsertMaster(String projectID, MdmCodeMaster mdmCodeMaster)
    {
        try
        {
            mdmCodeMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmCodeMaster);
            _mdmCodeCategoryMasterDao.InsertMaster(mdmCodeMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 공통코드 Master 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmCodeCategoryMaster/{codeCategoryID}/Master/{codeID}")]
    public int UpdateMaster(String projectID, MdmCodeMaster mdmCodeMaster)
    {
        _logger.LogInformation("Update : {}", mdmCodeMaster);
        try
        {
            mdmCodeMaster.projectID = projectID;
            var result = _mdmCodeCategoryMasterDao.UpdateMaster(mdmCodeMaster);
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
    /// 공통코드 Master 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCodeMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmCodeCategoryMaster/{codeCategoryID}/Master/{codeID}")]
    public int DeleteMaster(String projectID, MdmCodeMaster mdmCodeMaster)
    {
        _logger.LogInformation("Delete : {}", mdmCodeMaster);
        try
        {
            mdmCodeMaster.projectID = projectID;
            var result = _mdmCodeCategoryMasterDao.DeleteMaster(mdmCodeMaster);
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