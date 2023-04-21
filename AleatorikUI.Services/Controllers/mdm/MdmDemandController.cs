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
    /// Demand 를 조회 합니다.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/MdmDemand")]
    public IEnumerable<MdmDemand> GetAll()
    {
        try
        {
            var result = _mdmDemandDao.GetAll();
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
    /// DEMAND 를 추가 합니다.
    /// </summary>
    /// <param name="mdmDemand"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmDemand")]
    public int Insert(MdmDemand mdmDemand)
    {
        try
        {
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
    /// <param name="mdmDemand"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmDemand/{demandID}")]
    public int Update(MdmDemand mdmDemand)
    {
        _logger.LogInformation("Update : {}", mdmDemand);
        try
        {
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
    /// <param name="mdmDemand"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmDemand/{demandID}")]
    public int Delete(MdmDemand mdmDemand)
    {
        _logger.LogInformation("Delete : {}", mdmDemand);
        try
        {
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
    /// Demand PROP 를 조회 합니다.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/MdmDemand/{demandID}/PROP")]
    public IEnumerable<MdmDemandProp> GetAllProp(String demandID)
    {
        try
        {
            var result = _mdmDemandDao.GetAllProp(demandID);
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
    /// DEMAND PROP 를 추가 합니다.
    /// </summary>
    /// <param name="MdmDemandProp"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmDemand/{demandID}/PROP")]
    public int InsertProp(MdmDemandProp mdmDemandProp)
    {
        try
        {
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
    /// DEMAND PROP 를 수정 합니다.
    /// </summary>
    /// <param name="MdmDemandProp"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmDemandProp/{demandID}/PROP/{propID}")]
    public int UpdateProp(MdmDemandProp mdmDemandProp)
    {
        _logger.LogInformation("Update : {}", mdmDemandProp);
        try
        {
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
    /// DEMAND PROP 를 삭제 합니다.
    /// </summary>
    /// <param name="MdmDemandProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmDemandProp/{demandID}/PROP/{propID}")]
    public int DeleteProp(MdmDemandProp mdmDemandProp)
    {
        _logger.LogInformation("Delete : {}", mdmDemandProp);
        try
        {
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