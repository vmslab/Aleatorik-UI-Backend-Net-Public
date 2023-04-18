using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmStageMasterController : ControllerBase
{

    private readonly ILogger<MdmStageMasterController> _logger;
    private readonly IMdmStageMasterDao _mdmStageMasterDao;

    public MdmStageMasterController(ILogger<MdmStageMasterController> logger, IMdmStageMasterDao mdmStageMasterDao)
    {
        _logger = logger;
        _mdmStageMasterDao = mdmStageMasterDao;
    }

    [HttpGet("/api/MdmStageMaster")]
    public IEnumerable<MdmStageMaster> GetAll()
    {
        try
        {
            var result = _mdmStageMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmStageMaster>();
        }
    }

    [HttpPost("/api/MdmStageMaster")]
    public int Insert(MdmStageMaster mdmStageMaster)
    {
        try
        {
            //mdmStageMaster.createTime = DateTime.Now;
            //mdmStageMaster.updateTime = DateTime.Now;

            _logger.LogInformation("Insert : {}", mdmStageMaster);
            _mdmStageMasterDao.Insert(mdmStageMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmStageMaster/{stageID}")]
    public int Update(MdmStageMaster mdmStageMaster)
    {
        _logger.LogInformation("Update : {}", mdmStageMaster);
        try
        {
            var result = _mdmStageMasterDao.Update(mdmStageMaster);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmStageMaster/{stageID}")]
    public int Delete(MdmStageMaster mdmStageMaster)
    {
        _logger.LogInformation("Delete : {}", mdmStageMaster);
        try
        {
            var result = _mdmStageMasterDao.Delete(mdmStageMaster);
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