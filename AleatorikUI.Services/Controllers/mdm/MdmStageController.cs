using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmStageController : ControllerBase
{

    private readonly ILogger<MdmStageController> _logger;
    private readonly IMdmStageDao _mdmStageDao;

    public MdmStageController(ILogger<MdmStageController> logger, IMdmStageDao mdmStageDao)
    {
        _logger = logger;
        _mdmStageDao = mdmStageDao;
    }

    [HttpGet("/api/MdmStage")]
    public IEnumerable<MdmStage> GetAll()
    {
        try
        {
            var result = _mdmStageDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmStage>();
        }
    }

    [HttpGet("/api/MdmStage/{stageID}")]
    public MdmStage GetById(string stageID)
    {
        _logger.LogInformation("GetById  : {}", stageID);

        try
        {
            var result = _mdmStageDao.GetById(stageID);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new MdmStage();
        }
    }

    [HttpPost("/api/MdmStage")]
    public int Insert(MdmStage mdmStage)
    {
        try
        {
            mdmStage.createTime = DateTime.Now;
            mdmStage.updateTime = DateTime.Now;

            _logger.LogInformation("Insert : {}", mdmStage);
            _mdmStageDao.Insert(mdmStage);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmStage/{stageID}")]
    public int Update(MdmStage mdmStage, string stageID)
    {
        _logger.LogInformation("Update : {}", mdmStage);
        try
        {
            mdmStage.stageID = stageID;
            mdmStage.updateTime = DateTime.Now;

            var result = _mdmStageDao.Update(mdmStage);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmStage/{stageID}")]
    public int Delete(MdmStage mdmStage, string stageID)
    {
        _logger.LogInformation("Delete : {}", mdmStage);
        try
        {
            mdmStage.stageID = stageID;

            var result = _mdmStageDao.Delete(mdmStage);
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