namespace AleatorikUI.Services.DTO.mdm;

public class MdmOperRes
{
    public string? projectID { get; set; }
    public string? routingID { get; set; }
    public string? operID { get; set; }
    public string? resID { get; set; }
    public int? flowTime { get; set; }
    public int? usagePer { get; set; }
    public int? resPriority { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}