namespace AleatorikUI.Services.DTO.mdm;

public class MdmResGroupMaster
{
    public string? resourceGroupID { get; set; }
    public int sequence { get; set; }
    public string? allocationGroupID { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}