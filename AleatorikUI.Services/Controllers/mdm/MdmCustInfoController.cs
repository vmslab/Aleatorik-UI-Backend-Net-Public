using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmCustInfoController : ControllerBase
{

    private readonly ILogger<MdmCustInfoController> _logger;
    private readonly IMdmCustInfoDao _mdmCustInfoDao;

    public MdmCustInfoController(ILogger<MdmCustInfoController> logger, IMdmCustInfoDao mdmCustInfoDao)
    {
        _logger = logger;
        _mdmCustInfoDao = mdmCustInfoDao;
    }

    [HttpGet("/api/MdmCustInfo")]
    public IEnumerable<MdmCustInfo> GetAll()
    {
        try
        {
            var result = _mdmCustInfoDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCustInfo>();
        }
    }

    [HttpPost("/api/MdmCustInfo")]
    public int Insert(MdmCustInfo mdmCustInfo)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmCustInfo);
            _mdmCustInfoDao.Insert(mdmCustInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmCustInfo/{customerID}")]
    public int Update(MdmCustInfo mdmCustInfo)
    {
        _logger.LogInformation("Update : {}", mdmCustInfo);
        try
        {
            var result = _mdmCustInfoDao.Update(mdmCustInfo);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmCustInfo/{customerID}")]
    public int Delete(MdmCustInfo mdmCustInfo)
    {
        _logger.LogInformation("Delete : {}", mdmCustInfo);
        try
        {
            var result = _mdmCustInfoDao.Delete(mdmCustInfo);
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