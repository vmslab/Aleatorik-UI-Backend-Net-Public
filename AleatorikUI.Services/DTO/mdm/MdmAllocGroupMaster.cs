namespace AleatorikUI.Services.DTO.mdm;

public class MdmAllocGroupMaster
{
    public string? allocGroupID { get; set; }
    public int sequence { get; set; }
    public string? allocType { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}