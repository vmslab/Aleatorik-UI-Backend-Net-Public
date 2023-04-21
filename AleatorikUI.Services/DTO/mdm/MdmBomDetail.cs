namespace AleatorikUI.Services.DTO.mdm;

public class MdmBomDetail
{
    public string? projectID { get; set; }
    public string? bomID { get; set; }
    public string? fromItemID { get; set; }
    public string? fromSiteID { get; set; }
    public string? fromBufferID { get; set; }
    public int? fromQty { get; set; }
    public string? toItemID { get; set; }
    public string? toSiteID { get; set; }
    public string? toBufferID { get; set; }
    public int? toQty { get; set; }
    public string? calendarID { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}