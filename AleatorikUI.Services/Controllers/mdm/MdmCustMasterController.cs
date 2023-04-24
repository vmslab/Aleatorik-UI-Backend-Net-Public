using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmCustMasterController : ControllerBase
{

    private readonly ILogger<MdmCustMasterController> _logger;
    private readonly IMdmCustMasterDao _mdmCustMasterDao;

    public MdmCustMasterController(ILogger<MdmCustMasterController> logger, IMdmCustMasterDao mdmCustMasterDao)
    {
        _logger = logger;
        _mdmCustMasterDao = mdmCustMasterDao;
    }
    /// <summary>
    /// 거래처 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustMaster"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmCustMaster")]
    public IEnumerable<MdmCustMaster> GetAll(String projectID, [FromQuery] MdmCustMaster mdmCustMaster)
    {
        try
        {
            mdmCustMaster.projectID = projectID;
            var result = _mdmCustMasterDao.GetAll(mdmCustMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCustMaster>();
        }
    }
    /// <summary>
    /// 거래처 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmCustMaster")]
    public int Insert(String projectID, MdmCustMaster mdmCustMaster)
    {
        try
        {
            mdmCustMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmCustMaster);
            _mdmCustMasterDao.Insert(mdmCustMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 거래처 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmCustMaster/{custID}")]
    public int Update(String projectID, MdmCustMaster mdmCustMaster)
    {
        _logger.LogInformation("Update : {}", mdmCustMaster);
        try
        {
            mdmCustMaster.projectID = projectID;
            var result = _mdmCustMasterDao.Update(mdmCustMaster);
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
    /// 거래처 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmCustMaster/{custID}")]
    public int Delete(String projectID, MdmCustMaster mdmCustMaster)
    {
        _logger.LogInformation("Delete : {}", mdmCustMaster);
        try
        {
            mdmCustMaster.projectID = projectID;
            var result = _mdmCustMasterDao.Delete(mdmCustMaster);
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
    /// 거래처정보 추가속성을 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmCustMaster/{custID}/PROP")]
    public IEnumerable<MdmCustProp> GetAllProp(String projectID, [FromQuery] MdmCustProp mdmCustProp)
    {
        try
        {
            mdmCustProp.projectID = projectID;
            var result = _mdmCustMasterDao.GetAllProp(mdmCustProp);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCustProp>();
        }
    }

    /// <summary>
    /// 거래처정보 추가속성을 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmCustMaster/{custID}/PROP")]
    public int InsertProp(String projectID, MdmCustProp mdmCustProp)
    {
        try
        {
            mdmCustProp.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmCustProp);
            _mdmCustMasterDao.InsertProp(mdmCustProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 거래처정보 추가속성을 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmCustMaster/{custID}/PROP/{propID}")]
    public int UpdateProp(String projectID, MdmCustProp mdmCustProp)
    {
        _logger.LogInformation("Update : {}", mdmCustProp);
        try
        {
            mdmCustProp.projectID = projectID;
            var result = _mdmCustMasterDao.UpdateProp(mdmCustProp);
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
    /// 거래처정보 추가속성을 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCustProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmCustMaster/{custID}/PROP/{propID}")]
    public int DeleteProp(String projectID, MdmCustProp mdmCustProp)
    {
        _logger.LogInformation("Delete : {}", mdmCustProp);
        try
        {
            mdmCustProp.projectID = projectID;
            var result = _mdmCustMasterDao.DeleteProp(mdmCustProp);
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