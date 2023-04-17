using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmSetupInfoController : ControllerBase
{

    private readonly ILogger<MdmSetupInfoController> _logger;
    private readonly IMdmSetupInfoDao _mdmSetupInfoDao;

    public MdmSetupInfoController(ILogger<MdmSetupInfoController> logger, IMdmSetupInfoDao mdmSetupInfoDao)
    {
        _logger = logger;
        _mdmSetupInfoDao = mdmSetupInfoDao;
    }

    [HttpGet("/api/MdmSetupInfo")]
    public IEnumerable<MdmSetupInfo> GetAll()
    {
        try
        {
            var result = _mdmSetupInfoDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmSetupInfo>();
        }
    }

    [HttpPost("/api/MdmSetupInfo")]
    public int Insert(MdmSetupInfo mdmSetupInfo)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmSetupInfo);
            _mdmSetupInfoDao.Insert(mdmSetupInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmSetupInfo/{setupID}")]
    public int Update(MdmSetupInfo mdmSetupInfo)
    {
        _logger.LogInformation("Update : {}", mdmSetupInfo);
        try
        {
            var result = _mdmSetupInfoDao.Update(mdmSetupInfo);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmSetupInfo/{setupID}")]
    public int Delete(MdmSetupInfo mdmSetupInfo)
    {
        _logger.LogInformation("Delete : {}", mdmSetupInfo);
        try
        {
            var result = _mdmSetupInfoDao.Delete(mdmSetupInfo);
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