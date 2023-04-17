using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmItemMasterController : ControllerBase
{

    private readonly ILogger<MdmItemMasterController> _logger;
    private readonly IMdmItemMasterDao _mdmItemMasterDao;

    public MdmItemMasterController(ILogger<MdmItemMasterController> logger, IMdmItemMasterDao mdmItemMasterDao)
    {
        _logger = logger;
        _mdmItemMasterDao = mdmItemMasterDao;
    }

    [HttpGet("/api/MdmItemMaster")]
    public IEnumerable<MdmItemMaster> GetAll()
    {
        try
        {
            var result = _mdmItemMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmItemMaster>();
        }
    }

    [HttpPost("/api/MdmItemMaster")]
    public int Insert(MdmItemMaster mdmItemMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmItemMaster);
            _mdmItemMasterDao.Insert(mdmItemMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmItemMaster/{itemID}")]
    public int Update(MdmItemMaster mdmItemMaster)
    {
        _logger.LogInformation("Update : {}", mdmItemMaster);
        try
        {
            var result = _mdmItemMasterDao.Update(mdmItemMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmItemMaster/{itemID}")]
    public int Delete(MdmItemMaster mdmItemMaster)
    {
        _logger.LogInformation("Delete : {}", mdmItemMaster);
        try
        {
            var result = _mdmItemMasterDao.Delete(mdmItemMaster);
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