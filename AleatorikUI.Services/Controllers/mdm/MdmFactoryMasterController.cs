using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmFactoryMasterController : ControllerBase
{

    private readonly ILogger<MdmFactoryMasterController> _logger;
    private readonly IMdmFactoryMasterDao _mdmFactoryMasterDao;

    public MdmFactoryMasterController(ILogger<MdmFactoryMasterController> logger, IMdmFactoryMasterDao mdmFactoryMasterDao)
    {
        _logger = logger;
        _mdmFactoryMasterDao = mdmFactoryMasterDao;
    }

    [HttpGet("/api/MdmFactoryMaster")]
    public IEnumerable<MdmFactoryMaster> GetAll()
    {
        try
        {
            var result = _mdmFactoryMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmFactoryMaster>();
        }
    }

    [HttpPost("/api/MdmFactoryMaster")]
    public int Insert(MdmFactoryMaster mdmFactoryMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmFactoryMaster);
            _mdmFactoryMasterDao.Insert(mdmFactoryMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmFactoryMaster/{factoryStartTime}")]
    public int Update(MdmFactoryMaster mdmFactoryMaster)
    {
        _logger.LogInformation("Update : {}", mdmFactoryMaster);
        try
        {
            var result = _mdmFactoryMasterDao.Update(mdmFactoryMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmFactoryMaster/{factoryStartTime}")]
    public int Delete(MdmFactoryMaster mdmFactoryMaster)
    {
        _logger.LogInformation("Delete : {}", mdmFactoryMaster);
        try
        {
            var result = _mdmFactoryMasterDao.Delete(mdmFactoryMaster);
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