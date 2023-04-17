using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DTO.sam;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.sam;

[ApiController]
[Route("[controller]")]
public class MenuController : ControllerBase
{

    private readonly ILogger<MenuController> _logger;
    private readonly IMenuDao _menuDao;

    public MenuController(ILogger<MenuController> logger, IMenuDao menuDao)
    {
        _logger = logger;
        _menuDao = menuDao;
    }

    [HttpGet("/api/GetMenu/{systemId}")]
    public IEnumerable<MenuInfo> GetAll(string systemId)
    {
        try
        {
            var result = _menuDao.GetAll(systemId);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<MenuInfo>();
        }
    }

    [HttpPost("/api/GetMenu")]
    public IEnumerable<MenuInfo> GetAll(UserInfo userInfo)
    {
        try
        {
            var result = _menuDao.GetAll(userInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new List<MenuInfo>();
        }
    }

    [HttpPost("/api/GetMenuById")]
    public MenuInfo GetById(MenuInfo menuInfo)
    {
        _logger.LogInformation("menuInfo : {}", menuInfo);

        try
        {
            var result = _menuDao.GetById(menuInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new MenuInfo();
        }

    }

    [HttpPost("/api/SaveMenu")]
    public int Save(List<MenuInfo> menuInfos)
    {
        try
        {
            _logger.LogInformation("menuInfo : {}", menuInfos.Select(x => x.MenuId));
            var result = _menuDao.Save(menuInfos);
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