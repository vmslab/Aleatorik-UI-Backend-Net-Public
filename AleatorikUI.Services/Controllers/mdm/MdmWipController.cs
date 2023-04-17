using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmWipController : ControllerBase
{

    private readonly ILogger<MdmWipController> _logger;
    private readonly IMdmWipDao _mdmWipDao;

    public MdmWipController(ILogger<MdmWipController> logger, IMdmWipDao mdmWipDao)
    {
        _logger = logger;
        _mdmWipDao = mdmWipDao;
    }

    [HttpGet("/api/MdmWip")]
    public IEnumerable<MdmWip> GetAll()
    {
        try
        {
            var result = _mdmWipDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmWip>();
        }
    }

    [HttpPost("/api/MdmWip")]
    public int Insert(MdmWip mdmWip)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmWip);
            _mdmWipDao.Insert(mdmWip);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmWip/{lotID}")]
    public int Update(MdmWip mdmWip)
    {
        _logger.LogInformation("Update : {}", mdmWip);
        try
        {
            var result = _mdmWipDao.Update(mdmWip);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmWip/{lotID}")]
    public int Delete(MdmWip mdmWip)
    {
        _logger.LogInformation("Delete : {}", mdmWip);
        try
        {
            var result = _mdmWipDao.Delete(mdmWip);
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