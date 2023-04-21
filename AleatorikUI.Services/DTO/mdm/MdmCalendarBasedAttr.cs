namespace AleatorikUI.Services.DTO.mdm;

public class MdmCalendarBasedAttr
{
    public string? projectID { get; set; }
    public string? calendarID { get; set; }
    public string? patternID { get; set; }
    public string? attrType { get; set; }
    public string? attrValue { get; set; }
    public string? attrDataType { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}