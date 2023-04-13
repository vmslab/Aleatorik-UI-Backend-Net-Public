using AleatorikUI.Gantt.Data;

namespace AleatorikUI.Services.Model;

public class ResourceGanttRow : GanttRow
{
    public string? StageId { get; set; }
    public string? ResourceId { get; set; }
    public string? ResourceGroup { get; set; }
}
