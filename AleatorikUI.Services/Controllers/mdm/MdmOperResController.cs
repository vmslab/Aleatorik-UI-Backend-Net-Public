using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmOperResController : ControllerBase
{

    private readonly ILogger<MdmOperResController> _logger;
    private readonly IMdmOperResDao _mdmOperResDao;

    public MdmOperResController(ILogger<MdmOperResController> logger, IMdmOperResDao mdmOperResDao)
    {
        _logger = logger;
        _mdmOperResDao = mdmOperResDao;
    }
    /// <summary>
    /// Operation Resource 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperRes"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmOperRes")]
    public IEnumerable<MdmOperRes> GetAll(String projectID, [FromQuery] MdmOperRes mdmOperRes)
    {
        try
        {
            mdmOperRes.projectID = projectID;
            var result = _mdmOperResDao.GetAll(mdmOperRes);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmOperRes>();
        }
    }
    /// <summary>
    /// Operation Resource 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperRes"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmOperRes")]
    public int Insert(String projectID, MdmOperRes mdmOperRes)
    {
        try
        {
            mdmOperRes.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmOperRes);
            _mdmOperResDao.Insert(mdmOperRes);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Operation Resource 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperRes"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmOperRes/{resID}")]
    public int Update(String projectID, MdmOperRes mdmOperRes)
    {
        _logger.LogInformation("Update : {}", mdmOperRes);
        try
        {
            mdmOperRes.projectID = projectID;
            var result = _mdmOperResDao.Update(mdmOperRes);
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
    /// Operation Resource 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperRes"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmOperRes/{resID}")]
    public int Delete(String projectID, MdmOperRes mdmOperRes)
    {
        _logger.LogInformation("Delete : {}", mdmOperRes);
        try
        {
            mdmOperRes.projectID = projectID;
            var result = _mdmOperResDao.Delete(mdmOperRes);
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
    /// Operation Resource 추가속성을 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperResProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmOperRes/{resID}/Prop")]
    public IEnumerable<MdmOperResProp> GetAllProp(String projectID, [FromQuery] MdmOperResProp mdmOperResProp)
    {
        try
        {
            mdmOperResProp.projectID = projectID;
            var result = _mdmOperResDao.GetAllProp(mdmOperResProp);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmOperResProp>();
        }
    }
    /// <summary>
    /// Operation Resource 추가속성을 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperResProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmOperRes/{resID}/Prop")]
    public int InsertProp(String projectID, MdmOperResProp mdmOperResProp)
    {
        try
        {
            mdmOperResProp.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmOperResProp);
            _mdmOperResDao.InsertProp(mdmOperResProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Operation Resource 추가속성을 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperResProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmOperRes/{resID}/Prop/{propID}")]
    public int UpdateProp(String projectID, MdmOperResProp mdmOperResProp)
    {
        _logger.LogInformation("Update : {}", mdmOperResProp);
        try
        {
            mdmOperResProp.projectID = projectID;
            var result = _mdmOperResDao.UpdateProp(mdmOperResProp);
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
    /// Operation Resource 추가속성을 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperResProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmOperRes/{resID}/Prop/{propID}")]
    public int DeleteProp(String projectID, MdmOperResProp mdmOperResProp)
    {
        _logger.LogInformation("Delete : {}", mdmOperResProp);
        try
        {
            mdmOperResProp.projectID = projectID;
            var result = _mdmOperResDao.DeleteProp(mdmOperResProp);
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
    /// Operation Resource Add Resource 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddRes"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmOperRes/{resID}/AddRes")]
    public IEnumerable<MdmOperAddRes> GetAllAddRes(String projectID, [FromQuery] MdmOperAddRes mdmOperAddRes)
    {
        try
        {
            mdmOperAddRes.projectID = projectID;
            var result = _mdmOperResDao.GetAllAddRes(mdmOperAddRes);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmOperAddRes>();
        }
    }
    /// <summary>
    /// Operation Resource Add Resource 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddRes"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmOperRes/{resID}/AddRes")]
    public int InsertAddRes(String projectID, MdmOperAddRes mdmOperAddRes)
    {
        try
        {
            mdmOperAddRes.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmOperAddRes);
            _mdmOperResDao.InsertAddRes(mdmOperAddRes);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Operation Resource Add Resource 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddRes"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmOperRes/{resID}/AddRes/{addResID}")]
    public int UpdateAddRes(String projectID, MdmOperAddRes mdmOperAddRes)
    {
        _logger.LogInformation("Update : {}", mdmOperAddRes);
        try
        {
            mdmOperAddRes.projectID = projectID;
            var result = _mdmOperResDao.UpdateAddRes(mdmOperAddRes);
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
    /// Operation Resource Add Resource 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddRes"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmOperRes/{resID}/AddRes/{addResID}")]
    public int DeleteAddRes(String projectID, MdmOperAddRes mdmOperAddRes)
    {
        _logger.LogInformation("Delete : {}", mdmOperAddRes);
        try
        {
            mdmOperAddRes.projectID = projectID;
            var result = _mdmOperResDao.DeleteAddRes(mdmOperAddRes);
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
    /// Operation Resource Add Resource 추가속성을 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddResProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmOperRes/{resID}/AddRes/{addResID}/Prop")]
    public IEnumerable<MdmOperAddResProp> GetAllAddResProp(String projectID, [FromQuery] MdmOperAddResProp mdmOperAddResProp)
    {
        try
        {
            mdmOperAddResProp.projectID = projectID;
            var result = _mdmOperResDao.GetAllAddResProp(mdmOperAddResProp);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmOperAddResProp>();
        }
    }
    /// <summary>
    /// Operation Resource Add Resource 추가속성을 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddResProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmOperRes/{resID}/AddRes/{addResID}/Prop")]
    public int InsertAddResProp(String projectID, MdmOperAddResProp mdmOperAddResProp)
    {
        try
        {
            mdmOperAddResProp.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmOperAddResProp);
            _mdmOperResDao.InsertAddResProp(mdmOperAddResProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// Operation Resource Add Resource 추가속성을 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddResProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmOperRes/{resID}/AddRes/{addResID}/Prop/{propID}")]
    public int UpdateAddResProp(String projectID, MdmOperAddResProp mdmOperAddResProp)
    {
        _logger.LogInformation("Update : {}", mdmOperAddResProp);
        try
        {
            mdmOperAddResProp.projectID = projectID;
            var result = _mdmOperResDao.UpdateAddResProp(mdmOperAddResProp);
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
    /// Operation Resource Add Resource 추가속성을 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmOperAddResProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmOperRes/{resID}/AddRes/{addResID}/Prop/{propID}")]
    public int DeleteAddResProp(String projectID, MdmOperAddResProp mdmOperAddResProp)
    {
        _logger.LogInformation("Delete : {}", mdmOperAddResProp);
        try
        {
            mdmOperAddResProp.projectID = projectID;
            var result = _mdmOperResDao.DeleteAddResProp(mdmOperAddResProp);
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