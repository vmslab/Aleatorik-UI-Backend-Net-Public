namespace MozartUI.Services.DTO.exp;

public class GetResourceGanttData
{
    public string? ItemId { get; set; }
    public string? ResourceId { get; set; }
    public string? StageId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}