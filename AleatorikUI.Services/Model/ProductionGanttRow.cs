using AleatorikUI.Gantt.Data;

namespace AleatorikUI.Services.Model;

public class ProductionGanttRow : GanttRow
{
    public string? SiteId { get; set; }
    public string? BufferId { get; set; }
    public string? ItemId { get; set; }
}
