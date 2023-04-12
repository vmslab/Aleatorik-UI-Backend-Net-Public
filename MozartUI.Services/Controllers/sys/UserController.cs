using Microsoft.AspNetCore.Mvc;
using MozartUI.Services.DAO.sys;
using MozartUI.Services.DTO.sys;

namespace MozartUI.Services.Controllers.sys;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserDao _userDao;

    public UserController(ILogger<UserController> logger, IUserDao userDao)
    {
        _logger = logger;
        _userDao = userDao;
    }

    [HttpGet("/api/GetUser")]
    public IEnumerable<UserInfo> GetAll()
    {
        try
        {
            var result = _userDao.GetAll();
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<UserInfo>();
        }

    }

    [HttpPost("/api/GetUserByEmail")]
    public UserInfo GetById(UserInfo userInfo)
    {
        _logger.LogInformation("userInfo : {}", userInfo);

        try
        {
            var result = _userDao.GetByEmail(userInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new UserInfo();
        }

    }

    [HttpPost("/api/AddUser")]
    public int Insert(UserInfo userInfo)
    {
        try
        {
            _logger.LogInformation("userInfo : {}", userInfo);
            _userDao.Insert(userInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/ModifyUser")]
    public int Update(UserInfo userInfo)
    {
        _logger.LogInformation("userInfo : {}", userInfo);
        try
        {
            var result = _userDao.Update(userInfo);
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
    public int Delete(UserInfo userInfo)
    {
        _logger.LogInformation("userInfo : {}", userInfo);
        try
        {
            var result = _userDao.Delete(userInfo);
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