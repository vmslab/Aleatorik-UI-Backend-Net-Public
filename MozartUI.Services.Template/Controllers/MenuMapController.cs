using Microsoft.AspNetCore.Mvc;
using MozartUI.Services.Template.DAO;
using MozartUI.Services.Template.DTO;

namespace MozartUI.Services.Template.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuMapController : ControllerBase
{

    private readonly ILogger<MenuMapController> _logger;
    private readonly IMenuMapDao _menuMapDao;

    public MenuMapController(ILogger<MenuMapController> logger, IMenuMapDao menuMapDao)
    {
        _logger = logger;
        _menuMapDao = menuMapDao;
    }

    [HttpPost("/api/GetMenuMap")]
    public IEnumerable<MenuMapInfo> GetAll(MenuMapInfo menuMapInfo)
    {
        try
        {
            var result = _menuMapDao.GetAll(menuMapInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MenuMapInfo>();
        }
    }

    [HttpGet("/api/GetMenuMap/{menuMapId}")]
    public MenuMapInfo GetById(string menuMapId)
    {
        _logger.LogInformation("menuMapId : {}", menuMapId);

        try
        {
            var result = _menuMapDao.GetById(menuMapId);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new MenuMapInfo();
        }

    }

    [HttpPost("/api/SaveMenuMap")]
	public int Save(List<MenuMapInfo> menuMapInfos)
	{
		try
		{
			_logger.LogInformation("menuMapInfo : {}", menuMapInfos.Select(x => x.MenuMapId));
			var result = _menuMapDao.Save(menuMapInfos);
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