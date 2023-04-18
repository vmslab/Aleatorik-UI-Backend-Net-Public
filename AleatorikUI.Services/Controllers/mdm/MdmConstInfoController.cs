using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmConstInfoController : ControllerBase
{

    private readonly ILogger<MdmConstInfoController> _logger;
    private readonly IMdmConstInfoDao _mdmConstInfoDao;

    public MdmConstInfoController(ILogger<MdmConstInfoController> logger, IMdmConstInfoDao mdmConstInfoDao)
    {
        _logger = logger;
        _mdmConstInfoDao = mdmConstInfoDao;
    }

    [HttpGet("/api/MdmConstInfo")]
    public IEnumerable<MdmConstInfo> GetAll()
    {
        try
        {
            var result = _mdmConstInfoDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmConstInfo>();
        }
    }

    [HttpPost("/api/MdmConstInfo")]
    public int Insert(MdmConstInfo mdmConstInfo)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmConstInfo);
            _mdmConstInfoDao.Insert(mdmConstInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmConstInfo/{constraintID}")]
    public int Update(MdmConstInfo mdmConstInfo)
    {
        _logger.LogInformation("Update : {}", mdmConstInfo);
        try
        {
            var result = _mdmConstInfoDao.Update(mdmConstInfo);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmConstInfo/{constraintID}")]
    public int Delete(MdmConstInfo mdmConstInfo)
    {
        _logger.LogInformation("Delete : {}", mdmConstInfo);
        try
        {
            var result = _mdmConstInfoDao.Delete(mdmConstInfo);
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