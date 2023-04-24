using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmConstraintController : ControllerBase
{

    private readonly ILogger<MdmConstraintController> _logger;
    private readonly IMdmConstraintDao _mdmConstraintDao;

    public MdmConstraintController(ILogger<MdmConstraintController> logger, IMdmConstraintDao mdmConstraintDao)
    {
        _logger = logger;
        _mdmConstraintDao = mdmConstraintDao;
    }
    /// <summary>
    /// Constraint 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmConstraint"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmConstraint")]
    public IEnumerable<MdmConstraint> GetAll(String projectID, [FromQuery] MdmConstraint mdmConstraint)
    {
        try
        {
            mdmConstraint.projectID = projectID;
            var result = _mdmConstraintDao.GetAll(mdmConstraint);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmConstraint>();
        }
    }
    /// <summary>
    /// Constraint 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmConstraint"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmConstraint")]
    public int Insert(String projectID, MdmConstraint mdmConstraint)
    {
        try
        {
            mdmConstraint.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmConstraint);
            _mdmConstraintDao.Insert(mdmConstraint);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Constraint 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmConstraint"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmConstraint/{constraintID}")]
    public int Update(String projectID, MdmConstraint mdmConstraint)
    {
        _logger.LogInformation("Update : {}", mdmConstraint);
        try
        {
            mdmConstraint.projectID = projectID;
            var result = _mdmConstraintDao.Update(mdmConstraint);
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
    /// Constraint 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmConstraint"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmConstraint/{constraintID}")]
    public int Delete(String projectID, MdmConstraint mdmConstraint)
    {
        _logger.LogInformation("Delete : {}", mdmConstraint);
        try
        {
            mdmConstraint.projectID = projectID;
            var result = _mdmConstraintDao.Delete(mdmConstraint);
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