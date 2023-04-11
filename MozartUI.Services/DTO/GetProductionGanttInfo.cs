namespace MozartUI.Services.DTO;

public class GetProductionGanttInfo
{
    public DateTime? StartTimeMin { get; set; }
    public DateTime? EndTimeMax { get; set; }
    public DateTime? TargetDatetimeMax { get; set; }
}

