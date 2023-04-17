namespace AleatorikUI.Services.DTO.mdm;

public class MdmRoutingSub1
{
    public string? routingID { get; set; }
    public string? operationID { get; set; }
    public int sequence { get; set; }
    public string? operationType { get; set; }
    public int waitTat { get; set; }
    public int runTat { get; set; }
    public string? timeUom { get; set; }
    public int yield { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}