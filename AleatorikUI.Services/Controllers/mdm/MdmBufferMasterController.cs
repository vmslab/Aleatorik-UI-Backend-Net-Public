using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;


[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class MdmBufferMasterController : ControllerBase
{

    private readonly ILogger<MdmBufferMasterController> _logger;
    private readonly IMdmBufferMasterDao _mdmBufferMasterDao;

    public MdmBufferMasterController(ILogger<MdmBufferMasterController> logger, IMdmBufferMasterDao mdmBufferMasterDao)
    {
        _logger = logger;
        _mdmBufferMasterDao = mdmBufferMasterDao;
    }
    /// <summary>
    /// BUFFER 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferMaster"></param>
    /// <returns></returns>
    [HttpGet("/{projectID}/MdmBufferMaster")]
    public IEnumerable<MdmBufferMaster> GetAll(String projectID, [FromQuery] MdmBufferMaster mdmBufferMaster)
    {
        try
        {
            mdmBufferMaster.projectID = projectID;
            var result = _mdmBufferMasterDao.GetAll(mdmBufferMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBufferMaster>();
        }
    }
    /// <summary>
    /// BUFFER 정보를 추가 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferMaster"></param>
    /// <returns></returns>
    [HttpPost("/{projectID}/MdmBufferMaster")]
    public int Insert(String projectID, MdmBufferMaster mdmBufferMaster)
    {
        try
        {
            mdmBufferMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmBufferMaster);
            _mdmBufferMasterDao.Insert(mdmBufferMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BUFFER 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferMaster"></param>
    /// <returns></returns>
    [HttpPut("/{projectID}/MdmBufferMaster/{bufferID}")]
    public int Update(String projectID, MdmBufferMaster mdmBufferMaster)
    {
        _logger.LogInformation("Update : {}", mdmBufferMaster);
        try
        {
            mdmBufferMaster.projectID = projectID;
            var result = _mdmBufferMasterDao.Update(mdmBufferMaster);
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
    /// BUFFER 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferMaster"></param>
    /// <returns></returns>
    [HttpDelete("/{projectID}/MdmBufferMaster/{bufferID}")]
    public int Delete(String projectID, MdmBufferMaster mdmBufferMaster)
    {
        _logger.LogInformation("Delete : {}", mdmBufferMaster);
        try
        {
            mdmBufferMaster.projectID = projectID;
            var result = _mdmBufferMasterDao.Delete(mdmBufferMaster);
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
    /// BUFFER 정보 - PROP 를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferProp"></param>
    /// <returns></returns>
    [HttpGet("/{projectID}/MdmBufferProp/{bufferID}/PROP")]
    public IEnumerable<MdmBufferProp> GetAllProp(String projectID, [FromQuery] MdmBufferProp mdmBufferProp)
    {
        try
        {
            mdmBufferProp.projectID = projectID;
            var result = _mdmBufferMasterDao.GetAllProp(mdmBufferProp);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBufferProp>();
        }
    }
    /// <summary>
    /// BUFFER 정보 - PROP 를 추가 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferProp"></param>
    /// <returns></returns>
    [HttpPost("/{projectID}/MdmBufferProp/{bufferID}/PROP")]
    public int InsertProp(String projectID, MdmBufferProp mdmBufferProp)
    {
        try
        {
            mdmBufferProp.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmBufferProp);
            _mdmBufferMasterDao.InsertProp(mdmBufferProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BUFFER 정보 - PROP 를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferProp"></param>
    /// <returns></returns>
    [HttpPut("/{projectID}/MdmBufferProp/{bufferID}/PROP/{propID}")]
    public int UpdateProp(String projectID, MdmBufferProp mdmBufferProp)
    {
        _logger.LogInformation("Update : {}", mdmBufferProp);
        try
        {
            mdmBufferProp.projectID = projectID;
            var result = _mdmBufferMasterDao.UpdateProp(mdmBufferProp);
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
    /// BUFFER 정보 - PROP 를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmBufferProp"></param>
    /// <returns></returns>
    [HttpDelete("/{projectID}/MdmBufferProp/{bufferID}/PROP/{propID}")]
    public int DeleteProp(String projectID, MdmBufferProp mdmBufferProp)
    {
        _logger.LogInformation("Delete : {}", mdmBufferProp);
        try
        {
            mdmBufferProp.projectID = projectID;
            var result = _mdmBufferMasterDao.DeleteProp(mdmBufferProp);
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