using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmBufferMasterController : ControllerBase
{

    private readonly ILogger<MdmBufferMasterController> _logger;
    private readonly IMdmBufferMasterDao _mdmBufferMasterDao;

    public MdmBufferMasterController(ILogger<MdmBufferMasterController> logger, IMdmBufferMasterDao mdmBufferMasterDao)
    {
        _logger = logger;
        _mdmBufferMasterDao = mdmBufferMasterDao;
    }
    /// <summary>
    /// BUFFER 정보를 조회 합니다.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/MdmBufferMaster")]
    public IEnumerable<MdmBufferMaster> GetAll()
    {
        try
        {
            var result = _mdmBufferMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBufferMaster>();
        }
    }
    /// <summary>
    /// BUFFER 정보를 추가 합니다.
    /// </summary>
    /// <param name="mdmBufferMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBufferMaster")]
    public int Insert(MdmBufferMaster mdmBufferMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBufferMaster);
            _mdmBufferMasterDao.Insert(mdmBufferMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BUFFER 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmBufferMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBufferMaster/{bufferID}")]
    public int Update(MdmBufferMaster mdmBufferMaster)
    {
        _logger.LogInformation("Update : {}", mdmBufferMaster);
        try
        {
            var result = _mdmBufferMasterDao.Update(mdmBufferMaster);
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
    /// BUFFER 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBufferMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBufferMaster/{bufferID}")]
    public int Delete(MdmBufferMaster mdmBufferMaster)
    {
        _logger.LogInformation("Delete : {}", mdmBufferMaster);
        try
        {
            var result = _mdmBufferMasterDao.Delete(mdmBufferMaster);
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
    /// BUFFER 정보 - PROP 를 조회 합니다.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/MdmBufferProp/{bufferID}/PROP")]
    public IEnumerable<MdmBufferProp> GetAllProp(String bufferID)
    {
        try
        {
            var result = _mdmBufferMasterDao.GetAllProp(bufferID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBufferProp>();
        }
    }
    /// <summary>
    /// BUFFER 정보 - PROP 를 추가 합니다.
    /// </summary>
    /// <param name="mdmBufferProp"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBufferProp/{bufferID}/PROP")]
    public int InsertProp(MdmBufferProp mdmBufferProp)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBufferProp);
            _mdmBufferMasterDao.InsertProp(mdmBufferProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BUFFER 정보 - PROP 를 수정 합니다.
    /// </summary>
    /// <param name="mdmBufferProp"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBufferProp/{bufferID}/PROP/{propID}")]
    public int UpdateProp(MdmBufferProp mdmBufferProp)
    {
        _logger.LogInformation("Update : {}", mdmBufferProp);
        try
        {
            var result = _mdmBufferMasterDao.UpdateProp(mdmBufferProp);
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
    /// BUFFER 정보 - PROP 를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBufferProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBufferProp/{bufferID}/PROP/{propID}")]
    public int DeleteProp(MdmBufferProp mdmBufferProp)
    {
        _logger.LogInformation("Delete : {}", mdmBufferProp);
        try
        {
            var result = _mdmBufferMasterDao.DeleteProp(mdmBufferProp);
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