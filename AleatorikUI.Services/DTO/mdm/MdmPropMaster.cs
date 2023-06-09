namespace AleatorikUI.Services.DTO.mdm;

public class MdmPropMaster
{
    public string? propID { get; set; }
    public string? propCategory { get; set; }
    public string? dataType { get; set; }
    public string? description { get; set; }
    public string? reservedWord { get; set; }
    public string? defaultValue { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}