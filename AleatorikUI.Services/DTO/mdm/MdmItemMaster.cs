namespace AleatorikUI.Services.DTO.mdm;

public class MdmItemMaster
{
    public string? projectID { get; set; }
    public string? itemID { get; set; }
    public string? itemType { get; set; }
    public DateTime? itemName { get; set; }
    public string? itemGroup { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}