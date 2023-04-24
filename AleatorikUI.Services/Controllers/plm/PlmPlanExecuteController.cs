using AleatorikUI.Services.DAO.plm;
using AleatorikUI.Services.DTO.plm;
using AleatorikUI.Services.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.plm;

[Authorize]
[ApiVersion("1.0")]
[Route("[controller]")]
[ApiController]
public class PlmPlanExecuteController : ControllerBase
{
    private readonly ILogger<PlmPlanExecuteController> _logger;
    private readonly IPlmPlanExecuteDao _PlmPlanExecuteDao;

    public PlmPlanExecuteController(ILogger<PlmPlanExecuteController> logger, IPlmPlanExecuteDao aorBomMapDao)
    {
        _logger = logger;
        _PlmPlanExecuteDao = aorBomMapDao;
    }

    [AllowAnonymous]
    [HttpPost("/api/getPlan")]
    public IEnumerable<PlmPlanExecuteInfo> GetPlan(PlmPlanExecuteInfo param)
    {
        try
        {
            var result = _PlmPlanExecuteDao.GetPlan(param);
            _logger.LogInformation("PlmPlanExecuteInfo : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<PlmPlanExecuteInfo>();
        }
    }

    [AllowAnonymous]
    [HttpPost("/api/addPlan")]
    public bool AddPlan(PlmPlanExecuteInfo param)
    {
        try
        {
            _logger.LogInformation("param : {}", param);
            _PlmPlanExecuteDao.AddPlan(param);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return false;
        }
    }

    [AllowAnonymous]
    [HttpPost("/api/updatePlan")]
    public bool UpdatePlan(PlmPlanExecuteInfo param)
    {
        try
        {
            _logger.LogInformation("param : {}", param);
            var result = _PlmPlanExecuteDao.UpdatePlan(param);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return false;
        }
    }

    [AllowAnonymous]
    [HttpPost("/api/inboundPlan")]
    public object InboundPlan(PlmPlanExecuteInfo param)
    {
        try
        {
            _logger.LogInformation("param : {}", param);
            var result = _PlmPlanExecuteDao.InboundPlan(param);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return false;
        }
    }

    [AllowAnonymous]
    [HttpPost("/api/removePlan")]
    public object RemovePlan(PlmPlanExecuteInfo param)
    {
        try
        {
            _logger.LogInformation("param : {}", param);
            var result = _PlmPlanExecuteDao.RemovePlan(param);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return false;
        }
    }

    [AllowAnonymous]
    [HttpPost("/api/runPlan")]
    public bool RunPlan(PlmPlanExecuteInfo param)
    {
        try
        {
            _logger.LogInformation("param : {}", param);
            TriggerJobHelper.RunTaskService(param, _logger);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return false;
        }
    }
}