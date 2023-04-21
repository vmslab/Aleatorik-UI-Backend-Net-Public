using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmCustMasterController : ControllerBase
{

    private readonly ILogger<MdmCustMasterController> _logger;
    private readonly IMdmCustMasterDao _mdmCustMasterDao;

    public MdmCustMasterController(ILogger<MdmCustMasterController> logger, IMdmCustMasterDao mdmCustMasterDao)
    {
        _logger = logger;
        _mdmCustMasterDao = mdmCustMasterDao;
    }
    /// <summary>
    /// 거래처 정보를 조회 합니다.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/MdmCustMaster")]
    public IEnumerable<MdmCustMaster> GetAll()
    {
        try
        {
            var result = _mdmCustMasterDao.GetAll();
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCustMaster>();
        }
    }
    /// <summary>
    /// 거래처 정보를 추가 합니다.
    /// </summary>
    /// <param name="mdmCustMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmCustMaster")]
    public int Insert(MdmCustMaster mdmCustMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmCustMaster);
            _mdmCustMasterDao.Insert(mdmCustMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 거래처 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmCustMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmCustMaster/{custID}")]
    public int Update(MdmCustMaster mdmCustMaster)
    {
        _logger.LogInformation("Update : {}", mdmCustMaster);
        try
        {
            var result = _mdmCustMasterDao.Update(mdmCustMaster);
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
    /// 거래처 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmCustMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmCustMaster/{custID}")]
    public int Delete(MdmCustMaster mdmCustMaster)
    {
        _logger.LogInformation("Delete : {}", mdmCustMaster);
        try
        {
            var result = _mdmCustMasterDao.Delete(mdmCustMaster);
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
    /// 거래처정보 - PROP 를 조회 합니다.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/MdmCustMaster/{custID}/PROP")]
    public IEnumerable<MdmCustProp> GetAllProp(String custID)
    {
        try
        {
            var result = _mdmCustMasterDao.GetAllProp(custID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmCustProp>();
        }
    }

    /// <summary>
    /// 거래처정보 - PROP 를 추가 합니다.
    /// </summary>
    /// <param name="mdmCustProp"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmCustMaster/{custID}/PROP")]
    public int InsertProp(MdmCustProp mdmCustProp)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmCustProp);
            _mdmCustMasterDao.InsertProp(mdmCustProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// 거래처정보 - PROP 를 수정 합니다.
    /// </summary>
    /// <param name="mdmCustProp"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmCustProp/{custID}/PROP/{propID}")]
    public int UpdateProp(MdmCustProp mdmCustProp)
    {
        _logger.LogInformation("Update : {}", mdmCustProp);
        try
        {
            var result = _mdmCustMasterDao.UpdateProp(mdmCustProp);
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
    /// 거래처정보 - PROP 를 삭제 합니다.
    /// </summary>
    /// <param name="mdmCustProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmCustProp/{custID}/PROP/{propID}")]
    public int DeleteProp(MdmCustProp mdmCustProp)
    {
        _logger.LogInformation("Delete : {}", mdmCustProp);
        try
        {
            var result = _mdmCustMasterDao.DeleteProp(mdmCustProp);
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