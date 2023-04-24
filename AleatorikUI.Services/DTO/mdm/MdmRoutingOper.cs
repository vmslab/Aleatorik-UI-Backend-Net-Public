namespace AleatorikUI.Services.DTO.mdm;

public class MdmRoutingOper
{
    public string? projectID { get; set; }
    public string? routingID { get; set; }
    public string? operID { get; set; }
    public int? operSeq { get; set; }
    public string? operType { get; set; }
    public int? waitTat { get; set; }
    public int? runTat { get; set; }
    public int? operYield { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}