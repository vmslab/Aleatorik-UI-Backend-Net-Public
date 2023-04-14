using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmPropertyController : ControllerBase
{

    private readonly ILogger<MdmPropertyController> _logger;
    private readonly IMdmPropertyDao _mdmPropertyDao;

    public MdmPropertyController(ILogger<MdmPropertyController> logger, IMdmPropertyDao mdmPropertyDao)
    {
        _logger = logger;
        _mdmPropertyDao = mdmPropertyDao;
    }

    [HttpGet("/api/MdmProperty")]
    public IEnumerable<MdmProperty> GetAll()
    {
        try
        {
            var result = _mdmPropertyDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmProperty>();
        }
    }

    [HttpPost("/api/MdmProperty")]
    public int Insert(MdmProperty mdmProperty)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmProperty);
            _mdmPropertyDao.Insert(mdmProperty);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmProperty/{propertyID}")]
    public int Update(MdmProperty mdmProperty)
    {
        _logger.LogInformation("Update : {}", mdmProperty);
        try
        {
            var result = _mdmPropertyDao.Update(mdmProperty);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmProperty/{propertyID}")]
    public int Delete(MdmProperty mdmProperty)
    {
        _logger.LogInformation("Delete : {}", mdmProperty);
        try
        {
            var result = _mdmPropertyDao.Delete(mdmProperty);
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