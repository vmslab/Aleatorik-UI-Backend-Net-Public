using AleatorikUI.Services.DAO.plm;
using AleatorikUI.Services.DTO.plm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.plm;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class PlmFactorMasterController : ControllerBase
{
    private readonly ILogger<PlmFactorMasterController> _logger;
    private readonly IPlmFactorMasterDao _plmFactorMasterDao;

    public PlmFactorMasterController(ILogger<PlmFactorMasterController> logger, IPlmFactorMasterDao plmFactorMasterDao)
    {
        _logger = logger;
        _plmFactorMasterDao = plmFactorMasterDao;
    }
    /// <summary>
    /// Factor 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="plmFactorMaster"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/PlmFactorMaster/")]
    public IEnumerable<PlmFactorMaster> GetAll(string projectID, [FromQuery] PlmFactorMaster plmFactorMaster)
    {
        try
        {
            plmFactorMaster.projectID = projectID;
            var result = _plmFactorMasterDao.GetAll(plmFactorMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<PlmFactorMaster>();
        }
    }
    /// <summary>
    /// Factor 정보를 추가 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="plmFactorMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/PlmFactorMaster/")]
    public int Insert(string projectID, PlmFactorMaster plmFactorMaster)
    {
        try
        {
            plmFactorMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", plmFactorMaster);
            _plmFactorMasterDao.Insert(plmFactorMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    /// <summary>
    /// Factor 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="plmFactorMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/PlmFactorMaster/{rulePoint}")]
    public int Update(string projectID, PlmFactorMaster plmFactorMaster)
    {
        _logger.LogInformation("Update : {}", plmFactorMaster);
        try
        {
            plmFactorMaster.projectID = projectID;
            var result = _plmFactorMasterDao.Update(plmFactorMaster);
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
    /// Factor 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="plmFactorMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/PlmFactorMaster/{rulePoint}")]
    public int Delete(string projectID, PlmFactorMaster plmFactorMaster)
    {
        _logger.LogInformation("Delete : {}", plmFactorMaster);
        try
        {
            plmFactorMaster.projectID = projectID;
            var result = _plmFactorMasterDao.Delete(plmFactorMaster);
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