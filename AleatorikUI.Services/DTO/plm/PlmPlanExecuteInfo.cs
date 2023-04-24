namespace AleatorikUI.Services.DTO.plm;

public class PlmPlanExecuteInfo
{
    public string? planVer { get; set; }
    public string? scenarioID { get; set; }
    public DateTime? planStartDate { get; set; }
    public int? planPeriod { get; set; }
    public string? planType { get; set; }
    public string? executionType { get; set; }
    public string? description { get; set; }
    public string? refPlanVer { get; set; }
    public string? planStatus { get; set; }
    public DateTime? inboundStartDatetime { get; set; }
    public DateTime? inboundEndDatetime { get; set; }
    public DateTime? engineStartDatetime { get; set; }
    public DateTime? engineEndDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? createDatetime { get; set; }
}