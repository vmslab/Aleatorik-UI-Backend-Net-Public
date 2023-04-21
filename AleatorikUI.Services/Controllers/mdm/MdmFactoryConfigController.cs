using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmFactoryConfigController : ControllerBase
{

    private readonly ILogger<MdmFactoryConfigController> _logger;
    private readonly IMdmFactoryConfigDao _mdmFactoryConfigDao;

    public MdmFactoryConfigController(ILogger<MdmFactoryConfigController> logger, IMdmFactoryConfigDao mdmFactoryConfigDao)
    {
        _logger = logger;
        _mdmFactoryConfigDao = mdmFactoryConfigDao;
    }

    [HttpGet("/api/MdmFactoryConfig")]
    public IEnumerable<MdmFactoryConfig> GetAll()
    {
        try
        {
            var result = _mdmFactoryConfigDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmFactoryConfig>();
        }
    }

    [HttpPost("/api/MdmFactoryConfig")]
    public int Insert(MdmFactoryConfig mdmFactoryConfig)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmFactoryConfig);
            _mdmFactoryConfigDao.Insert(mdmFactoryConfig);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmFactoryConfig/{factoryStartTime}")]
    public int Update(MdmFactoryConfig mdmFactoryConfig)
    {
        _logger.LogInformation("Update : {}", mdmFactoryConfig);
        try
        {
            var result = _mdmFactoryConfigDao.Update(mdmFactoryConfig);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmFactoryConfig/{factoryStartHour}")]
    public int Delete(MdmFactoryConfig mdmFactoryConfig)
    {
        _logger.LogInformation("Delete : {}", mdmFactoryConfig);
        try
        {
            var result = _mdmFactoryConfigDao.Delete(mdmFactoryConfig);
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