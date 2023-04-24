using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmFactoryConfigController : ControllerBase
{

    private readonly ILogger<MdmFactoryConfigController> _logger;
    private readonly IMdmFactoryConfigDao _mdmFactoryConfigDao;

    public MdmFactoryConfigController(ILogger<MdmFactoryConfigController> logger, IMdmFactoryConfigDao mdmFactoryConfigDao)
    {
        _logger = logger;
        _mdmFactoryConfigDao = mdmFactoryConfigDao;
    }
    /// <summary>
    /// 공장 운영 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmFactoryConfig"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmFactoryConfig")]
    public IEnumerable<MdmFactoryConfig> GetAll(String projectID, [FromQuery] MdmFactoryConfig mdmFactoryConfig)
    {
        try
        {
            mdmFactoryConfig.projectID = projectID;
            var result = _mdmFactoryConfigDao.GetAll(mdmFactoryConfig);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmFactoryConfig>();
        }
    }
    /// <summary>
    /// 공장 운영 정보를 저장 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmFactoryConfig"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmFactoryConfig")]
    public int Insert(String projectID, MdmFactoryConfig mdmFactoryConfig)
    {
        try
        {
            mdmFactoryConfig.projectID = projectID;
            _logger.LogInformation("Insert : {}", mdmFactoryConfig);
            _mdmFactoryConfigDao.Insert(mdmFactoryConfig);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 공장 운영 정보를 수정 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmFactoryConfig"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmFactoryConfig/{factoryStartHour}")]
    public int Update(String projectID, MdmFactoryConfig mdmFactoryConfig)
    {
        _logger.LogInformation("Update : {}", mdmFactoryConfig);
        try
        {
            mdmFactoryConfig.projectID = projectID;
            var result = _mdmFactoryConfigDao.Update(mdmFactoryConfig);
            _logger.LogInformation("result : {}", result);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 공장 운영 정보를 삭제 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <param name="mdmFactoryConfig"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmFactoryConfig/{factoryStartHour}")]
    public int Delete(String projectID, MdmFactoryConfig mdmFactoryConfig)
    {
        _logger.LogInformation("Delete : {}", mdmFactoryConfig);
        try
        {
            mdmFactoryConfig.projectID = projectID;
            var result = _mdmFactoryConfigDao.Delete(mdmFactoryConfig);
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