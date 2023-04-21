namespace AleatorikUI.Services.DTO.mdm;

public class MdmBomMaster
{
    public string? projectID { get; set; }
    public string? bomID { get; set; }
    public string? bomType { get; set; }
    public int? bomPriority { get; set; }
    public DateTime? effStartDate { get; set; }
    public DateTime? effEndDate { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}