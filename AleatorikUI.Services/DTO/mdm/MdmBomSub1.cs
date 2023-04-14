namespace AleatorikUI.Services.DTO.mdm;

public class MdmBomSub1
{
    public string? bomID { get; set; }
    public string? fromItemID { get; set; }
    public string? fromSiteID { get; set; }
    public string? fromBufferID { get; set; }
    public int fromQty { get; set; }
    public string? toItemID { get; set; }
    public string? toSiteID { get; set; }
    public string? toBufferID { get; set; }
    public int toQty { get; set; }
    public string? calendarID { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; } 
}