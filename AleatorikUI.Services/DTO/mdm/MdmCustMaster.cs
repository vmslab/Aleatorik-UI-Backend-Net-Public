namespace AleatorikUI.Services.DTO.mdm;

public class MdmCustMaster
{
    public string? projectID { get; set; }
    public string? custID { get; set; }
    public string? custName { get; set; }
    public int? custPriority { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}