using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
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
    [HttpGet("/api/MdmAllocGroupMaster/{projectID}")]
    public IEnumerable<MdmAllocGroupMaster> GetAll(String projectID)
    {
        try
        {
            var result = _mdmAllocGroupMasterDao.GetAll(projectID);
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
    /// <param name="mdmAllocGroupMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmAllocGroupMaster/{projectID}")]
    public int Insert(MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        try
        {
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
    ///  Allocation Group 을 수정 합니다.
    /// </summary>
    /// <param name="mdmAllocGroupMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmAllocGroupMaster/{projectID}/{allocGroupID}")]
    public int Update(MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        _logger.LogInformation("Update : {}", mdmAllocGroupMaster);
        try
        {
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
    ///  Allocation Group 을 삭제 합니다.
    /// </summary>
    /// <param name="mdmAllocGroupMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmAllocGroupMaster/{projectID}/{allocGroupID}")]
    public int Delete(MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        _logger.LogInformation("Delete : {}", mdmAllocGroupMaster);
        try
        {
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