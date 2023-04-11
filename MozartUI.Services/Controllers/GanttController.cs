using Microsoft.AspNetCore.Mvc;
using MozartUI.Services.DAO;
using MozartUI.Services.DTO;
using MozartUI.Services.Model;
using MozartUI.Gantt.Util;
using MozartUI.Gantt.Data;

namespace MozartUI.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class GanttController : ControllerBase
{
    private readonly ILogger<GanttController> _logger;
    private readonly IGanttDao _ganttDao;

    public GanttController(ILogger<GanttController> logger, IGanttDao ganttDao)
    {
        _logger = logger;
        _ganttDao = ganttDao;
    }

    [HttpGet("/api/gantt/resource/info")]
    public GetResourceGanttInfo GetResourceGanttInfo()
    {
        var result = _ganttDao.GetResourceGanttInfo();
        _logger.LogInformation("result : {}", result);

        return result;
    }

    [HttpGet("/api/gantt/resource/data")]
    public IEnumerable<GanttRow> GetResourceGanttData()
    {
        var result = new List<GanttRow>();

        var datas = _ganttDao.GetResourceGanttData();

        var minStartTime = datas.Where(x => x.StartTime != null).Min(x => x.StartTime) ?? DateTime.Now;
        var maxEndTime = datas.Where(x => x.EndTime != null).Max(x => x.EndTime) ?? DateTime.Now;
        // StageId, ResourcdId 로 그룹화
        foreach (var grp in datas.GroupBy(r => new
        {
            StageId = r.StageId,
            ResourceId = r.ResourceId
        }))
        {
            var row = new ResourceGanttRow
            {
                StageId = grp.Key.StageId,
                ResourceId = grp.Key.ResourceId,
            };

            var tasks = grp.Select(r => new GanttTask
            {
                Key = r.ItemId,
                Item = r,
                StartTime = r.StartTime ?? minStartTime,
                EndTime = r.EndTime ?? maxEndTime,
                Text = r.ItemId,
            }).OrderBy(r => r.StartTime).ThenBy(r => r.EndTime).ToList();
            // StartTime, EndTime 기준 정렬

            GanttHelper.SetLevel(tasks, out int maxLevel);

            row.Tasks = tasks;
            row.MaxLevel = maxLevel;

            result.Add(row);
        }

        return result;
    }

    [HttpGet("/api/gantt/production/info")]
    public GetProductionGanttInfo GetProductionGanttInfo()
    {
        var result = _ganttDao.GetProductionGanttInfo();
        _logger.LogInformation("result : {}", result);

        return result;
    }
}