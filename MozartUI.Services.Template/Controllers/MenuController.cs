using Microsoft.AspNetCore.Mvc;
using MozartUI.Services.Template.DAO;
using MozartUI.Services.Template.DTO;

namespace MozartUI.Services.Template.Controllers
{
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
				Serilog.Log.Logger.Information(result.ToString());
				return result;
			}
			catch (Exception e)
			{
				_logger.LogError("error : {}", e.Message);
				Serilog.Log.Logger.Error(e.Message);
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
				Serilog.Log.Logger.Information(result.ToString());
				return result;
			}
			catch (Exception e)
			{
				_logger.LogError("error : {}", e.Message);
				Serilog.Log.Logger.Error(e.Message);
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

		//[HttpPost("/api/AddMenu")]
		//public int Insert(MenuInfo menuInfo)
		//{
		//    try
		//    {
		//        _logger.LogInformation("menuInfo : {}", menuInfo);
		//        _menuDao.Insert(menuInfo);
		//        return 1;
		//    }
		//    catch (Exception e)
		//    {
		//        _logger.LogError("error : {}", e.Message);
		//        return 0;
		//    }
		//}

		//[HttpPut("/api/ModifyMenu")]
		//public int Update(MenuInfo menuInfo)
		//{
		//    _logger.LogInformation("menuInfo : {}", menuInfo);
		//    try
		//    {
		//        var result = _menuDao.Update(menuInfo);
		//        _logger.LogInformation("result : {}", result);

		//        return result;
		//    }
		//    catch (Exception e)
		//    {
		//        _logger.LogError("error : {}", e.Message);
		//        return 0;
		//    }

		//}

		//[HttpDelete("/api/RemoveMenu")]
		//public int Delete(MenuInfo menuInfo)
		//{
		//    _logger.LogInformation("menuInfo : {}", menuInfo);
		//    try
		//    {
		//        var result = _menuDao.Delete(menuInfo);
		//        _logger.LogInformation("result : {}", result);

		//        return result;
		//    }
		//    catch (Exception e)
		//    {
		//        _logger.LogError("error : {}", e.Message);
		//        return 0;
		//    }

		//}
	}
}