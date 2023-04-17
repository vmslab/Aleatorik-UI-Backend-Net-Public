namespace AleatorikUI.Services.DTO.mdm;

public class MdmResMaster
{
    public string? resourceID { get; set; }
    public string? siteID { get; set; }
    public string? location { get; set; }
    public string? category { get; set; }
    public string? resourceType { get; set; }
    public string? resourceGroupID { get; set; }
    public string? stageID { get; set; }
    public string? capacityType { get; set; }
    public string? capacityMode { get; set; }
    public string? isActive { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}