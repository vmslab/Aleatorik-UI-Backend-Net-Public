namespace AleatorikUI.Services.DTO.mdm;

public class MdmCalendarDetail
{
    public string? projectID { get; set; }
    public string? calendarID { get; set; }
    public string? patternID { get; set; }
    public DateTime? effStartDate { get; set; }
    public DateTime? effEndDate { get; set; }
    public string? patternType { get; set; }
    public string? patternValue { get; set; }
    public int? patternPriority { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}