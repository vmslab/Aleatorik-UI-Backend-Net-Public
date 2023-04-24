using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.iod;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmDemandController : ControllerBase
{

    private readonly ILogger<MdmDemandController> _logger;
    private readonly IMdmDemandDao _mdmDemandDao;

    public MdmDemandController(ILogger<MdmDemandController> logger, IMdmDemandDao mdmDemandDao)
    {
        _logger = logger;
        _mdmDemandDao = mdmDemandDao;
    }

    /// <summary>
    /// DEMAND 를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemand"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmDemand")]
    public IEnumerable<MdmDemand> GetAll(String projectID, [FromQuery] MdmDemand mdmDemand)
    {
        try
        {
            mdmDemand.projectID = projectID;
            var result = _mdmDemandDao.GetAll(mdmDemand);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmDemand>();
        }
    }
    /// <summary>
    /// DEMAND 를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemand"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmDemand")]
    public int Insert(String projectID, MdmDemand mdmDemand)
    {
        try
        {
            mdmDemand.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmDemand);
            _mdmDemandDao.Insert(mdmDemand);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// DEMAND 를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemand"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmDemand/{demandID}")]
    public int Update(String projectID, MdmDemand mdmDemand)
    {
        _logger.LogInformation("Update : {}", mdmDemand);
        try
        {
            mdmDemand.projectID = projectID;
            var result = _mdmDemandDao.Update(mdmDemand);
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
    /// DEMAND 를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemand"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmDemand/{demandID}")]
    public int Delete(String projectID, MdmDemand mdmDemand)
    {
        _logger.LogInformation("Delete : {}", mdmDemand);
        try
        {
            mdmDemand.projectID = projectID;
            var result = _mdmDemandDao.Delete(mdmDemand);
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
    /// DEMAND 추가속석을 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemandProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmDemand/{demandID}/PROP")]
    public IEnumerable<MdmDemandProp> GetAllProp(String projectID, [FromQuery] MdmDemandProp mdmDemandProp)
    {
        try
        {
            mdmDemandProp.projectID = projectID;
            var result = _mdmDemandDao.GetAllProp(mdmDemandProp);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmDemandProp>();
        }
    }
    /// <summary>
    /// DEMAND 추가속석을 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemandProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmDemand/{demandID}/PROP")]
    public int InsertProp(String projectID, MdmDemandProp mdmDemandProp)
    {
        try
        {
            mdmDemandProp.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmDemandProp);
            _mdmDemandDao.InsertProp(mdmDemandProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// DEMAND 추가속석을 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemandProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmDemandProp/{demandID}/PROP/{propID}")]
    public int UpdateProp(String projectID, MdmDemandProp mdmDemandProp)
    {
        _logger.LogInformation("Update : {}", mdmDemandProp);
        try
        {
            mdmDemandProp.projectID = projectID;
            var result = _mdmDemandDao.UpdateProp(mdmDemandProp);
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
    /// DEMAND 추가속석을 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmDemandProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmDemandProp/{demandID}/PROP/{propID}")]
    public int DeleteProp(String projectID, MdmDemandProp mdmDemandProp)
    {
        _logger.LogInformation("Delete : {}", mdmDemandProp);
        try
        {
            mdmDemandProp.projectID = projectID;
            var result = _mdmDemandDao.DeleteProp(mdmDemandProp);
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