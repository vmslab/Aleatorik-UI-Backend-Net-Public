using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DTO.sam;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sam;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{

    private readonly ILogger<GroupController> _logger;
    private readonly IGroupDao _groupDao;

    public GroupController(ILogger<GroupController> logger, IGroupDao groupDao)
    {
        _logger = logger;
        _groupDao = groupDao;
    }

    [HttpGet("/api/GetGroup")]
    public IEnumerable<GroupInfo> GetAll()
    {
        try
        {
            var result = _groupDao.GetAll();
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<GroupInfo>();
        }
    }

    [HttpGet("/api/GetGroup/{systemId}")]
    public IEnumerable<GroupInfo> GetBySystem(string systemId)
    {
        try
        {
            var result = _groupDao.GetBySystem(systemId);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<GroupInfo>();
        }
    }

    [HttpPost("/api/AddGroup")]
    public int Insert(GroupInfo groupInfo)
    {
        try
        {
            _logger.LogInformation("GroupInfo : {}", groupInfo);
            _groupDao.Insert(groupInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/ModifyGroup")]
    public int Update(GroupInfo groupInfo)
    {
        _logger.LogInformation("GroupInfo : {}", groupInfo);
        try
        {
            var result = _groupDao.Update(groupInfo);
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
    public int Delete(GroupInfo groupInfo)
    {
        _logger.LogInformation("GroupInfo : {}", groupInfo);
        try
        {
            var result = _groupDao.Delete(groupInfo);
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