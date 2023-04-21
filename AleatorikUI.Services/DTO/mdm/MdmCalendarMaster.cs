namespace AleatorikUI.Services.DTO.mdm;

public class MdmCalendarMaster
{
    public string? projectID { get; set; }
    public string? calendarID { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}