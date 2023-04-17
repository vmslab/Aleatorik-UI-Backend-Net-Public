namespace AleatorikUI.Services.DTO.mdm;

public class MdmPmPlan
{
    public string? pmID { get; set; }
    public int priority { get; set; }
    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }
    public int pmTime { get; set; }
    public string? patternName { get; set; }
    public string? patternValue { get; set; }
    public string? pmPolicy { get; set; }
    public string? parameter { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}