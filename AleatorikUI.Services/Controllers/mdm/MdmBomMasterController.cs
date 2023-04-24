using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DTO.mdm;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.mdm;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
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
    /// <param name="mdmBomMaster"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmBomMaster")]
    public IEnumerable<MdmBomMaster> GetAll(String projectID, [FromQuery] MdmBomMaster mdmBomMaster)
    {
        try
        {
            mdmBomMaster.projectID = projectID;
            var result = _mdmBomMasterDao.GetAll(mdmBomMaster);
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomMaster"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmBomMaster")]
    public int Insert(String projectID, MdmBomMaster mdmBomMaster)
    {
        try
        {
            mdmBomMaster.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomMaster"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmBomMaster/{bomID}")]
    public int Update(String projectID, MdmBomMaster mdmBomMaster)
    {
        _logger.LogInformation("Update : {}", mdmBomMaster);
        try
        {
            mdmBomMaster.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomMaster"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmBomMaster/{bomID}")]
    public int Delete(String projectID, MdmBomMaster mdmBomMaster)
    {
        _logger.LogInformation("Delete : {}", mdmBomMaster);
        try
        {
            mdmBomMaster.projectID = projectID;
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
    /// <param name="mdmBomDetail"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmBomMaster/{bomID}/Detail")]
    public IEnumerable<MdmBomDetail> GetAllDetail(String projectID, [FromQuery] MdmBomDetail mdmBomDetail)
    {
        try
        {
            mdmBomDetail.projectID = projectID;
            var result = _mdmBomMasterDao.GetAllDetail(mdmBomDetail);
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomDetail"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmBomMaster/{bomID}/Detail")]
    public int InsertDetail(String projectID, MdmBomDetail mdmBomDetail)
    {
        try
        {
            mdmBomDetail.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomDetail"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmBomMaster/{bomID}/Detail/{fromItemID}")]
    public int UpdateDetail(String projectID, MdmBomDetail mdmBomDetail)
    {
        _logger.LogInformation("Update : {}", mdmBomDetail);
        try
        {
            mdmBomDetail.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomDetail"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmBomMaster/{bomID}/Detail/{fromItemID}")]
    public int DeleteDetail(String projectID, MdmBomDetail mdmBomDetail)
    {
        _logger.LogInformation("Delete : {}", mdmBomDetail);
        try
        {
            mdmBomDetail.projectID = projectID;
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
    /// <param name="mdmBomDetailAlt"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmBomMaster/{bomID}/DetailAlt")]
    public IEnumerable<MdmBomDetailAlt> GetAllDetailAlt(String projectID, [FromQuery] MdmBomDetailAlt mdmBomDetailAlt)
    {
        try
        {
            mdmBomDetailAlt.projectID = projectID;
            var result = _mdmBomMasterDao.GetAllDetailAlt(mdmBomDetailAlt);
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomDetailAlt"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmBomMaster/{bomID}/DetailAlt")]
    public int InsertDetailAlt(String projectID, MdmBomDetailAlt mdmBomDetailAlt)
    {
        try
        {
            mdmBomDetailAlt.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomDetailAlt"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmBomMaster/{bomID}/DetailAlt/{itemID}")]
    public int UpdateDetailAlt(String projectID, MdmBomDetailAlt mdmBomDetailAlt)
    {
        _logger.LogInformation("Update : {}", mdmBomDetailAlt);
        try
        {
            mdmBomDetailAlt.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomDetailAlt"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmBomMaster/{bomID}/DetailAlt/{itemID}")]
    public int DeleteDetailAlt(String projectID, MdmBomDetailAlt mdmBomDetailAlt)
    {
        _logger.LogInformation("Delete : {}", mdmBomDetailAlt);
        try
        {
            mdmBomDetailAlt.projectID = projectID;
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
    /// <param name="mdmBomProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmBomMaster/{bomID}/Prop")]
    public IEnumerable<MdmBomProp> GetAllProp(String projectID, [FromQuery] MdmBomProp mdmBomProp)
    {
        try
        {
            mdmBomProp.projectID = projectID;
            var result = _mdmBomMasterDao.GetAllProp(mdmBomProp);
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmBomMaster/{bomID}/Prop")]
    public int InsertProp(String projectID, MdmBomProp mdmBomProp)
    {
        try
        {
            mdmBomProp.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmBomMaster/{bomID}/Prop/{propID}")]
    public int UpdateProp(String projectID, MdmBomProp mdmBomProp)
    {
        _logger.LogInformation("Update : {}", mdmBomProp);
        try
        {
            mdmBomProp.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmBomMaster/{bomID}/Prop/{propID}")]
    public int DeleteProp(String projectID, MdmBomProp mdmBomProp)
    {
        _logger.LogInformation("Delete : {}", mdmBomProp);
        try
        {
            mdmBomProp.projectID = projectID;
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
    /// <param name="mdmBomRouting"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmBomMaster/{bomID}/Routing")]
    public IEnumerable<MdmBomRouting> GetAllRouting(String projectID, [FromQuery] MdmBomRouting mdmBomRouting)
    {
        try
        {
            mdmBomRouting.projectID = projectID;
            var result = _mdmBomMasterDao.GetAllRouting(mdmBomRouting);
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomRouting"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmBomMaster/{bomID}/Routing")]
    public int InsertRouting(String projectID, MdmBomRouting mdmBomRouting)
    {
        try
        {
            mdmBomRouting.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomRouting"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmBomMaster/{bomID}/Routing/{routingID}")]
    public int UpdateRouting(String projectID, MdmBomRouting mdmBomRouting)
    {
        _logger.LogInformation("Update : {}", mdmBomRouting);
        try
        {
            mdmBomRouting.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomRouting"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmBomMaster/{bomID}/Routing/{routingID}")]
    public int DeleteRouting(String projectID, MdmBomRouting mdmBomRouting)
    {
        _logger.LogInformation("Delete : {}", mdmBomRouting);
        try
        {
            mdmBomRouting.projectID = projectID;
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
    /// <param name="mdmBomRoutingProp"></param>
    /// <returns></returns>
    [HttpGet("/api/{projectID}/MdmBomMaster/{bomID}/Routing/{routingID}/RoutingProp")]
    public IEnumerable<MdmBomRoutingProp> GetAllRoutingProp(String projectID, [FromQuery] MdmBomRoutingProp mdmBomRoutingProp)
    {
        try
        {
            mdmBomRoutingProp.projectID = projectID;
            var result = _mdmBomMasterDao.GetAllRoutingProp(mdmBomRoutingProp);
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomRoutingProp"></param>
    /// <returns></returns>
    [HttpPost("/api/{projectID}/MdmBomMaster/{bomID}/Routing/{routingID}/RoutingProp")]
    public int InsertRoutingProp(String projectID, MdmBomRoutingProp mdmBomRoutingProp)
    {
        try
        {
            mdmBomRoutingProp.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomRoutingProp"></param>
    /// <returns></returns>
    [HttpPut("/api/{projectID}/MdmBomMaster/{bomID}/Routing/{routingID}/RoutingProp/{propID}")]
    public int UpdateRoutingProp(String projectID, MdmBomRoutingProp mdmBomRoutingProp)
    {
        _logger.LogInformation("Update : {}", mdmBomRoutingProp);
        try
        {
            mdmBomRoutingProp.projectID = projectID;
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
    /// <param name="projectID"></param>
    /// <param name="mdmBomRoutingProp"></param>
    /// <returns></returns>
    [HttpDelete("/api/{projectID}/MdmBomMaster/{bomID}/Routing/{routingID}/RoutingProp/{propID}")]
    public int DeleteRoutingProp(String projectID, MdmBomRoutingProp mdmBomRoutingProp)
    {
        _logger.LogInformation("Delete : {}", mdmBomRoutingProp);
        try
        {
            mdmBomRoutingProp.projectID = projectID;
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