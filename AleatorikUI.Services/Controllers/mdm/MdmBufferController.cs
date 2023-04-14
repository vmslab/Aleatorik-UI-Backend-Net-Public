using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
public class MdmBufferController : ControllerBase
{

    private readonly ILogger<MdmBufferController> _logger;
    private readonly IMdmBufferDao _mdmBufferDao;

    public MdmBufferController(ILogger<MdmBufferController> logger, IMdmBufferDao mdmBufferDao)
    {
        _logger = logger;
        _mdmBufferDao = mdmBufferDao;
    }

    [HttpGet("/api/MdmBuffer")]
    public IEnumerable<MdmBuffer> GetAll()
    {
        try
        {
            var result = _mdmBufferDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBuffer>();
        }
    }

    [HttpPost("/api/MdmBuffer")]
    public int Insert(MdmBuffer mdmBuffer)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBuffer);
            _mdmBufferDao.Insert(mdmBuffer);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/MdmBuffer/{stageID}/{bufferID}")]
    public int Update(MdmBuffer mdmBuffer)
    {
        _logger.LogInformation("Update : {}", mdmBuffer);
        try
        {
            var result = _mdmBufferDao.Update(mdmBuffer);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpDelete("/api/MdmBuffer/{stageID}/{bufferID}")]
    public int Delete(MdmBuffer mdmBuffer)
    {
        _logger.LogInformation("Delete : {}", mdmBuffer);
        try
        {
            var result = _mdmBufferDao.Delete(mdmBuffer);
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