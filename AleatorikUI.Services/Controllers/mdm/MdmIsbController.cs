using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmIsbController : ControllerBase
{

    private readonly ILogger<MdmIsbController> _logger;
    private readonly IMdmIsbDao _mdmIsbDao;

    public MdmIsbController(ILogger<MdmIsbController> logger, IMdmIsbDao mdmIsbDao)
    {
        _logger = logger;
        _mdmIsbDao = mdmIsbDao;
    }

    [HttpGet("/api/MdmIsb")]
    public IEnumerable<MdmIsb> GetAll()
    {
        try
        {
            var result = _mdmIsbDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmIsb>();
        }
    }

    [HttpPost("/api/MdmIsb")]
    public int Insert(MdmIsb mdmIsb)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmIsb);
            _mdmIsbDao.Insert(mdmIsb);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmIsb/{itemID}/{siteID}/{bufferID}")]
    public int Update(MdmIsb mdmIsb)
    {
        _logger.LogInformation("Update : {}", mdmIsb);
        try
        {
            var result = _mdmIsbDao.Update(mdmIsb);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmIsb/{itemID}/{siteID}/{bufferID}")]
    public int Delete(MdmIsb mdmIsb)
    {
        _logger.LogInformation("Delete : {}", mdmIsb);
        try
        {
            var result = _mdmIsbDao.Delete(mdmIsb);
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