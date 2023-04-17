namespace AleatorikUI.Services.DTO.mdm;

public class MdmPropMaster
{
    public string? propertyID { get; set; }
    public string? category { get; set; }
    public string? valueType { get; set; }
    public string? description { get; set; }
    public string? reservedWord { get; set; }
    public string? defaultValue { get; set; }
    public string? isActive { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}