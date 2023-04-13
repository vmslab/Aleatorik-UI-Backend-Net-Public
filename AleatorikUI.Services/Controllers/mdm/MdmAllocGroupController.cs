using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmAllocGroupController : ControllerBase
{

    private readonly ILogger<MdmAllocGroupController> _logger;
    private readonly IMdmAllocGroupDao _mdmAllocGroupDao;

    public MdmAllocGroupController(ILogger<MdmAllocGroupController> logger, IMdmAllocGroupDao mdmAllocGroupDao)
    {
        _logger = logger;
        _mdmAllocGroupDao = mdmAllocGroupDao;
    }

    [HttpGet("/api/MdmAllocGroup")]
    public IEnumerable<MdmAllocGroup> GetAll()
    {
        try
        {
            var result = _mdmAllocGroupDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmAllocGroup>();
        }
    }

    [HttpPost("/api/MdmAllocGroup")]
    public int Insert(MdmAllocGroup mdmAllocGroup)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmAllocGroup);
            _mdmAllocGroupDao.Insert(mdmAllocGroup);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmAllocGroup/{allocGroupID}")]
    public int Update(MdmAllocGroup mdmAllocGroup)
    {
        _logger.LogInformation("Update : {}", mdmAllocGroup);
        try
        {
            var result = _mdmAllocGroupDao.Update(mdmAllocGroup);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmAllocGroup/{allocGroupID}")]
    public int Delete(MdmAllocGroup mdmAllocGroup)
    {
        _logger.LogInformation("Delete : {}", mdmAllocGroup);
        try
        {
            var result = _mdmAllocGroupDao.Delete(mdmAllocGroup);
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