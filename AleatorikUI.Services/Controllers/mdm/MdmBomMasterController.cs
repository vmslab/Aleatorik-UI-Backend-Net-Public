using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class MdmBomMasterController : ControllerBase
{

    private readonly ILogger<MdmBomMasterController> _logger;
    private readonly IMdmBomMasterDao _mdmBomMasterDao;

    public MdmBomMasterController(ILogger<MdmBomMasterController> logger, IMdmBomMasterDao mdmBomMasterDao)
    {
        _logger = logger;
        _mdmBomMasterDao = mdmBomMasterDao;
    }
    /// <summary>
    /// BOM MASTER 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <returns></returns>
    [HttpGet("/api/MdmBomMaster/{projectID}")]
    public IEnumerable<MdmBomMaster> GetAll(String projectID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAll(projectID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomMaster>();
        }
    }
    /// <summary>
    /// BOM MASTER 정보를 저장 합니다.
    /// </summary>
    /// <param name="mdmBomMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBomMaster/{projectID}")]
    public int Insert(MdmBomMaster mdmBomMaster)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBomMaster);
            _mdmBomMasterDao.Insert(mdmBomMaster);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BOM MASTER 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmBomMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBomMaster/{projectID}/{bomID}")]
    public int Update(MdmBomMaster mdmBomMaster)
    {
        _logger.LogInformation("Update : {}", mdmBomMaster);
        try
        {
            var result = _mdmBomMasterDao.Update(mdmBomMaster);
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
    /// BOM MASTER 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBomMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBomMaster/{projectID}/{bomID}")]
    public int Delete(MdmBomMaster mdmBomMaster)
    {
        _logger.LogInformation("Delete : {}", mdmBomMaster);
        try
        {
            var result = _mdmBomMasterDao.Delete(mdmBomMaster);
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
    /// BOM DETAIL 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <returns></returns>
    [HttpGet("/api/MdmBomMaster/{projectID}/{bomID}/Detail")]
    public IEnumerable<MdmBomDetail> GetAllDetail(String projectID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllDetail(projectID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomDetail>();
        }
    }
    /// <summary>
    /// BOM DETAIL 정보를 저장 합니다.
    /// </summary>
    /// <param name="mdmBomDetail"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBomMaster/{projectID}/{bomID}/Detail")]
    public int InsertDetail(MdmBomDetail mdmBomDetail)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBomDetail);
            _mdmBomMasterDao.InsertDetail(mdmBomDetail);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BOM DETAIL 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmBomDetail"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBomMaster/{projectID}/{bomID}/Detail/{fromItemID}")]
    public int UpdateDetail(MdmBomDetail mdmBomDetail)
    {
        _logger.LogInformation("Update : {}", mdmBomDetail);
        try
        {
            var result = _mdmBomMasterDao.UpdateDetail(mdmBomDetail);
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
    /// BOM DETAIL 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBomDetail"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBomMaster/{projectID}/{bomID}/Detail/{fromItemID}")]
    public int DeleteDetail(MdmBomDetail mdmBomDetail)
    {
        _logger.LogInformation("Delete : {}", mdmBomDetail);
        try
        {
            var result = _mdmBomMasterDao.DeleteDetail(mdmBomDetail);
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
    /// BOM DETAIL ALT 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <returns></returns>
    [HttpGet("/api/MdmBomMaster/{projectID}/{bomID}/DetailAlt")]
    public IEnumerable<MdmBomDetailAlt> GetAllDetailAlt(String projectID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllDetailAlt(projectID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomDetailAlt>();
        }
    }
    /// <summary>
    /// BOM DETAIL ALT 정보를 저장 합니다.
    /// </summary>
    /// <param name="mdmBomDetailAlt"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBomMaster/{projectID}/{bomID}/DetailAlt")]
    public int InsertDetailAlt(MdmBomDetailAlt mdmBomDetailAlt)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBomDetailAlt);
            _mdmBomMasterDao.InsertDetailAlt(mdmBomDetailAlt);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BOM DETAIL ALT 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmBomDetailAlt"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBomMaster/{projectID}/{bomID}/DetailAlt/{itemID}")]
    public int UpdateDetailAlt(MdmBomDetailAlt mdmBomDetailAlt)
    {
        _logger.LogInformation("Update : {}", mdmBomDetailAlt);
        try
        {
            var result = _mdmBomMasterDao.UpdateDetailAlt(mdmBomDetailAlt);
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
    /// BOM DETAIL ALT 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBomDetailAlt"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBomMaster/{projectID}/{bomID}/DetailAlt/{itemID}")]
    public int DeleteDetailAlt(MdmBomDetailAlt mdmBomDetailAlt)
    {
        _logger.LogInformation("Delete : {}", mdmBomDetailAlt);
        try
        {
            var result = _mdmBomMasterDao.DeleteDetailAlt(mdmBomDetailAlt);
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
    /// BOM Prop 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <returns></returns>
    [HttpGet("/api/MdmBomMaster/{projectID}/{bomID}/Prop")]
    public IEnumerable<MdmBomProp> GetAllProp(String projectID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllProp(projectID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomProp>();
        }
    }
    /// <summary>
    /// BOM Prop 정보를 저장 합니다.
    /// </summary>
    /// <param name="mdmBomProp"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBomMaster/{projectID}/{bomID}/Prop")]
    public int InsertProp(MdmBomProp mdmBomProp)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBomProp);
            _mdmBomMasterDao.InsertProp(mdmBomProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BOM Prop 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmBomProp"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBomMaster/{projectID}/{bomID}/Prop/{propID}")]
    public int UpdateProp(MdmBomProp mdmBomProp)
    {
        _logger.LogInformation("Update : {}", mdmBomProp);
        try
        {
            var result = _mdmBomMasterDao.UpdateProp(mdmBomProp);
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
    /// BOM Prop 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBomProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBomMaster/{projectID}/{bomID}/Prop/{propID}")]
    public int DeleteProp(MdmBomProp mdmBomProp)
    {
        _logger.LogInformation("Delete : {}", mdmBomProp);
        try
        {
            var result = _mdmBomMasterDao.DeleteProp(mdmBomProp);
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
    /// BOM Routing 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <returns></returns>
    [HttpGet("/api/MdmBomMaster/{projectID}/{bomID}/Routing")]
    public IEnumerable<MdmBomRouting> GetAllRouting(String projectID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllRouting(projectID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomRouting>();
        }
    }
    /// <summary>
    /// BOM Routing 정보를 저장 합니다.
    /// </summary>
    /// <param name="mdmBomRouting"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBomMaster/{projectID}/{bomID}/Routing")]
    public int InsertRouting(MdmBomRouting mdmBomRouting)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBomRouting);
            _mdmBomMasterDao.InsertRouting(mdmBomRouting);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BOM Routing 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmBomRouting"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBomMaster/{projectID}/{bomID}/Routing/{routingID}")]
    public int UpdateRouting(MdmBomRouting mdmBomRouting)
    {
        _logger.LogInformation("Update : {}", mdmBomRouting);
        try
        {
            var result = _mdmBomMasterDao.UpdateRouting(mdmBomRouting);
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
    /// BOM Routing 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBomRouting"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBomMaster/{projectID}/{bomID}/Routing/{routingID}")]
    public int DeleteRouting(MdmBomRouting mdmBomRouting)
    {
        _logger.LogInformation("Delete : {}", mdmBomRouting);
        try
        {
            var result = _mdmBomMasterDao.DeleteRouting(mdmBomRouting);
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
    /// BOM Routing Prop 정보를 조회 합니다.
    /// </summary>
    /// <param name="projectID"></param>
    /// <returns></returns>
    [HttpGet("/api/MdmBomMaster/{projectID}/{bomID}/Routing/{routingID}/RoutingProp")]
    public IEnumerable<MdmBomRoutingProp> GetAllRoutingProp(String projectID)
    {
        try
        {
            var result = _mdmBomMasterDao.GetAllRoutingProp(projectID);
            _logger.LogInformation("result : {}", result);
            Serilog.Log.Logger.Information(result.ToString());
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<MdmBomRoutingProp>();
        }
    }
    /// <summary>
    /// BOM Routing Prop 정보를 저장 합니다.
    /// </summary>
    /// <param name="mdmBomRoutingProp"></param>
    /// <returns></returns>
    [HttpPost("/api/MdmBomMaster/{projectID}/{bomID}/Routing/{routingID}/RoutingProp")]
    public int InsertRoutingProp(MdmBomRoutingProp mdmBomRoutingProp)
    {
        try
        {
            _logger.LogInformation("Insert : {}", mdmBomRoutingProp);
            _mdmBomMasterDao.InsertRoutingProp(mdmBomRoutingProp);
            return 1;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            return 0;
        }
    }
    /// <summary>
    /// BOM Routing Prop 정보를 수정 합니다.
    /// </summary>
    /// <param name="mdmBomRoutingProp"></param>
    /// <returns></returns>
    [HttpPut("/api/MdmBomMaster/{projectID}/{bomID}/Routing/{routingID}/RoutingProp/{propID}")]
    public int UpdateRoutingProp(MdmBomRoutingProp mdmBomRoutingProp)
    {
        _logger.LogInformation("Update : {}", mdmBomRoutingProp);
        try
        {
            var result = _mdmBomMasterDao.UpdateRoutingProp(mdmBomRoutingProp);
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
    /// BOM Routing Prop 정보를 삭제 합니다.
    /// </summary>
    /// <param name="mdmBomRoutingProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/MdmBomMaster/{projectID}/{bomID}/Routing/{routingID}/RoutingProp/{propID}")]
    public int DeleteRoutingProp(MdmBomRoutingProp mdmBomRoutingProp)
    {
        _logger.LogInformation("Delete : {}", mdmBomRoutingProp);
        try
        {
            var result = _mdmBomMasterDao.DeleteRoutingProp(mdmBomRoutingProp);
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