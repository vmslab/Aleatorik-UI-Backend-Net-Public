using AleatorikUI.Services.DAO.exp;
using AleatorikUI.Services.DTO.exp;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.exp;

[ApiController]
[Route("[controller]")]
public class TrEmployeeController : ControllerBase
{

    private readonly ILogger<TrEmployeeController> _logger;
    private readonly ITrEmployeeDao _trEmployeeDao;

    public TrEmployeeController(ILogger<TrEmployeeController> logger, ITrEmployeeDao trEmployeeDao)
    {
        _logger = logger;
        _trEmployeeDao = trEmployeeDao;
    }

    [HttpGet("/api/TrEmployee")]
    public IEnumerable<TrEmployee> GetAll([FromQuery] TrEmployee trEmployee)
    {
        try
        {
            var result = _trEmployeeDao.GetAll(trEmployee);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<TrEmployee>();
        }

    }

    [HttpPost("/api/TrEmployee")]
    public int Insert(TrEmployee trEmployee)
    {
        try
        {
            _logger.LogInformation("trEmployee : {}", trEmployee);
            _trEmployeeDao.Insert(trEmployee);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/TrEmployee")]
    public int Update(TrEmployee trEmployee)
    {
        _logger.LogInformation("trEmployee : {}", trEmployee);
        try
        {
            var result = _trEmployeeDao.Update(trEmployee);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }

    }

    [HttpDelete("/api/TrEmployee")]
    public int Delete(TrEmployee trEmployee)
    {
        _logger.LogInformation("trEmployee : {}", trEmployee);
        try
        {
            var result = _trEmployeeDao.Delete(trEmployee);
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