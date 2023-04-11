using Microsoft.AspNetCore.Mvc;
using MozartUI.Services.DAO;
using MozartUI.Services.DTO;

namespace MozartUI.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{

    private readonly ILogger<TodoController> _logger;
    private readonly ITodoDao _todoDao;

    public TodoController(ILogger<TodoController> logger, ITodoDao todoDao)
    {
        _logger = logger;
        _todoDao = todoDao;
    }

    [HttpGet("/api/GetTodo")]
    public IEnumerable<TodoInfo> GetAll()
    {
        try {
            var result = _todoDao.GetAll();
            _logger.LogInformation("result : {}", result);
            return result;
        } 
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<TodoInfo>();
		}

    }

    [HttpPost("/api/GetTodo")]
    public TodoInfo GetById(TodoInfo todoInfo)
    {
        _logger.LogInformation("todoInfo : {}", todoInfo);

        try
        {
            var result = _todoDao.GetById(todoInfo);
            _logger.LogInformation("result : {}", result);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return new TodoInfo();
        }

    }

    [HttpPost("/api/AddTodo")]
    public int Insert(TodoInfo todoInfo)
    {
        try
        {
            _logger.LogInformation("todoInfo : {}", todoInfo);
            _todoDao.Insert(todoInfo);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }

    [HttpPut("/api/ModifyTodo")]
    public int Update(TodoInfo todoInfo)
    {
        _logger.LogInformation("todoInfo : {}", todoInfo);
        try
        {
            var result = _todoDao.Update(todoInfo);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }

    }

    [HttpDelete("/api/RemoveTodo")]
    public int Delete(TodoInfo todoInfo)
    {
        _logger.LogInformation("todoInfo : {}", todoInfo);
        try
        {
            var result = _todoDao.Delete(todoInfo);
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