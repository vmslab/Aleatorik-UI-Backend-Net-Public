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
    /// Demand Ãß°¡
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

    [HttpPut("/api/MdmDemand/{soID}")]
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

    [HttpDelete("/api/MdmDemand/{soID}")]
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
}