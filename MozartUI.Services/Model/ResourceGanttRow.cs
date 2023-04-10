using MozartUI.Gantt.Data;

namespace MozartUI.Services.Model;

public class ResourceGanttRow : GanttRow
{
    public string? StageId { get; set; }
    public string? ResourceId { get; set; }
    public string? ResourceGroup { get; set; }
}
