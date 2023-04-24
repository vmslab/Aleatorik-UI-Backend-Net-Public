using AleatorikUI.Services.DAO.exp;
using AleatorikUI.Services.DTO.exp;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.exp;

[ApiVersion("1.0")]
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
            Serilog.Log.Logger.Information(result.ToString());
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
    public int Insert(TrEmployee TrEmployee)
    {
        try
        {
            _logger.LogInformation("Insert : {}", TrEmployee);
            _trEmployeeDao.Insert(TrEmployee);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/TrEmployee/{empNo}")]
    public int Update(TrEmployee TrEmployee)
    {
        _logger.LogInformation("Update : {}", TrEmployee);
        try
        {
            var result = _trEmployeeDao.Update(TrEmployee);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/TrEmployee/{empNo}")]
    public int Delete(TrEmployee TrEmployee)
    {
        _logger.LogInformation("Delete : {}", TrEmployee);
        try
        {
            var result = _trEmployeeDao.Delete(TrEmployee);
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