using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmPropMasterController : ControllerBase
{

    private readonly ILogger<MdmPropMasterController> _logger;
    private readonly IMdmPropMasterDao _mdmPropMasterDao;

    public MdmPropMasterController(ILogger<MdmPropMasterController> logger, IMdmPropMasterDao mdmPropMasterDao)
    {
        _logger = logger;
        _mdmPropMasterDao = mdmPropMasterDao;
    }

    [HttpGet("/api/MdmPropMastery")]
    public IEnumerable<MdmPropMaster> GetAll()
    {
        try
        {
            var result = _mdmPropMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmPropMaster>();
        }
    }

    [HttpPost("/api/MdmPropMastery")]
    public int Insert(MdmPropMaster mdmPropMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmPropMaster);
            _mdmPropMasterDao.Insert(mdmPropMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmPropMastery/{propertyID}")]
    public int Update(MdmPropMaster mdmPropMaster)
    {
        _logger.LogInformation("Update : {}", mdmPropMaster);
        try
        {
            var result = _mdmPropMasterDao.Update(mdmPropMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmPropMastery/{propertyID}")]
    public int Delete(MdmPropMaster mdmPropMaster)
    {
        _logger.LogInformation("Delete : {}", mdmPropMaster);
        try
        {
            var result = _mdmPropMasterDao.Delete(mdmPropMaster);
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