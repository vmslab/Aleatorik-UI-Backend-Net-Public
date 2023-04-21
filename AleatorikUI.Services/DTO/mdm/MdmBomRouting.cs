namespace AleatorikUI.Services.DTO.mdm;

public class MdmBomRouting
{
    public string? projectID { get; set; }
    public string? bomID { get; set; }
    public string? routingID { get; set; }
    public int routingPriority { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}