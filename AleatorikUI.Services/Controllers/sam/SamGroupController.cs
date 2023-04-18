using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DTO.sam;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sam;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class SamGroupController : ControllerBase
{

    private readonly ILogger<SamGroupController> _logger;
    private readonly ISamGroupDao _samGroupDao;

    public SamGroupController(ILogger<SamGroupController> logger, ISamGroupDao samGroupDao)
    {
        _logger = logger;
        _samGroupDao = samGroupDao;
    }

    [HttpGet("/api/GetGroup")]
    public IEnumerable<SamGroupInfo> GetAll()
    {
        try
        {
            var result = _samGroupDao.GetAll();
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<SamGroupInfo>();
        }
    }

    [HttpGet("/api/GetGroup/{systemId}")]
    public IEnumerable<SamGroupInfo> GetBySystem(string systemId)
    {
        try
        {
            var result = _samGroupDao.GetBySystem(systemId);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<SamGroupInfo>();
        }
    }

    [HttpPost("/api/AddGroup")]
    public int Insert(SamGroupInfo samGroupInfo)
    {
        try
        {
            _logger.LogInformation("GroupInfo : {}", samGroupInfo);
            _samGroupDao.Insert(samGroupInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/ModifyGroup")]
    public int Update(SamGroupInfo samGroupInfo)
    {
        _logger.LogInformation("GroupInfo : {}", samGroupInfo);
        try
        {
            var result = _samGroupDao.Update(samGroupInfo);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }

    }

    [HttpDelete("/api/RemoveGroup")]
    public int Delete(SamGroupInfo samGroupInfo)
    {
        _logger.LogInformation("GroupInfo : {}", samGroupInfo);
        try
        {
            var result = _samGroupDao.Delete(samGroupInfo);
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