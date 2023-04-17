namespace AleatorikUI.Services.DTO.mdm;

public class MdmDemand
{
    public string? soID { get; set; }
    public string? stageID { get; set; }
    public string? itemID { get; set; }
    public string? siteID { get; set; }
    public string? bufferID { get; set; }
    public DateTime? dueDate { get; set; }
    public int qty { get; set; }
    public int priority { get; set; }
    public string? customerID { get; set; }
    public string? demandType { get; set; }
    public int maxLatenessDays { get; set; }
    public int maxEarlinessDays { get; set; }
    public string? isRtfTarget { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}