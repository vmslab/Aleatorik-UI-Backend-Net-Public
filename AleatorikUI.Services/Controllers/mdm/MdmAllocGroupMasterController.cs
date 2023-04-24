using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class MdmAllocGroupMasterController : ControllerBase
{
    private readonly ILogger<MdmAllocGroupMasterController> _logger;
    private readonly IMdmAllocGroupMasterDao _mdmAllocGroupMasterDao;

    public MdmAllocGroupMasterController(ILogger<MdmAllocGroupMasterController> logger, IMdmAllocGroupMasterDao mdmAllocGroupMasterDao)
    {
        _logger = logger;
        _mdmAllocGroupMasterDao = mdmAllocGroupMasterDao;
    }
    /// <summary>
    ///  Allocation Group 을 조회 합니다.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmAllocGroupMaster/")]
    public IEnumerable<MdmAllocGroupMaster> GetAll(string projectID, [FromQuery] MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        try
        {
            mdmAllocGroupMaster.projectID = projectID;
            var result = _mdmAllocGroupMasterDao.GetAll(mdmAllocGroupMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmAllocGroupMaster>();
        }
    }
    /// <summary>
    /// Allocation Group 을 추가 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmAllocGroupMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmAllocGroupMaster/")]
    public int Insert(string projectID, MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        try
        {
            mdmAllocGroupMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmAllocGroupMaster);
            _mdmAllocGroupMasterDao.Insert(mdmAllocGroupMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    /// <summary>
    /// Allocation Group 을 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmAllocGroupMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmAllocGroupMaster/{allocGroupID}")]
    public int Update(string projectID, MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        _logger.LogInformation("Update : {}", mdmAllocGroupMaster);
        try
        {
            mdmAllocGroupMaster.projectID = projectID;
            var result = _mdmAllocGroupMasterDao.Update(mdmAllocGroupMaster);
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
    /// Allocation Group 을 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmAllocGroupMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmAllocGroupMaster/{allocGroupID}")]
    public int Delete(string projectID, MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        _logger.LogInformation("Delete : {}", mdmAllocGroupMaster);
        try
        {
            mdmAllocGroupMaster.projectID = projectID;
            var result = _mdmAllocGroupMasterDao.Delete(mdmAllocGroupMaster);
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