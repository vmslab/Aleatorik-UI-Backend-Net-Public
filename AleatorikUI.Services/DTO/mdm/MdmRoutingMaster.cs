namespace AleatorikUI.Services.DTO.mdm;

public class MdmRoutingMaster
{
    public string? routingID { get; set; }
    public string? description { get; set; }
    public DateTime? effStartTime { get; set; }
    public DateTime? effEndTime { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}