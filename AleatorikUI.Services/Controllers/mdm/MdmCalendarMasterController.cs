using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class MdmCalendarMasterController : ControllerBase
{

    private readonly ILogger<MdmCalendarMasterController> _logger;
    private readonly IMdmCalendarMasterDao _mdmCalendarMasterDao;

    public MdmCalendarMasterController(ILogger<MdmCalendarMasterController> logger, IMdmCalendarMasterDao mdmCalendarMasterDao)
    {
        _logger = logger;
        _mdmCalendarMasterDao = mdmCalendarMasterDao;
    }
    /// <summary>
    /// Calendar 정보를 조회 합니다. 
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarMaster"></param>
    /// <returns></returns>
    [HttpGet("/{projectID}/MdmCalendarMaster")]
    public IEnumerable<MdmCalendarMaster> GetAll(String projectID, [FromQuery] MdmCalendarMaster mdmCalendarMaster)
    {
        try
        {
            mdmCalendarMaster.projectID = projectID;
            var result = _mdmCalendarMasterDao.GetAll(mdmCalendarMaster);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCalendarMaster>();
        }
    }
    /// <summary>
    /// Calendar 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarMaster"></param>
    /// <returns></returns>
    [HttpPost("/{projectID}/MdmCalendarMaster")]
    public int Insert(String projectID, MdmCalendarMaster mdmCalendarMaster)
    {
        try
        {
            mdmCalendarMaster.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmCalendarMaster);
            _mdmCalendarMasterDao.Insert(mdmCalendarMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Calendar 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarMaster"></param>
    /// <returns></returns>
    [HttpPut("/{projectID}/MdmCalendarMaster/{calendarID}")]
    public int Update(String projectID, MdmCalendarMaster mdmCalendarMaster)
    {
        _logger.LogInformation("Update : {}", mdmCalendarMaster);
        try
        {
            mdmCalendarMaster.projectID = projectID;
            var result = _mdmCalendarMasterDao.Update(mdmCalendarMaster);
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
    /// Calendar 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarMaster"></param>
    /// <returns></returns>
    [HttpDelete("/{projectID}/MdmCalendarMaster/{calendarID}")]
    public int Delete(String projectID, MdmCalendarMaster mdmCalendarMaster)
    {
        _logger.LogInformation("Delete : {}", mdmCalendarMaster);
        try
        {
            mdmCalendarMaster.projectID = projectID;
            var result = _mdmCalendarMasterDao.Delete(mdmCalendarMaster);
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
    /// Calendar Detail 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarDetail"></param>
    /// <returns></returns>
    [HttpGet("/{projectID}/MdmCalendarMaster/{calendarID}/Detail")]
    public IEnumerable<MdmCalendarDetail> GetAllDetail(String projectID, [FromQuery] MdmCalendarDetail mdmCalendarDetail)
    {
        try
        {
            mdmCalendarDetail.projectID = projectID;
            var result = _mdmCalendarMasterDao.GetAllDetail(mdmCalendarDetail);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCalendarDetail>();
        }
    }
    /// <summary>
    /// Calendar Detail 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarDetail"></param>
    /// <returns></returns>
    [HttpPost("/{projectID}/MdmCalendarMaster/{calendarID}/Detail")]
    public int InsertDetail(String projectID, MdmCalendarDetail mdmCalendarDetail)
    {
        try
        {
            mdmCalendarDetail.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmCalendarDetail);
            _mdmCalendarMasterDao.InsertDetail(mdmCalendarDetail);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Calendar Detail 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarDetail"></param>
    /// <returns></returns>
    [HttpPut("/{projectID}/MdmCalendarMaster/{calendarID}/Detail/{patternID}")]
    public int UpdateDetail(String projectID, MdmCalendarDetail mdmCalendarDetail)
    {
        _logger.LogInformation("Update : {}", mdmCalendarDetail);
        try
        {
            mdmCalendarDetail.projectID = projectID;
            var result = _mdmCalendarMasterDao.UpdateDetail(mdmCalendarDetail);
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
    /// Calendar Detail 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarDetail"></param>
    /// <returns></returns>
    [HttpDelete("/{projectID}/MdmCalendarMaster/{calendarID}/Detail/{patternID}")]
    public int DeleteDetail(String projectID, MdmCalendarDetail mdmCalendarDetail)
    {
        _logger.LogInformation("Delete : {}", mdmCalendarDetail);
        try
        {
            mdmCalendarDetail.projectID = projectID;
            var result = _mdmCalendarMasterDao.DeleteDetail(mdmCalendarDetail);
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
    /// Calendar 캘린더속성값 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarBasedAttr"></param>
    /// <returns></returns>
    [HttpGet("/{projectID}/MdmCalendarMaster/{calendarID}/Detail/{patternID}/BasedAttr")]
    public IEnumerable<MdmCalendarBasedAttr> GetAllBasedAttr(String projectID, [FromQuery] MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        try
        {
            mdmCalendarBasedAttr.projectID = projectID;
            var result = _mdmCalendarMasterDao.GetAllBasedAttr(mdmCalendarBasedAttr);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCalendarBasedAttr>();
        }
    }
    /// <summary>
    /// Calendar 캘린더속성값 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarBasedAttr"></param>
    /// <returns></returns>
    [HttpPost("/{projectID}/MdmCalendarMaster/{calendarID}/Detail/{patternID}/BasedAttr")]
    public int InsertBasedAttr(String projectID, MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        try
        {
            mdmCalendarBasedAttr.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmCalendarBasedAttr);
            _mdmCalendarMasterDao.InsertBasedAttr(mdmCalendarBasedAttr);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Calendar 캘린더속성값 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarBasedAttr"></param>
    /// <returns></returns>
    [HttpPut("/{projectID}/MdmCalendarMaster/{calendarID}/Detail/{patternID}/BasedAttr/{attrType}")]
    public int UpdateBasedAttr(String projectID, MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        _logger.LogInformation("Update : {}", mdmCalendarBasedAttr);
        try
        {
            mdmCalendarBasedAttr.projectID = projectID;
            var result = _mdmCalendarMasterDao.UpdateBasedAttr(mdmCalendarBasedAttr);
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
    /// Calendar 캘린더속성값 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmCalendarBasedAttr"></param>
    /// <returns></returns>
    [HttpDelete("/{projectID}/MdmCalendarMaster/{calendarID}/Detail/{patternID}/BasedAttr/{attrType}")]
    public int DeleteBasedAttr(String projectID, MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        _logger.LogInformation("Delete : {}", mdmCalendarBasedAttr);
        try
        {
            mdmCalendarBasedAttr.projectID = projectID;
            var result = _mdmCalendarMasterDao.DeleteBasedAttr(mdmCalendarBasedAttr);
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