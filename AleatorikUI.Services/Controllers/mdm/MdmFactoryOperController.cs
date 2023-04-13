using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmFactoryOperController : ControllerBase
{

    private readonly ILogger<MdmFactoryOperController> _logger;
    private readonly IMdmFactoryOperDao _mdmFactoryOperDao;

    public MdmFactoryOperController(ILogger<MdmFactoryOperController> logger, IMdmFactoryOperDao mdmFactoryOperDao)
    {
        _logger = logger;
        _mdmFactoryOperDao = mdmFactoryOperDao;
    }

    [HttpGet("/api/MdmFactoryOper")]
    public IEnumerable<MdmFactoryOper> GetAll()
    {
        try
        {
            var result = _mdmFactoryOperDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmFactoryOper>();
        }
    }

    [HttpPost("/api/MdmFactoryOper")]
    public int Insert(MdmFactoryOper mdmFactoryOper)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmFactoryOper);
            _mdmFactoryOperDao.Insert(mdmFactoryOper);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmFactoryOper/{factoryStartTime}")]
    public int Update(MdmFactoryOper mdmFactoryOper)
    {
        _logger.LogInformation("Update : {}", mdmFactoryOper);
        try
        {
            var result = _mdmFactoryOperDao.Update(mdmFactoryOper);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmFactoryOper/{factoryStartTime}")]
    public int Delete(MdmFactoryOper mdmFactoryOper)
    {
        _logger.LogInformation("Delete : {}", mdmFactoryOper);
        try
        {
            var result = _mdmFactoryOperDao.Delete(mdmFactoryOper);
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