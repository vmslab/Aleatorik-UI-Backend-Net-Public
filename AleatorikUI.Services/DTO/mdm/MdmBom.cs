namespace AleatorikUI.Services.DTO.mdm;

public class MdmBom
{
    public string? bomID { get; set; }
    public string? bomType { get; set; }
    public int priority { get; set; }
    public DateTime? effStartTime { get; set; }
    public DateTime? effEndTime { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}