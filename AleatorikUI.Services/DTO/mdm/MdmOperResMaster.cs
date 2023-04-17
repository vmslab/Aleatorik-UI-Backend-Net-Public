namespace AleatorikUI.Services.DTO.mdm;

public class MdmOperResMaster
{
    public string? routingID { get; set; }
    public string? operationID { get; set; }
    public string? resourceID { get; set; }
    public string? timeUom { get; set; }
    public int priority { get; set; }
    public int usagePer { get; set; }
    public int flowTime { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}