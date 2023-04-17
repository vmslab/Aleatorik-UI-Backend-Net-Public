using AleatorikUI.Services.DAO.iod;
using AleatorikUI.Services.DTO.iod;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.iod;

[ApiController]
[Route("[controller]")]
public class IodReportController : ControllerBase
{

    private readonly ILogger<IodReportController> _logger;
    private readonly IRarBomMapViewDao _iodReportDao;

    public IodReportController(ILogger<IodReportController> logger, IRarBomMapViewDao iodReportDao)
    {
        _logger = logger;
        _iodReportDao = iodReportDao;
    }

    [HttpGet("/api/IodReport")]
    public IEnumerable<RarBomMapView> GetAll()
    {
        try
        {
            var result = _iodReportDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<RarBomMapView>();
        }
    }

    [HttpPost("/api/IodReport")]
    public int Insert(RarBomMapView iodReport)
    {
        try
        {
            _logger.LogInformation("Insert : {}", iodReport);
            _iodReportDao.Insert(iodReport);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/IodReport/{resourceID}")]
    public int Update(RarBomMapView iodReport)
    {
        _logger.LogInformation("Update : {}", iodReport);
        try
        {
            var result = _iodReportDao.Update(iodReport);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/IodReport/{resourceID}")]
    public int Delete(RarBomMapView iodReport)
    {
        _logger.LogInformation("Delete : {}", iodReport);
        try
        {
            var result = _iodReportDao.Delete(iodReport);
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