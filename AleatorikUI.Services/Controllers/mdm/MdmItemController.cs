using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmItemController : ControllerBase
{

    private readonly ILogger<MdmItemController> _logger;
    private readonly IMdmItemDao _mdmItemDao;

    public MdmItemController(ILogger<MdmItemController> logger, IMdmItemDao mdmItemDao)
    {
        _logger = logger;
        _mdmItemDao = mdmItemDao;
    }

    [HttpGet("/api/MdmItem")]
    public IEnumerable<MdmItem> GetAll()
    {
        try
        {
            var result = _mdmItemDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmItem>();
        }
    }

    [HttpPost("/api/MdmItem")]
    public int Insert(MdmItem mdmItem)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmItem);
            _mdmItemDao.Insert(mdmItem);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmItem/{itemID}")]
    public int Update(MdmItem mdmItem)
    {
        _logger.LogInformation("Update : {}", mdmItem);
        try
        {
            var result = _mdmItemDao.Update(mdmItem);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmItem/{itemID}")]
    public int Delete(MdmItem mdmItem)
    {
        _logger.LogInformation("Delete : {}", mdmItem);
        try
        {
            var result = _mdmItemDao.Delete(mdmItem);
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