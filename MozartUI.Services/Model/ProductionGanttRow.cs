using MozartUI.Gantt.Data;

namespace MozartUI.Services.Model;

public class ProductionGanttRow : GanttRow
{
    public string? SiteId { get; set; }
    public string? BufferId { get; set; }
    public string? ItemId { get; set; }
}
