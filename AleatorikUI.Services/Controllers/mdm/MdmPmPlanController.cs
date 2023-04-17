using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmPmPlanController : ControllerBase
{

    private readonly ILogger<MdmPmPlanController> _logger;
    private readonly IMdmPmPlanDao _mdmPmPlanDao;

    public MdmPmPlanController(ILogger<MdmPmPlanController> logger, IMdmPmPlanDao mdmPmPlanDao)
    {
        _logger = logger;
        _mdmPmPlanDao = mdmPmPlanDao;
    }

    [HttpGet("/api/MdmPmPlan")]
    public IEnumerable<MdmPmPlan> GetAll()
    {
        try
        {
            var result = _mdmPmPlanDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmPmPlan>();
        }
    }

    [HttpPost("/api/MdmPmPlan")]
    public int Insert(MdmPmPlan mdmPmPlan)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmPmPlan);
            _mdmPmPlanDao.Insert(mdmPmPlan);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmPmPlan/{pmID}")]
    public int Update(MdmPmPlan mdmPmPlan)
    {
        _logger.LogInformation("Update : {}", mdmPmPlan);
        try
        {
            var result = _mdmPmPlanDao.Update(mdmPmPlan);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmPmPlan/{pmID}")]
    public int Delete(MdmPmPlan mdmPmPlan)
    {
        _logger.LogInformation("Delete : {}", mdmPmPlan);
        try
        {
            var result = _mdmPmPlanDao.Delete(mdmPmPlan);
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