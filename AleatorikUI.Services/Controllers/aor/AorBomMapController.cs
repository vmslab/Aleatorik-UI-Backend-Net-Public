using AleatorikUI.Services.DAO.aor;
using AleatorikUI.Services.DTO.aor;
using Microsoft.AspNetCore.Mvc;

namespace AleatorikUI.Services.Controllers.exp;

[ApiController]
[Route("[controller]")]
public class AorBomMapController : ControllerBase
{

    private readonly ILogger<AorBomMapController> _logger;
    private readonly IAorBomMapDao _aorBomMapDao;

    public AorBomMapController(ILogger<AorBomMapController> logger, IAorBomMapDao aorBomMapDao)
    {
        _logger = logger;
        _aorBomMapDao = aorBomMapDao;
    }

    [HttpPost("/api/GetBomItems")]
    public IEnumerable<AorBomMapInfo> GetBomMapItems(AorBomMapParam param)
    {
        try
        {
            var bomNetwork = _aorBomMapDao.GetBomNetworkInfos(param);
            var pathLog = _aorBomMapDao.GetBomPathLog(param);
            _logger.LogInformation("bomNetwork : {}", bomNetwork);
            _logger.LogInformation("pathLog : {}", pathLog);
            return bomNetwork;
        }
        catch (Exception e)
        {
            _logger.LogError("error : {}", e.Message);
            Serilog.Log.Logger.Error(e.Message);
            return new List<AorBomMapInfo>();
        }
    }
}