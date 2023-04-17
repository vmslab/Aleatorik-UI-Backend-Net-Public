using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DTO.sam;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sam;

[ApiController]
[Route("[controller]")]
public class SamUserController : ControllerBase
{

    private readonly ILogger<SamUserController> _logger;
    private readonly ISamUserDao _samUserDao;

    public SamUserController(ILogger<SamUserController> logger, ISamUserDao samUserDao)
    {
        _logger = logger;
        _samUserDao = samUserDao;
    }

    [HttpGet("/api/GetUser")]
    public IEnumerable<SamUserInfo> GetAll()
    {
        try
        {
            var result = _samUserDao.GetAll();
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<SamUserInfo>();
        }

    }

    [HttpPost("/api/GetUserByEmail")]
    public SamUserInfo GetById(SamUserInfo samUserInfo)
    {
        _logger.LogInformation("samUserInfo : {}", samUserInfo);

        try
        {
            var result = _samUserDao.GetByEmail(samUserInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new SamUserInfo();
        }

    }

    [HttpPost("/api/AddUser")]
    public int Insert(SamUserInfo samUserInfo)
    {
        try
        {
            _logger.LogInformation("samUserInfo : {}", samUserInfo);
            _samUserDao.Insert(samUserInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/ModifyUser")]
    public int Update(SamUserInfo samUserInfo)
    {
        _logger.LogInformation("samUserInfo : {}", samUserInfo);
        try
        {
            var result = _samUserDao.Update(samUserInfo);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }

    }

    [HttpDelete("/api/RemoveUser")]
    public int Delete(SamUserInfo samUserInfo)
    {
        _logger.LogInformation("samUserInfo : {}", samUserInfo);
        try
        {
            var result = _samUserDao.Delete(samUserInfo);
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